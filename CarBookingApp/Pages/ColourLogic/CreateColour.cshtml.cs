using CarBookingDataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.ColourLogic
{
    public class CreateColourModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;
        public CreateColourModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }

        [BindProperty]
        public Colour NewColour { get; set; }

        public void OnGet()
        { 
            
        }

        public ActionResult OnPost(Colour NewColour)
        {
            if (ModelState.IsValid)
            {
                _Context.Colours.Add(NewColour);
                _Context.SaveChanges();
                return RedirectToPage("/Logics/List");
            }
            return Page();
        }


    }
}
