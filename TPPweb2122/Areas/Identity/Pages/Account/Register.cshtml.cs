using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TPPweb2122.Models;

namespace TPPweb2122.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly UserManager<Utilizador> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<Utilizador> userManager,
            SignInManager<Utilizador> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "E-mail inválido")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Introduza o seu nome!")]
            [StringLength(100)]
            public string Nome { get; set; }

            [Required(ErrorMessage = "Introduza a sua morada!")]
            [StringLength(100)]
            public string Morada { get; set; }

            [Required(ErrorMessage = "Introduza um número de telefone válido")]
            [Phone]
            public string Telefone { get; set; }

            [Required(ErrorMessage = "Insira uma palavra-passe!")]
            [StringLength(100, ErrorMessage = "A {0} tem que ter um mínimo de {2} e um máximo de {1} caratéres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme password")]
            [Compare("Password", ErrorMessage = "A password e a confirmação são diferentes")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Indique o Tipo de Utilizador")]
            [Display(Name = "Tipo de Utilizador")]
            public int RoleId { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var user = new Utilizador();
            var role = Roles.RoleUtils.RegistSelectList.FirstOrDefault(s => s.Value == Input.RoleId.ToString());
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                if(role.Text == "Cliente")
                {
                    user = new Cliente { UserName = Input.Email, Email = Input.Email, Nome = Input.Nome, Morada = Input.Morada, Telefone = Input.Telefone, };
                }else if (role.Text == "Gestor")
                {
                    user = new Gestor { UserName = Input.Email, Email = Input.Email, Nome = Input.Nome, Morada = Input.Morada, Telefone = Input.Telefone, };
                }
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    role = Roles.RoleUtils.RegistSelectList.FirstOrDefault(s => s.Value == Input.RoleId.ToString());
                    
                    await _userManager.AddToRoleAsync(user, role.Text);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
