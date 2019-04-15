using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRCTS.Models;

namespace DRCTS.Tests.Fakes
{
    public class FakedrctsRepo : IdrctsRepository
    {
        private List<tDRCRequest> fTDRCRequest;
        private List<Employee> fEmployee;
        private List<UserAccountsResult> fUsers;
        private List<OACode> fOA;
        private List<RTCode> fReqType;
        private List<MD715Code> fMD715;
        private List<DisbCode> fDisa;
        private List<GradeCode> fGrades;
        private List<NOTECODE> fnotes;
        private List<AMD715Code> fAMD715;
        private List<ResultsResult> fResult;
       // DRCTSClassesDataContext dc = new DRCTSClassesDataContext();
        //drctsRepository drcRepo = new drctsRepository();
        public FakedrctsRepo(List<tDRCRequest> drcRequest, List<UserAccountsResult> users, List<OACode> oa, 
            List<RTCode> rt, List<MD715Code> md715, List<AMD715Code> amd715, List<DisbCode> disab, List<NOTECODE> note, List<GradeCode> gsGrades, List<ResultsResult> rResult)
        {
            fTDRCRequest = drcRequest;
            fUsers = users;
            fOA = oa;
            fReqType = rt;
            fMD715 = md715;
            fDisa = disab;
            fnotes = note;
            fAMD715 = amd715;
            fGrades = gsGrades;
            fResult = rResult;
        }
        public void addEmp(string empid, string empfname, string emplname, string empemail)
        {
            // emp.DOCR_Employee(empid, empfname, emplname, empemail);
            Employee emp = new Employee()
            {
                EmployeeID = empid,
                EmployeeEmail = empemail,
                EmployeeFirstName = empfname,
                EmployeeLastName = emplname,
                ID = 999
            };
            //fEmployee.Add(emp);
            
            //throw new NotImplementedException();
        }

        public void addNAEmp(string empid, string empfname, string emplname, string empemail)
        {
            // emp.DOCR_Employee(empid, empfname, emplname, empemail);
            Employee emp = new Employee()
            {
                EmployeeID = empid,
                EmployeeEmail = empemail,
                EmployeeFirstName = empfname,
                EmployeeLastName = emplname,
                ID = 999
            };
            //fEmployee.Add(emp);

            //throw new NotImplementedException();
        }

        public IQueryable<Employee> getEmployeesID(int id)
        {
           
            return fEmployee.AsQueryable();
        }
        public void upEmp(string empid, string empfname, string emplname, string empemail)
        {
            // emp.DOCR_Employee(empid, empfname, emplname, empemail);
            Employee emp = new Employee()
            {
                EmployeeID = empid,
                EmployeeEmail = empemail,
                EmployeeFirstName = empfname,
                EmployeeLastName = emplname,
                ID = 999
            };
            //fEmployee.Add(emp);

            //throw new NotImplementedException();
        }
        public Employee getEMP(string id)
        {
            Employee emp = new Employee()
            {
                EmployeeID = "E333444",
                EmployeeEmail = "N/A",
                EmployeeFirstName = "empfname",
                EmployeeLastName = "emplname",
                ID = 999
            };
            return emp;
        }
        public List<tDRCRequest> getRequestList(int id)
        {
            return fTDRCRequest.Where(p => p.ID == id).ToList();
            //return dc.tDRCRequests.Where(p => p.ID == id).ToList();
        }
        public void addRequest(tDRCRequest req)
        {
            fTDRCRequest.Add(req);
            //throw new NotImplementedException();
        }

        public IQueryable<ANALYSTCODE> anaylistTemp()
        {
            throw new NotImplementedException();
        }

        public IQueryable<OACode> code1()
        {
            
            //return drcRepo.code1();
            //throw new NotImplementedException();
            return fOA.AsQueryable();
        }

        public IsDeleteUserResult deleted(string id)
        {
            throw new NotImplementedException();
        }
        public List<tDRCRequest> allReq()
        {
            return fTDRCRequest.ToList();
            //throw new NotImplementedException();
        }
        public List<ResultsResult> allSearch()
        {
            return fResult.ToList();
        }
        public Task DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DisbCode> Disability()
        {
            //throw new NotImplementedException();
            //return drcRepo.Disability();
            return fDisa.AsQueryable();
        }
        
        public List<UserAccountsResult> DRCAnaylist()
        {
            
            return fUsers.ToList();
            //throw new NotImplementedException();
        }

        public List<OpenUserRequestsResult> DRCOpenAssigned(string uname)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RTCode> DRCRequestType()
        {
            return fReqType.AsQueryable();
            throw new NotImplementedException();
        }

        public List<ApplicationAccountsResult> DRCUsers()
        {
            throw new NotImplementedException();
        }
        public bool empExists(string empEmail, string empFname, string empLname)
        {
            return false;
        }
        public bool empNAExists(string empEmail, string empFname, string empLname)
        {
            return false;
        }
        public string empID(string empEmail)
        {
            //throw new NotImplementedException();
            return "1";
        }
        public string empNAID(string empEmail, string empFname, string empLname)
        {
            //throw new NotImplementedException();
            return "1";
        }
        public IQueryable<Employee> getEmployees()
        {
            throw new NotImplementedException();
        }

        public tDRCRequest getRequest(int id)
        {
            return fTDRCRequest.SingleOrDefault(p => p.ID == id);

            // throw new NotImplementedException();
        }

        public string getUserName(string id)
        {
            return "Moore";
            //throw new NotImplementedException();
        }
        public string getUserNameByEmail(string email)
        {
            return "Moore";
        }
        public bool isAssigned(int id)
        {
            if (fTDRCRequest.SingleOrDefault(d => d.ID == id).AnalystAssigned == null)
            {
                return true;
            }
            return false;
        }
        public string getEmail(string id)
        {
            string email = "charles.moore.ctr@dot.gov";
            return email;
            //throw new NotImplementedException();
        }
        public void lAccess(string uname)
        {
            throw new NotImplementedException();
        }

        public void LockUser(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<NOTECODE> notes()
        {
            //throw new NotImplementedException();
            return fnotes.AsQueryable();
        }
        public IQueryable<GradeCode> getGrades()
        {
            return fGrades.AsQueryable();
        }
        public IQueryable<MD715Code> rMD715()
        {
            //throw new NotImplementedException();
            return fMD715.AsQueryable();
        }
        public IQueryable<AMD715Code> aMD715()
        {
            //throw new NotImplementedException();
            return fAMD715.AsQueryable();
        }
        public Task<List<ApplicationRolesResult>> RoleDRC()
        {
            throw new NotImplementedException();
        }

        public List<DisabilityReportResult> rptDisability(string year)
        {
            throw new NotImplementedException();
        }

        public List<MD715ReportResult> rptMD715(string year)
        {
            throw new NotImplementedException();
        }
        public List<ReqMD715ReportResult> reqrptMD715(string year)
        {
            throw new NotImplementedException();
        }
        public List<RAAnylistResult> rptRAAnylist(string year)
        {
            throw new NotImplementedException();
        }

        public List<ServiceReportResult> rptService(string year)
        {
            throw new NotImplementedException();
        }

        public List<StatusReportResult> rptStatus(string year)
        {
            throw new NotImplementedException();
        }

        public List<CustomSearchResult> rSearch()
        {
            throw new NotImplementedException();
        }

        public List<CustomResultsResult> rSearch44()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            //throw new NotImplementedException();
        }

        public void UnDeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public void UnlockUser(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRequest(RequestViewModel toTable, int id)
        {
            tDRCRequest nRequest = fTDRCRequest.SingleOrDefault(p => p.ID == id);
            nRequest.ID = toTable.ID;
            nRequest.OA = toTable.OA;
            nRequest.CaseID = toTable.CaseID;
            nRequest.EmployeeID = toTable.EmployeeID;
            nRequest.EmployeeLastName = toTable.EmployeeLastName;
            nRequest.EmployeeFirstName = toTable.EmployeeFirstName;
            nRequest.Position = toTable.Position;
            nRequest.Grade = toTable.Grade;
            nRequest.EmployeePhone = toTable.EmployeePhone;
            nRequest.EmployeeEmail = toTable.EmployeeEmail;
            nRequest.Disability = toTable.Disability;
            nRequest.SupervisorLastName = toTable.SupervisorLastName;
            nRequest.SupervisorFirstName = toTable.SupervisorFirstName;
            nRequest.SupervisorPhone = toTable.SupervisorPhone;
            nRequest.Description = toTable.Description;
            nRequest.DateRequestReceived = toTable.DateRequestReceived;
            nRequest.COWADate = toTable.COWADate;
            nRequest.QuarterReceived = toTable.QuarterReceived;
            nRequest.DateCompleted = toTable.DateCompleted;
            nRequest.DateFulfilled = toTable.DateFulfilled;
            nRequest.DRCRequestType = toTable.DRCRequestType;
            nRequest.DRCStatus = toTable.DRCStatus;
            nRequest.OC = toTable.OC;
            nRequest.Source = toTable.Source;
            nRequest.RequestedMD715 = toTable.RequestedMD715;
            nRequest.EndMD715 = toTable.EndMD715;
            nRequest.AnalystAssigned = toTable.AnalystAssigned;
            nRequest.TFToday = toTable.TFToday;
            nRequest.TFReportDate = toTable.TFReportDate;
            nRequest.ReportInOut = toTable.ReportInOut;
            nRequest.Notes = toTable.Notes;
            nRequest.Comments = toTable.Comments;
            nRequest.deleted = toTable.deleted;
            nRequest.CreatedBy = toTable.CreatedBy;
            nRequest.Purchasing = toTable.Purchasing;
            nRequest.PRNumber = toTable.PRNumber;
            nRequest.UpdatedBy = toTable.UpdatedBy;
            //throw new NotImplementedException();
        }

        public Task<List<ApplicationAccountsResult>> UserDRC()
        {
            throw new NotImplementedException();
        }

        public DateTime? openDate(int id)
        {
            throw new NotImplementedException();
        }

        public int getCaseLength(string caseID)
        {
            throw new NotImplementedException();
        }

        public List<PurchasingCode> purch()
        {
            throw new NotImplementedException();
        }
    }
}
