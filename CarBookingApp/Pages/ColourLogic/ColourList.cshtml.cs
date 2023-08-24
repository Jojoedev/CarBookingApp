using CarBookingDataLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.ColourLogic
{
    [Authorize]
    public class ColourListModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;
        public ColourListModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }

        [BindProperty]
        public List<Colour> ColourList { get; set; }
        public void OnGet()
        {
            ColourList = _Context.Colours.ToList();
            
        }
    }
}
