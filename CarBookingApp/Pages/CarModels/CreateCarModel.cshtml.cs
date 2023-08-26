using CarBookingDataLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBookingApp.Pages.CarModels
{
    [Authorize(Roles = "IT, Accounts, IT2")]
    public class CreateCarModelModel : PageModel
    {
        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;

        public CreateCarModelModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _context)
        {
            _Context = _context;
        }

        [BindProperty]
        public CarModel CarModelObj { get; set; }

        public SelectList Make { get; set; }
        public ActionResult OnGet()
        {
            LoadData();
            return Page();
        }

        public ActionResult OnPost(CarModel CarModelObj)
        {
            CheckDuplication(CarModelObj);

            if (ModelState.IsValid)
            {
                _Context.CarModels.Add(CarModelObj);
                _Context.SaveChanges();
                return RedirectToPage("/CarModels/CarModelList");
            }
            LoadData();
            return Page();
        }
        private void CheckDuplication(CarModel carModel)
        {
            var CheckDup = _Context.CarModels.Where(n => n.Name == carModel.Name);
            if (CheckDup.Any())
            {
                //throw new Exception($"Error!,The {CarModelObj.Name} you are trying to create exists in the Database");
                throw new InvalidOperationException($"Error!,The {CarModelObj.Name} you are trying to create exists in the Database");
            
            }        

        }

        private void LoadData()
        {
            Make = new SelectList(_Context.Makes.ToList(), "Id", "Name");
        }
    }
}
