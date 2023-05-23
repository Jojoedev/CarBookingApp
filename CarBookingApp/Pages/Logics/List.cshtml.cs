using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingDataLibrary;
using CarBookingDataLibrary.Migrations.Context;

namespace CarBookingApp.Pages.Logics
{
    public class IndexModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _context;

        public IndexModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Car> Cars { get; set; }


        public void OnGet()
        {
            
            var car = _context.Cars
                .Include(n => n.Make)
                .Include(n => n.Colour)
                .Include(n => n.CarModel).ToList();
            
            Cars = car;
            
        }
    }
}
