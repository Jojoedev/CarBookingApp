using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.CarModels
{
    public class DeleteCarModelModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;
        public DeleteCarModelModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _context)
        {
            _Context = _context;
        }
        

        public IActionResult OnGet(int? id)
        {
            if(id != null)
            {
                /*var DeleteItem = (from n in _Context.CarModels
                                  where n.Id == id
                                  select n).FirstOrDefault();
              */
                var DelItem = _Context.CarModels.Where(n => n.Id == id).FirstOrDefault();

                _Context.Remove(DelItem);
                _Context.SaveChanges();

            }
            return RedirectToPage("CarModelList");

        }
          
    }
}
