using Business_Logic.Interface;
using Data_Layer.DataContext;
using Data_Layer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.LogicRepositories
{
    public class patientReqRepo : IPatientReq
    {
        private readonly ApplicationDbContext _db;

        public patientReqRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public void patientReq(User obj)
        {
            Request request = new Request();
            Requestclient requestclient = new Requestclient();
            Aspnetuser aspnetuser = new Aspnetuser();

            var data = _db.Aspnetusers.FirstOrDefault(x => x.Email == obj.Email);

            var user=_db.Users.FirstOrDefault(x=>x.Email == obj.Email);
             
            var asp=_db.Aspnetusers.FirstOrDefault(x=>x.Email==obj.Email);

            if (data != null)
            {

                if (user == null)
                {
                    obj.Aspnetuserid = asp.Id;
                    obj.Createdby = data.Id;
                    obj.Createddate = DateTime.Now;
                    _db.Users.Add(obj);
                    _db.SaveChanges();
                }

                //aspnetuser.Username = obj.Firstname;
                //aspnetuser.Email = obj.Email;
                //aspnetuser.Phonenumber = obj.Mobile;
                //aspnetuser.Ip = obj.Ip;
                //aspnetuser.Createddate = DateTime.Now;
                //_db.Aspnetusers.Add(aspnetuser);
                //_db.SaveChanges();

                request.Requesttypeid = 1;
                request.Userid = _db.Users.FirstOrDefault(x => x.Email == obj.Email).Userid;
                request.Firstname = obj.Firstname;
                request.Lastname = obj.Lastname;
                request.Phonenumber = obj.Mobile;
                request.Email = obj.Email;
                request.Status = 1;
                request.Createddate = DateTime.Now;
                request.Ip = obj.Ip;
                _db.Requests.Add(request);
                _db.SaveChanges();



                requestclient.Requestid = request.Requestid;
                requestclient.Firstname = obj.Firstname;
                requestclient.Lastname = obj.Lastname;
                requestclient.Email = obj.Email;
                requestclient.Street = obj.Street;
                requestclient.City = obj.City;
                requestclient.State = obj.State;
                requestclient.Zipcode = obj.Zipcode;
                requestclient.Ip = obj.Ip;
                _db.Requestclients.Add(requestclient);
                _db.SaveChanges();




            }




        }

    }
}
