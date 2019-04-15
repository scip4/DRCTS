using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRCTS.Models
{
    public interface IdrctsRepository
    {
        void addEmp(string empid, string empfname, string emplname, string empemail);
        void addNAEmp(string empid, string empfname, string emplname, string empemail);
        void upEmp(string empid, string empfname, string emplname, string empemail);
        void addRequest(tDRCRequest req);
        IQueryable<ANALYSTCODE> anaylistTemp();
        IQueryable<OACode> code1();
        IQueryable<Employee> getEmployeesID(int id);
        IsDeleteUserResult deleted(string id);
        Task DeleteUser(string id);
        IQueryable<DisbCode> Disability();
        List<UserAccountsResult> DRCAnaylist();
        List<OpenUserRequestsResult> DRCOpenAssigned(string uname);
        IQueryable<RTCode> DRCRequestType();
        List<ApplicationAccountsResult> DRCUsers();
        string empID(string empEmail);
        string empNAID(string empEmail, string empFname, string empLname);
        bool empExists(string empEmail, string empFname, string empLname);
        bool empNAExists(string empEmail, string empFname, string empLname);
        IQueryable<Employee> getEmployees();
        List<tDRCRequest> getRequestList(int id);
        tDRCRequest getRequest(int id);
        Employee getEMP(string id);
        string getUserName(string id);
        string getUserNameByEmail(string email);
        string getEmail(string id);
        bool isAssigned(int id);
        DateTime? openDate(int id);
        int getCaseLength(string caseID);
        void lAccess(string uname);
        void LockUser(string id);
        IQueryable<NOTECODE> notes();
        IQueryable<MD715Code> rMD715();
        IQueryable<AMD715Code> aMD715();
        IQueryable<GradeCode> getGrades();
        Task<List<ApplicationRolesResult>> RoleDRC();
        List<DisabilityReportResult> rptDisability(string year);
        List<MD715ReportResult> rptMD715(string year);
        List<ReqMD715ReportResult> reqrptMD715(string year);
        List<RAAnylistResult> rptRAAnylist(string year);
        List<ServiceReportResult> rptService(string year);
        List<StatusReportResult> rptStatus(string year);
        List<CustomSearchResult> rSearch();
        List<CustomResultsResult> rSearch44();
        List<ResultsResult> allSearch();
        void Save();
        void UnDeleteUser(string id);
        void UnlockUser(string id);
        void UpdateRequest(RequestViewModel toTable, int id);
        Task<List<ApplicationAccountsResult>> UserDRC();
        List<tDRCRequest> allReq();
        List<PurchasingCode> purch();
    }
}