using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TPPweb2122.Models
{
    public class Utilizador : IdentityUser<int>
    {
         
        [Required(ErrorMessage = "Introduza o seu nome!")]
        [StringLength(100)]
        public string Nome { get; set; }
         
        [Required(ErrorMessage = "Introduza a sua morada!")]
        [StringLength(100)]
        public string Morada { get; set; }
        [Required(ErrorMessage = "Introduza um número de telefone válido")]
        [Phone]
        public string Telefone { get; set; }
    }
}
