﻿using System;
using Business_Logic.Interface;
using Data_Layer.DataContext;
using Data_Layer.CustomModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DataModels;
using System.Net;

namespace Business_Logic.LogicRepositories
{
    public class viewCaseRepo : IviewCase
    {

        private readonly ApplicationDbContext _context;

        public viewCaseRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public viewCaseCm viewCase(int id)
        {
            var check=_context.Requestclients.FirstOrDefault(x=>x.Requestid==id);

            if(check != null)
            {
                viewCaseCm requestclient = new viewCaseCm()
                {
                    Requestid = check.Requestid,
                    Notes = check.Notes,
                    Firstname = check.Firstname,
                    Lastname = check.Lastname,
                    Strmonth = check.Strmonth,
                    Intdate = check.Intdate,
                    Intyear = check.Intyear,
                    Phonenumber = check.Phonenumber,
                    Email = check.Email,
                    Region = check.Region,
                    Address = check.Street + ", " + check.City + " " + check.State,
                    Date = new DateTime((int)check.Intyear, Convert.ToInt16(check.Strmonth), (int)check.Intdate).ToString("yyyy-MM-dd"),
                    Requesttypeid = _context.Requests.FirstOrDefault(x => x.Requestid == check.Requestid).Requesttypeid,
                    Status = _context.Requests.FirstOrDefault(x => x.Requestid == check.Requestid).Status,
                    //Confirmationnumber= _context.Requests.FirstOrDefault(x => x.Requestid == check.Requestid).Confirmationnumber,
                    Confirmationnumber= check.Firstname.Substring(0, 2) + DateTime.Now.ToString().Substring(0, 19).Replace(" ", ""),
                  
                };







                return requestclient;

            }

            return null;
        }



        // View Case POST
        public void viewCaseUpdate(viewCaseCm cm)
        {

        }

    }
}

