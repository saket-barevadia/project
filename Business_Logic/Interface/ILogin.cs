﻿using Data_Layer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interface
{
    public interface ILogin
    {
      public Aspnetuser login(string Email, string PasswordHash);
    }
}

