﻿using Business_Logic.Interface;
using Data_Layer.CustomModels;
using Data_Layer.DataContext;
using Data_Layer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.LogicRepositories
{
    public class BusinessReqRepo : IBusinessReq
    {
       private readonly ApplicationDbContext _db;

        public BusinessReqRepo (ApplicationDbContext db)
        {
            _db = db;
        }

        public void businessReq(businessReqcm cm)
        {
            

            var data = _db.Aspnetusers.FirstOrDefault(x => x.Email == cm.Emailclient);

            var user=_db.Users.FirstOrDefault(x=>x.Email== cm.Emailclient);
           


            if (data != null)
            {

                if (user == null)
                {
                    var userTb = new User();
                    userTb.Aspnetuserid = data.Id;
                    userTb.Createdby = data.Id;
                    userTb.Createddate = DateTime.Now;
                    userTb.Firstname = cm.FirstNameclient;
                    userTb.Lastname = cm.LastNameclient;
                    userTb.Email = cm.Emailclient;
                    userTb.Mobile = cm.Phoneclient;
                    userTb.Street = cm.Street;
                    userTb.City = cm.City;
                    userTb.State = cm.State;
                    userTb.Zipcode = cm.Zipcode;
                    userTb.Strmonth = cm.Strmonth.Substring(5, 2);
                    userTb.Intdate = Convert.ToInt16(cm.Strmonth.Substring(8, 2));
                    userTb.Intyear = Convert.ToInt16(cm.Strmonth.Substring(0, 4));
                    _db.Users.Add(userTb);
                    _db.SaveChanges();
                }

                Request _request = new Request();
               
                _request.Requesttypeid = 4;
                _request.Userid = _db.Users.FirstOrDefault(x => x.Email == cm.Emailclient).Userid;
                _request.Firstname = cm.firstnamebusiness;
                _request.Lastname = cm.lastnamebusiness;
                _request.Phonenumber = cm.mobilebusiness;
                _request.Email = cm.emailbusiness;
                _request.Createddate = DateTime.Now;
                _request.Confirmationnumber = cm.FirstNameclient.Substring(0, 2) + DateTime.Now.ToString().Substring(0, 19).Replace(" ", "");

                _db.Requests.Add(_request);
                _db.SaveChanges();




                Requestclient _requestclient = new Requestclient();

                _requestclient.Requestid = _request.Requestid;
                _requestclient.Firstname = cm.FirstNameclient;
                _requestclient.Lastname = cm.LastNameclient;
                _requestclient.Street = cm.Street;
                _requestclient.City = cm.City;
                _requestclient.State = cm.State;
                _requestclient.Zipcode = cm.Zipcode;
                _requestclient.Email = cm.Emailclient;
                _requestclient.Phonenumber = cm.Phoneclient;
                _requestclient.Strmonth = cm.Strmonth.Substring(5, 2);
                _requestclient.Intdate = Convert.ToInt16(cm.Strmonth.Substring(8, 2));
                _requestclient.Intyear = Convert.ToInt16(cm.Strmonth.Substring(0, 4));
                _requestclient.Notes = cm.Symptons;

                _db.Requestclients.Add(_requestclient);
                _db.SaveChanges();



                Business _business = new Business();
                _business.Name = cm.firstnamebusiness + " " + cm.lastnamebusiness;
                _business.City = cm.City;
                _business.Zipcode = cm.Zipcode;
                _business.Createddate = DateTime.Now;
                _db.Businesses.Add(_business);
                _db.SaveChanges();


                //Requestconcierge _reqCon= new Requestconcierge();
                //_reqCon.Requestid = _db.Requests.FirstOrDefault(x => x.Email == cm.emailconcierge).Requestid;
                //_reqCon.Conciergeid=_db.Concierges.FirstOrDefault(x=>x.)


            }

        }
    }
        }
 