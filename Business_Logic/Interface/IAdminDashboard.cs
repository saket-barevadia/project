using System;
using Data_Layer.CustomModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DataModels;

namespace Business_Logic.Interface
{
    public interface IAdminDashboard
    {
        public List<AdminDashboardcm> data();

        public void blockCase(int requestId, string reasonNote);

        public List<Assigncase> assigncases(int requestId);

        public List<Physician> getPhysicianName(int physicianId);

        public void assignCasePost(int reqId, int regionId, int physicianId, string description);

        public ViewUploads viewUploads(int reqId);

        public void postUploads(ViewUploads cm);

       public void deleteUploads(int Id);

        public void sendMail(int reqID);
    }
}
