using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.Makes
{
    public class DeleteMakeModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;

        public DeleteMakeModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }
        public ActionResult OnGet(int? id)
        {
            if(id != null)
            {
                var delItem = _Context.Makes.Where(n => n.Id == id).FirstOrDefault();
                _Context.Remove(delItem);
                _Context.SaveChanges();
            }
            return RedirectToPage("/Makes/ListMakes");
        }
    }
}
