using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.ColourLogic
{
    public class DeleteColourModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;

        public DeleteColourModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id != null)
            {
                /*var delItem = (from n in _Context.Colours
                               where n.Id == id
                               select n).FirstOrDefault();*/

                var delItem = _Context.Colours.Where(n => n.Id == id).FirstOrDefault();

                _Context.Remove(delItem);
                _Context.SaveChanges();
            }

            return RedirectToPage("/ColourLogic/ColourList");
        }

    }
}
