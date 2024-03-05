using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.CustomModels
{
    public class patientDashboard
    { 
        public DateTime Createddate { get; set; }

     
        public short Status { get; set; }

        public int doc_Count { get; set; }

        public int Requestid { get; set; }

        public string Email { get; set; } = null!;


        public string? Filename { get; set; }
    }
}
