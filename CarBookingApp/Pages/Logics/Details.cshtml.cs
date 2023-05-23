using CarBookingDataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Logics
{
    public class DetailsModel : PageModel
    {

        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _context;
        public DetailsModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }
        public SelectList Makes { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                
                Car = _context.Cars.
                    Include(n => n.Make)
                    .Include(n => n.CarModel)
                    .Include(n => n.Colour)
                    .FirstOrDefault(n => n.Id == id);

                
                 
                    /*(from n in _context.Cars 
                       where n.Id == id
                       select n).FirstOrDefault();*/
                

            }
            else
            {
             
            }
        }
    }
}
