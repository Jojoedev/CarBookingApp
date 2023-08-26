using CarBookingDataLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.ColourLogic
{
    [Authorize(Roles = "IT, Accounts, IT2")]
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
            CheckDuplication(NewColour);
            if (ModelState.IsValid)
            {
                _Context.Colours.Add(NewColour);
                _Context.SaveChanges();
                return RedirectToPage("/Logics/List");
            }
            return Page();
        }

        private void CheckDuplication(Colour colour)
        {
            var CheckDup = _Context.Colours.Where(n => n.Name == colour.Name);
            if (CheckDup.Any())
            {
                throw new Exception($"Error!,The {NewColour.Name} colour you are trying to create exists in the Database");
                
            }
        
        }
    }
}
