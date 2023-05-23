using CarBookingDataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.Makes
{
    public class CreateModel : PageModel
    {

        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;
        public CreateModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }

        [BindProperty]
        public Make NewMake { get; set; }

        public ActionResult OnGet()
        {
            return Page();
        }




        public ActionResult OnPost(Make NewMake)
        {
           
            CheckDuplication(NewMake);


            if (ModelState.IsValid)
            {
                _Context.Makes.Add(NewMake);
               _Context.SaveChanges();
                return RedirectToPage("/Makes/ListMakes");
            }
            {
                return Page();
            }
        }
      

        //This Method checks if a new being created exists in the DB.
        public void CheckDuplication(Make make)
        {
            var CheckDup = _Context.Makes.Where(n => n.Name == make.Name);
            if (CheckDup.Any())
            {
                throw new Exception("Error!,The Make you are trying to create exists in the Database");
               
            }
            
        }
    }
}
