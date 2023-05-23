using CarBookingDataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Logics
{
    public class EditModel : PageModel
    {
        public readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;

        public EditModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }


        [BindProperty]
        public Car car { get; set; }

        public ActionResult OnGet(int? id)
        {
            if(id != null)
            {
                /*car = (from n in _Context.Cars
                              where n.Id == id
                              select n).FirstOrDefault();*/

                //car = _Context.Cars.Include(n => n.Make).FirstOrDefault(n => n.Id == id);
               
                car = _Context.Cars
                     .Include(n => n.Make)
                     .Include(n => n.CarModel)
                     .Include(n => n.Colour).FirstOrDefault(n => n.Id == id);


            }
            return Page();
        }

        public ActionResult OnPost(Car car)
        {
            if (ModelState.IsValid)
            {

              //_Context.Entry(car).Property(x => x.Make).IsModified = true;
              // _Context.Entry(car).Property(x => x.Make).IsModified = true;
                _Context.Entry(car).Property(x => x.Year).IsModified = true;
                _Context.Entry(car).Property(x => x.Location).IsModified = true;
                _Context.Entry(car).Property(x => x.NameOfDriver).IsModified = true;
                _Context.Entry(car).Property(x => x.NumberPlate).IsModified = true;
                _Context.Entry(car).Property(x => x.Id).IsModified = false;
               // _Context.Entry(car).Property(x => x.Model).IsModified = true;
                _Context.Entry(car).Property(x => x.MakeId).IsModified = false;

                _Context.SaveChanges();

            }
            return RedirectToPage("/Logics/List");
        }
    }
}
