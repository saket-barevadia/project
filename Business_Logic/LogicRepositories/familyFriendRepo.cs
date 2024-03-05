using Data_Layer.CustomModels;
using Business_Logic.Interface;
using Data_Layer.DataContext;
using Data_Layer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Business_Logic.LogicRepositories
{
    public class familyFriendRepo : IFamilyFriendReq
    {
        private readonly ApplicationDbContext _context;

        public familyFriendRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void familyFriend(familyFriendReqcm obj)
        {


            var data = _context.Aspnetusers.FirstOrDefault(x => x.Email == obj.Emailclient);

            var user = _context.Users.FirstOrDefault(x => x.Email == obj.Emailclient);



            if (data != null)
            {

                if (user == null)
                {
                    var userTb = new User();
                    userTb.Aspnetuserid = data.Id;
                    userTb.Createdby = data.Id;
                    userTb.Createddate = DateTime.Now;
                    userTb.Firstname = obj.FirstNameclient;
                    userTb.Lastname = obj.LastNameclient;
                    userTb.Email = obj.Emailclient;
                    userTb.Mobile = obj.Phoneclient;
                    userTb.Street = obj.Street;
                    userTb.City = obj.City;
                    userTb.State = obj.State;
                    userTb.Zipcode = obj.Zipcode;
                    userTb.Strmonth = obj.Strmonth.Substring(5, 2);
                    userTb.Intdate = Convert.ToInt16(obj.Strmonth.Substring(8, 2));
                    userTb.Intyear = Convert.ToInt16(obj.Strmonth.Substring(0, 4));
                    _context.Users.Add(userTb);
                    _context.SaveChanges();
                }


                Request _request = new Request();
          
                _request.Requesttypeid = 2;
                _request.Userid = _context.Users.FirstOrDefault(x => x.Email == obj.Emailclient).Userid;
                //_request.Status = 2;
                _request.Firstname = obj.firstnamefamily;
                _request.Lastname = obj.lastnamefamily;
                _request.Phonenumber = obj.mobilefamily;
                _request.Email = obj.emailfamily;
                _request.Createddate = DateTime.Now;
                _request.Relationname = obj.Relationname;
                _request.Confirmationnumber = obj.FirstNameclient.Substring(0, 2) + DateTime.Now.ToString().Substring(0, 19).Replace(" ", "");

                _context.Requests.Add(_request);
                _context.SaveChanges();




                Requestclient _requestclient = new Requestclient();
                _requestclient.Requestid = _request.Requestid;
                _requestclient.Firstname = obj.FirstNameclient;
                _requestclient.Lastname = obj.LastNameclient;
                _requestclient.Street = obj.Street;
                _requestclient.City = obj.City;
                _requestclient.State = obj.State;
                _requestclient.Zipcode = obj.Zipcode;
                _requestclient.Email = obj.Emailclient;
                _requestclient.Phonenumber = obj.Phoneclient;
                _requestclient.Strmonth = obj.Strmonth.Substring(5, 2);
                _requestclient.Intdate = Convert.ToInt16(obj.Strmonth.Substring(8, 2));
                _requestclient.Intyear = Convert.ToInt16(obj.Strmonth.Substring(0, 4));
                _requestclient.Notes = obj.Symptons;

                _context.Requestclients.Add(_requestclient);
                _context.SaveChanges();


                string filename = obj.Upload.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", filename);
                IFormFile file = obj.Upload;

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                // Request? req = _db.Requests.FirstOrDefault(i => i.Email == obj.Email);
                // int ReqId = req.Requestid;

                var data3 = new Requestwisefile()
                {
                    Requestid = _context.Requests.FirstOrDefault(x => x.Email == obj.emailfamily).Requestid,
                    Filename = filename,
                };

                _context.Requestwisefiles.Add(data3);
                _context.SaveChanges();


            }

        }
    }
}
