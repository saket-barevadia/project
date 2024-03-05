using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DataModels;

namespace Data_Layer.CustomModels
{
    public class viewCaseCm
    {
        public int Requestid { get; set; }

        public string Firstname { get; set; } = null!;

   
        public string? Lastname { get; set; }

        public string? Phonenumber { get; set; }

        public string? Address { get; set; }

        public string? Notes { get; set; }

     
        public string? Email { get; set; }

        public string? Strmonth { get; set; }

        public string? Date { get; set; }


        public int? Intyear { get; set; }


        public int? Intdate { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public virtual Region? Region { get; set; }

        public int Requesttypeid { get; set; }

        public short Status { get; set; }


        public string? Confirmationnumber  { get; set; }

    }
}
