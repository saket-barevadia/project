﻿using Data_Layer.DataModels;
using Data_Layer.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interface
{
    public interface IPatientReq
    {
        public void patientReq(PatientRequestCm obj);


        public int UserExist(string email);
    }
}
