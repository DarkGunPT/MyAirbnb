using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TPPweb2122.Models;

namespace TPPweb2122.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly SignInManager<Utilizador> _signInManager;

        public IndexModel(
            UserManager<Utilizador> userManager,
            SignInManager<Utilizador> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Telefone")]
            public string Telefone { get; set; }

            public string Morada { get; set; }
            public string Nome { get; set; }
        }

        private async Task LoadAsync(Utilizador user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var telefone = user.Telefone;
            var nome = user.Nome;
            var morada = user.Morada;

            Username = userName;

            Input = new InputModel
            {
                Telefone = telefone,
                Nome = nome,
                Morada = morada

            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = user.Telefone;
            if (Input.Telefone != phoneNumber)
            {
                user.Telefone = phoneNumber;
                await _userManager.UpdateAsync(user);
            }
            var nome = user.Nome;
            if(nome != Input.Nome)
            {
                user.Nome = Input.Nome;
                await _userManager.UpdateAsync(user);
            }
            if(user.Morada != Input.Morada)
            {
                user.Morada = Input.Morada;
                await _userManager.UpdateAsync(user);
            }
            
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Atualizado com sucesso!";
            return RedirectToPage();
        }
    }
}
