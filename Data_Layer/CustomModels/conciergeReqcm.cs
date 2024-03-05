using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.CustomModels
{
    public class ConciergeRequestCm
    {
        [Key]
        [Column("Userid")]
        public string Userid { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        public string firstnameconcierge { get; set; }

        public string lastnameconcierge { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        public string emailconcierge { get; set; }


        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string mobileconcierge { get; set; }



        public string Symptons { get; set; }

        [Required(ErrorMessage = "Please Enter Patient's Name")]
        public string FirstNameclient { get; set; }

        public string LastNameclient { get; set; }

        public string? Strmonth { get; set; }

        public int? Intyear { get; set; }

        public int? Intdate { get; set; }

        [Required(ErrorMessage = "Please Enter Patient's Email")]
        public string Emailclient { get; set; }


        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Phoneclient { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public string Room { get; set; }

        // public IFormFile Upload { get; set; }

    }
}

