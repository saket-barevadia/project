using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.CustomModels
{
    public class viewDocument
    {

        public string? Firstname { get; set; }

        public int Requestid { get; set; }

        public DateTime Createddate { get; set; }


        public string? Filename { get; set; }

        public IFormFile Upload { get; set; }


    }
}
