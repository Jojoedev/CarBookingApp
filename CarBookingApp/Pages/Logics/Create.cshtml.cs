using CarBookingDataLibrary;
using CarBookingDataLibrary.Migrations.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Logics
{
    public class CreateModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;

        public CreateModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            this._Context = context;
        }


        [BindProperty]
        public Car NewCar { get; set; }

        public SelectList Make { get; set; }
        public SelectList CarModel { get; set; }
        public SelectList Colour { get; set; }

        public ActionResult OnGet()
        {

            LoadInitialData(); //That is to load the drop down lists.
            //Make = new SelectList(_context.Makes.ToList(), "Id", "Name");

            return Page();
        }


        public ActionResult OnPost(Car NewCar)
        {
            var dateCreated = DateTime.Now;
            dateCreated = NewCar.DateCreated;


            if (ModelState.IsValid)
            {
                _Context.Cars.Add(NewCar);
                _Context.SaveChanges();
                 return RedirectToPage("/Logics/List");
            }
            else
            {
                LoadInitialData();
                return Page();   
            }
             
        }

        public async Task<JsonResult> OnGetCarModel(int id)
        {
            var models = await _Context.CarModels
                            .Where(n => n.MakeId == id)
                            .ToListAsync();

            return new JsonResult(models);
            
        }


        //This is to load the dropdownlist
        private void LoadInitialData()
        {
            Make = new SelectList(_Context.Makes.ToList(), "Id", "Name");
            CarModel = new SelectList(_Context.CarModels.ToList(), "Id", "Name");
            Colour = new SelectList(_Context.Colours.ToList(), "Id", "Name");

        }
    }
}
