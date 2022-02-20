using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TPPweb2122.Roles
{
    static public class RoleUtils
    {
        private static List<IdentityRole<int>> roles = new List<IdentityRole<int>>
        {
            new IdentityRole<int>{  Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "1"},
            new IdentityRole<int>{  Id = 2, Name = "Gestor", NormalizedName = "GESTOR", ConcurrencyStamp = "2"},
            new IdentityRole<int>{  Id = 3, Name = "Funcionario", NormalizedName = "FUNCIONARIO", ConcurrencyStamp = "3"},
            new IdentityRole<int>{  Id = 4, Name = "Cliente", NormalizedName = "CLIENTE", ConcurrencyStamp = "4"},
        };

        static public List<IdentityRole<int>> All
        {
            get
            {
                return roles;
            }
        }

        static public IEnumerable<SelectListItem> RegistSelectList
        {
            get
            {
                return roles.Where(r => r.Id == 2 || r.Id == 4)
                    .Select(r => new SelectListItem()
                    {
                        Text = r.Name,
                        Value = r.Id.ToString()
                    });
            }
        }
    }
}
