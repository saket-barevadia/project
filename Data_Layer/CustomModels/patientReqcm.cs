using Microsoft.AspNetCore.Http;
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
    public class PatientRequestCm
    {
        [Key]
        [Column("Userid")]
        public string Userid { get; set; }

        public string Symptons { get; set; }

        [Required(ErrorMessage ="Please Enter Your Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }




        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public string Room { get; set; }

        public IFormFile Upload { get; set; }

        public string PasswordHash { get; set; }

        public string ConfirmPasswordHash { get; set; }

        public string? Strmonth { get; set; }

        public int? Intyear { get; set; }
 
        public int? Intdate { get; set; }

    }
}

