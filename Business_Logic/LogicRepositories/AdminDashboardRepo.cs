using Data_Layer.CustomModels;
using Business_Logic.Interface;
using Data_Layer.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;
using System.Collections;
using Data_Layer.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;


namespace Business_Logic.LogicRepositories
{
    public class AdminDashboardRepo : IAdminDashboard
    {
        private readonly ApplicationDbContext _db;

        public AdminDashboardRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<AdminDashboardcm> data()
        {


            var query = from r in _db.Requests
                        join rw in _db.Requestclients
                      on r.Requestid equals rw.Requestid
                     where r.Isdeleted==null
                        
                        select (new AdminDashboardcm
                        {
                            FirstnameRequestor = r.Firstname,
                            Firstname = rw.Firstname,
                            Createddate = r.Createddate,
                            Phonenumber = r.Phonenumber,
                            Street=rw.Street,
                            Address =rw.City+" "+rw.State,
                            Strmonth= rw.Strmonth,
                            Intdate = rw.Intdate,
                            Intyear = rw.Intyear,
                            Requesttypeid = r.Requesttypeid,
                            Email=rw.Email,
                            requestClientPhonenumber=rw.Phonenumber,
                            Lastname=rw.Lastname,
                            LastnameRequestor=r.Lastname,
                            Notes=rw.Notes,
                            Status=r.Status,
                            Requestid=rw.Requestid,
                        });

            var data=query.ToList();

            return (data);

        }


        // Block Patient
        public void blockCase(int requestId, string reasonNote)
        {
            var request=_db.Requests.FirstOrDefault(x=>x.Requestid==requestId);

            if (request != null)
            {
                if(request.Isdeleted == null)
                { 
                request.Isdeleted = new BitArray(1);
                request.Isdeleted[0] = true;
                    request.Status = 10;

                    _db.Requests.Update(request);
                    _db.SaveChanges();
                }

               


                Blockrequest blockrequest = new Blockrequest()
                {
                    Requestid = request.Requestid,
                    Phonenumber = request.Phonenumber,
                    Email = request.Email,
                    Createddate = DateTime.Now,
                    Reason = reasonNote,
                };

                _db.Blockrequests.Add(blockrequest);
                _db.SaveChanges();

            }
        }




        // Assign Case GET
        public List<Assigncase> assigncases(int requestId)
        {
            var requestClient = _db.Requestclients.FirstOrDefault(x=>x.Requestid==requestId);

            if (requestClient != null)
            {
                var query = from r in _db.Regions
                            select (new Assigncase()
                            {
                                Name = r.Name,
                                Regionid= r.Regionid,
                            });
                

                var data = query.ToList();

                return data;
            }

            return null;
        }



        // Get Physician
        public List<Physician> getPhysicianName(int physicianId)
        {
            var query = from r in _db.Physicianregions
                        join rw in _db.Physicians on r.Physicianid equals rw.Physicianid
                        where r.Regionid == physicianId
                        select (new Physician()
                        {
                            Physicianid = rw.Physicianid,
                            Firstname = rw.Firstname,
                        });

            var data=query.ToList();

            return data;
        }




        // Assign Case POST
        public void assignCasePost(int reqId, int regionId, int physicianId, string description)
        {
            var request=_db.Requests.FirstOrDefault(x=>x.Requestid == reqId);

            if(request != null)
            {
                request.Physicianid = physicianId;
                request.Status = 2;

                _db.Requests.Update(request);
                _db.SaveChanges();


                Requeststatuslog requeststatuslog = new Requeststatuslog()
                {
                    Requestid = request.Requestid,
                    Physicianid = physicianId,
                    Notes = description,
                    Createddate = DateTime.Now,
                };

                _db.Requeststatuslogs.Add(requeststatuslog);
                _db.SaveChanges();
            }
        }




        // GET View Uploads
        public ViewUploads viewUploads(int reqId)
        {
            var request = _db.Requests.FirstOrDefault(x => x.Requestid == reqId);

            if (request != null)
            {

                var query = from r in _db.Requestwisefiles
                            where r.Requestid == reqId && r.Isdeleted==null
                            select (new Documentss()
                            {
                                Filename = r.Filename,
                                Createddate = r.Createddate,
                                Requestwisefileid = r.Requestwisefileid,
                            });

                ViewUploads data=  new ViewUploads() { 
                 Requestid=request.Requestid,
                 Confirmationnumber= request.Confirmationnumber,
                 fullName = _db.Requestclients.FirstOrDefault(x => x.Requestid == reqId).Firstname + _db.Requestclients.FirstOrDefault(x => x.Requestid == reqId).Lastname,
                 documents=query.ToList()
                };

               
          
                return data;
            }
            return null;
        }





        // POST view uploads
        public void postUploads(ViewUploads cm)
        {
            string filename = cm.Upload.FileName;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", filename);
            IFormFile file = cm.Upload;

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            Requestwisefile requestwisefile = new Requestwisefile()
            {
                Requestid = cm.Requestid,
                Filename = filename,
                Createddate = DateTime.Now,
            };

            _db.Requestwisefiles.Add(requestwisefile);
            _db.SaveChanges();

        }




        // Delete file in view uploads
        public void deleteUploads(int Id)
        {
            var check=_db.Requestwisefiles.FirstOrDefault(x=>x.Requestwisefileid== Id);

            if (check!=null)
            {
                if (check.Isdeleted == null)
                {
                    check.Isdeleted = new BitArray(1);
                    check.Isdeleted[0] = true;

                    _db.Requestwisefiles.Update(check);
                    _db.SaveChanges();
                }
            }
        }




        // Send Mail in view uploads
        public void sendMail(int reqID)
        {

           

           

            
            //try
            //{
            string smtpServer = "outlook.office365.com";
                int port = 587; // Port number for SMTP (e.g., 587 for Gmail)
                string senderEmail = "tatva.dotnet.saketbarevadia@outlook.com";
                string password = "S@ket6898";
                string recipientEmail = "saketpatel139@gmail.com";
                string subject = "Documents of Request";
                string body = "Find the files uploaded for your request below";
                using (SmtpClient client = new SmtpClient(smtpServer, port))
                {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(senderEmail, password);

                using (MailMessage message = new MailMessage(senderEmail, recipientEmail, subject, body))
                    {
                        // Attach all files in a directory
                        string directoryPath = @"C:\HalloDoc\HalloDoc\wwwroot\Documents";
                        string[] files = Directory.GetFiles(directoryPath);
                        var request = from r in _db.Requestwisefiles where r.Requestid == reqID select r.Filename;
                    foreach (string file in files)
                        {
                        foreach (var item in request)
                        {
                            if (item == file.Substring(39))
                            {
                                message.Attachments.Add(new Attachment(file));
                            }
                           
                        }       
                        
                        }

                        client.Send(message);
                    }
                }

               
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = "An error occurred: " + ex.Message;
            //}
        }



    }
}
