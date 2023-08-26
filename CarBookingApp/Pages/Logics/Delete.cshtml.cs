using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.Logics
{
    [Authorize(Roles = "IT")]
    public class DeleteModel : PageModel
    {

        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;

        public DeleteModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }
        public ActionResult OnGet(int? id)
        {
            if(id != null)
            {
                /*var DelCar = (from n in _Context.Cars
                              where n.Id == id
                              select n).FirstOrDefault();
                */
                var DelCar = _Context.Cars.Where(n => n.Id == id).FirstOrDefault();
                
                _Context.Remove(DelCar);
                _Context.SaveChanges();
            }
            return RedirectToPage("/Logics/List");
        }
    }
}
