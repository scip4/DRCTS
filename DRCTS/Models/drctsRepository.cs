using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

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

        public async Task<List<ApplicationRolesResult>> RoleDRC()
        {
            await Task.Delay(1000);
            return dc.ApplicationRoles("DRC").ToList();
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
        public void addRequest(tDRCRequest req)
        {
            dc.tDRCRequests.InsertOnSubmit(req);
        }
        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}