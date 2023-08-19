using System.ComponentModel.DataAnnotations;

namespace CarBookingDataLibrary
{
    public class CarModel : BaseClass
    {
       //public int? Id { get; set; }

        [Display(Name = "Model")]
        public string Name { get; set; }

        public virtual List<Car>? Cars { get; set; }

        public int? MakeId { get; set; }

        public virtual Make? Make { get; set; }

    }
}