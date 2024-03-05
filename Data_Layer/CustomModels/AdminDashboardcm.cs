using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.CustomModels
{
    public class  AdminDashboardcm
    {

        // Model inside custom model ---------------------
        public Assigncase assigncase { get; set; }

        public ViewUploads viewUploads { get; set; }

       

        // -------------------------------------------

        public string Firstname { get; set; } = null!;

        public string? Strmonth { get; set; }

        public int? Intyear { get; set; }

        public int? Intdate { get; set; }

        public string? FirstnameRequestor { get; set; }

        public DateTime Createddate { get; set; }

        public string? Phonenumber { get; set; }
        
        public string? requestClientPhonenumber { get; set; }

        public string Lastname { get; set; } = null!;

        public string? LastnameRequestor { get; set; }

        public string? Street { get; set; }

        public string? Address { get; set; }

        public string? Notes { get; set; }

        public int Requesttypeid { get; set; }

        public string? Email { get; set; }

        public int Count { get; set; }

        public short Status { get; set; }

        public int Requestid { get; set; }

        public string Name { get; set; } = null!;

        public int Casetagid { get; set; }
    }



    public class Assigncase {
        public string Name { get; set; } = null!;

        public int Regionid { get; set; }

    }

    public class ViewUploads
    {
        public int Requestid { get; set; }

        public string? fullName { get; set; }

        public string? Confirmationnumber { get; set; }

        public IFormFile Upload { get; set; }

        public List<Documentss> documents { get; set; }

        public BitArray? Isdeleted { get; set; }
    }

    public class Documentss
    {
         public string Filename { get; set; }

         public DateTime Createddate { get; set; }

        public int Requestwisefileid { get; set; }
    }


   


}
