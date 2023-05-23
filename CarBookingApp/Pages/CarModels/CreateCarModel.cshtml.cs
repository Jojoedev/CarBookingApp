using CarBookingDataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.CarModels
{
    public class CreateCarModelModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;

        public CreateCarModelModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }

        [BindProperty]
        public CarModel CarModelObj { get; set; }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost(CarModel CarModelObj)
        {
            if (ModelState.IsValid)
            {
                _Context.CarModels.Add(CarModelObj);
                _Context.SaveChanges();
                return RedirectToPage("/Logics/List");
            }
            return Page();
        }
    }
}
