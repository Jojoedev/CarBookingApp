using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingDataLibrary
{
    public class Car : BaseClass
    {
        //public int Id { get; set; }


        [Required]
        
        [Display(Name = "Year")]

        [Range(2000,2023)]
        public int Year { get; set; }

        /*[Required]
        [Display(Name = "Model")]
        [StringLength(maximumLength: 25, MinimumLength = 3, ErrorMessage = "Must contain at least 3 letters")]
*/
        [StringLength(maximumLength: 25, MinimumLength = 3, ErrorMessage = "Must contain at least 3 letters")]
        [Required]
        [Display(Name ="User")]
        public string NameOfDriver { get; set; }
        
        
        [Required]
        [Display(Name="Number Plate")]
        public string NumberPlate { get; set; }



        [StringLength(maximumLength: 25, MinimumLength = 4, ErrorMessage = "Must contain at least 3 letters")]
        [Required]
        [Display(Name ="Vehicle Location")]
        
        
        public string Location { get; set; }

        /*[Required] */
        public int? MakeId { get; set; }

        public virtual Make? Make { get; set; }


        public int? ColourId { get; set; }
        public virtual Colour? Colour { get; set; }


        public int? CarModelId { get; set; }
        public CarModel? CarModel { get; set; }

    }
}
