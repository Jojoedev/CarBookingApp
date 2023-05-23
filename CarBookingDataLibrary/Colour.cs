using System.ComponentModel.DataAnnotations;

namespace CarBookingDataLibrary
{
    public class Colour : BaseClass
    {
        //public int? Id { get; set; }

        [Required]
        [Display(Name="Colour Name")]
        public string Name { get; set; }
       
        //public virtual List<Car> Cars { get; set; }
    }

}
