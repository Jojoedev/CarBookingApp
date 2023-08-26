using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.RoleLogics
{
    [Authorize(Roles ="IT, Accounts, IT2")]
    public class CreateModel : PageModel
    {
        public readonly RoleManager<IdentityRole> _roleManager;
        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        public IdentityRole Role { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(IdentityRole Role)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(Role);
                return RedirectToPage("/RoleLogics/List");
            }
            return Page();
        }

    }
}
