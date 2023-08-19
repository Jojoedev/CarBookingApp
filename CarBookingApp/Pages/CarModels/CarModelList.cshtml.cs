using CarBookingDataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingApp.Pages.CarModels
{
    public class CarModelListModel : PageModel
    {

        private readonly CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext _Context;

        public CarModelListModel(CarBookingDataLibrary.Migrations.Context.CarApplicationDbContext context)
        {
            _Context = context;
        }

       
        public List<CarModel> CarModel { get; set; }
       
        public void OnGet()
        {
          CarModel = _Context.CarModels.ToList();
        }


    }


}
