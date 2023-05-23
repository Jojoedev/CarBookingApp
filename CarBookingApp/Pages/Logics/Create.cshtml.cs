using CarBookingDataLibrary;
using CarBookingDataLibrary.Migrations.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBookingApp.Pages.Logics
{
    public class CreateModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _context;

        public CreateModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            this._context = context;
        }


        [BindProperty]
        public Car NewCar { get; set; }

        public SelectList Make { get; set; }
        
        public SelectList CarModel { get; set; }
        public SelectList Colour { get; set; }

        public ActionResult OnGet()
        {

            LoadInitialData();
            //Make = new SelectList(_context.Makes.ToList(), "Id", "Name");

            return Page();
        }




        public ActionResult OnPost(Car NewCar)
        {
            if (ModelState.IsValid)
            {
                _context.Cars.Add(NewCar);
                _context.SaveChanges();
               return RedirectToPage("/Logics/List");
            }
            else
            {
                LoadInitialData();
                return Page();   
            }
             
        }

        //This is to load the dropdownlist
        private void LoadInitialData()
        {
            Make = new SelectList(_context.Makes.ToList(), "Id", "Name");
            CarModel = new SelectList(_context.CarModels.ToList(), "Id", "Name");
            Colour = new SelectList(_context.Colours.ToList(), "Id", "Name");
        }

    }
}
