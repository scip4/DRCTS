using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DRCTS.Models
{
    public class drctsRepository
    {
        DRCTSClassesDataContext dc = new DRCTSClassesDataContext();
        public void lAccess(string uname)
        {
            dc.LastAccess(uname);
        }

        public List<ApplicationAccountsResult> DRCUsers()
        {
            return dc.ApplicationAccounts("DRC").ToList();
        }
        public async Task<List<ApplicationAccountsResult>> UserDRC()
        {
            await Task.Delay(1000);
            return dc.ApplicationAccounts("DRC").ToList();
        }
        public List<OpenUserRequestsResult> DRCOpenAssigned(string uname)
        {
            return dc.OpenUserRequests("DRC", uname).ToList();
        }
        public List<UserAccountsResult> DRCAnaylist()
        {
            //await Task.Delay(1000);
            return dc.UserAccounts("DRC").ToList();
        }
        public async Task<List<ApplicationRolesResult>> RoleDRC()
        {
            await Task.Delay(1000);
            return dc.ApplicationRoles("DRC").ToList();
        }
        public tDRCRequest getRequest(int id)
        {
            return dc.tDRCRequests.SingleOrDefault(p => p.ID == id);
        }
        public void UnlockUser(string id)
        {
            dc.UnlockUser(id);
        }
        public void LockUser(string id)
        {
            dc.LockUser(id);
        }
         public IQueryable<OACode> code1()
        {
            return dc.OACodes;
        }
        public IQueryable<ANALYSTCODE> anaylistTemp()
        {
            return dc.ANALYSTCODEs;
        }
        public IQueryable<RTCode> DRCRequestType()
        {
            return dc.RTCodes;
        }
        public IQueryable<MD715Code> rMD715()
        {
            return dc.MD715Codes;
        }
        public IQueryable<DisbCode> Disability()
        {
            return dc.DisbCodes;
        }
        public IQueryable<NOTECODE> notes()
        {
            return dc.NOTECODEs;
        }
        public void addRequest(tDRCRequest req)
        {
            
            dc.tDRCRequests.InsertOnSubmit(req);
        }
        public void UpdateRequest(RequestViewModel req, int id)
        {
            tDRCRequest UserData = dc.tDRCRequests.Where(u => u.ID == id).SingleOrDefault();
            UserData.UpdatedBy = "shit";
            dc.SubmitChanges();
            

        }
        public List<ServiceReportResult> rptService()
        {
            return dc.ServiceReport().ToList();
        }
        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}