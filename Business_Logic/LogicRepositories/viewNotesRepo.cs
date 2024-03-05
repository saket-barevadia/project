using System;
using Business_Logic.Interface;
using Data_Layer.DataContext;
using Data_Layer.CustomModels;
using Data_Layer.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.CustomModels;

namespace Business_Logic.LogicRepositories
{
    public class viewNotesRepo : IviewNotes
    {
        private readonly ApplicationDbContext _context;

        public viewNotesRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Requestnote viewNote(Requestnote cm,int id)
        {
            var data=_context.Requestnotes.FirstOrDefault(x=>x.Requestid==id);
            var request=_context.Requests.FirstOrDefault(x=>x.Requestid==id).Userid;
            var user = _context.Users.FirstOrDefault(x => x.Userid == request).Createdby;



                data.Adminnotes = cm.Adminnotes;
                data.Requestid = id;
                data.Createdby = user;
                    
             
                _context.Requestnotes.Update(data);
                _context.SaveChanges();

                return (data);
                                   
        }


        public Requestnote addNote(int id)
        {
          
            var request = _context.Requests.FirstOrDefault(x => x.Requestid == id).Userid;
            var user = _context.Users.FirstOrDefault(x => x.Userid == request).Createdby;
            var requestNote = _context.Requestnotes.FirstOrDefault(x => x.Requestid == id);

            if (requestNote == null)
            {
                Requestnote requestnote = new Requestnote()
                {
                    Requestid = id,
                    Createdby = user,
                    Createddate = DateTime.Now,
                };


                _context.Requestnotes.Add(requestnote);
                _context.SaveChanges();

                return (requestnote);
            }
            else
            {
                var requestNotee = _context.Requestnotes.FirstOrDefault(x => x.Requestid == id);

                return requestNotee;
            }
            
        }
    }
}
