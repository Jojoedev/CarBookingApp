using CarBookingDataLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.Makes
{
    [Authorize]
    public class ListModel : PageModel
    {

        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;
        public ListModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }

        [BindProperty]
        public List<Make> Makes { get; set; }

        public void OnGet()
        {
            Makes = _Context.Makes.ToList();
            
        }
    }
}
