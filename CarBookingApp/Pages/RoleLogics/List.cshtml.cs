using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.RoleLogics
{
    public class ListModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public ListModel(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public List<IdentityRole> Role { get; set; }

        public void OnGet()
        {
            Role = _roleManager.Roles.ToList();
        }
    }
}
