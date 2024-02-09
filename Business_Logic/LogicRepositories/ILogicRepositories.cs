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
    public class ILogicRepositories : ILogin
    {
        private readonly ApplicationDbContext _db;

        public ILogicRepositories(ApplicationDbContext db)
        {
            _db = db;
        }
        public Aspnetuser login(string Email, string PasswordHash)
        {

            var data = _db.Aspnetusers.FirstOrDefault(x => x.Email == Email && x.Passwordhash == PasswordHash);

            return data;

        }

    }
}



