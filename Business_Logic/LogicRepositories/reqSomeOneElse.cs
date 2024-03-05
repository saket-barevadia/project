using System;
using Business_Logic.Interface;
using Data_Layer.DataContext;
using Data_Layer.CustomModels;
using Data_Layer.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DataContext;
using Microsoft.AspNetCore.Http;

namespace Business_Logic.LogicRepositories
{
    public class reqSomeOneElse : IsomeoneElse
    {
        private readonly ApplicationDbContext _context;

        public reqSomeOneElse(ApplicationDbContext context)
        {
            _context = context;
        }

        public void someElse(familyFriendReqcm cm, string emaill)
        {
            var result = _context.Users.Where(x => x.Email == emaill).FirstOrDefault();

            var data = _context.Aspnetusers.FirstOrDefault(x => x.Email == cm.Emailclient);

            if (data != null)
            {

                if (result != null)
                {
                    Request newReq = new Request()
                    {
                        Requesttypeid = 1,
                        Userid = result.Userid,
                        Firstname = result.Firstname,
                        Lastname = result.Lastname,
                        Phonenumber = result.Mobile,
                        Email = result.Email,
                        Status = 2,
                        Createddate = DateTime.Now,
                        Relationname = cm.Relationname,
                        Confirmationnumber = cm.FirstNameclient.Substring(0, 2) + DateTime.Now.ToString().Substring(0, 19).Replace(" ", ""),

                };

                    _context.Add(newReq);
                    _context.SaveChanges();
                }

                Requestclient requestclient = new Requestclient()
                {
                    Requestid = _context.Requests.FirstOrDefault(x => x.Email == emaill).Requestid,
                    Firstname = cm.FirstNameclient,
                    Lastname = cm.LastNameclient,
                    Phonenumber = cm.Phoneclient,
                    Email = cm.Emailclient,
                    Street = cm.Street,
                    City = cm.City,
                    State = cm.State,
                    Zipcode = cm.Zipcode,
                    Strmonth = cm.Strmonth.Substring(5, 2),
                    Intdate = Convert.ToInt16(cm.Strmonth.Substring(8, 2)),
                    Intyear = Convert.ToInt16(cm.Strmonth.Substring(0, 4)),
            };

                _context.Add(requestclient);
                _context.SaveChanges();




                string filename = cm.Upload.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", filename);
                IFormFile file = cm.Upload;

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                // Request? req = _db.Requests.FirstOrDefault(i => i.Email == obj.Email);
                // int ReqId = req.Requestid;

                var data3 = new Requestwisefile()
                {
                    Requestid = _context.Requests.FirstOrDefault(x => x.Email == emaill).Requestid,
                    Filename = filename,
                };

                _context.Requestwisefiles.Add(data3);
                _context.SaveChanges();

            }

        }


    }
}
