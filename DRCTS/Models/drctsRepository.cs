using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using DRCTS.Models;

namespace DRCTS.Models
{
    public class drctsRepository : IdrctsRepository
    {
        DRCTSClassesDataContext dc = new DRCTSClassesDataContext();
        EmpDataClassesDataContext emp = new EmpDataClassesDataContext();
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
        public async Task DeleteUser(string id)
        {
            await Task.Delay(1000);
            dc.DeleteUser(id);
        }
        public IsDeleteUserResult deleted(string id)
        {
            return dc.IsDeleteUser(id).SingleOrDefault();
        }
        public void UnDeleteUser(string id)
        {
            dc.UnDeleteUser(id);
        }
        public int getCaseLength(string caseID)
        {
            return (int)dc.fn_getTFT(caseID);
        }
        public List<tDRCRequest> getRequestList(int id)
        {
            return dc.tDRCRequests.Where(p => p.ID == id).ToList();
        }
        public tDRCRequest getRequest(int id)
        {
            return dc.tDRCRequests.SingleOrDefault(p => p.ID == id);
        }

        public Employee getEMP(string id)
        {
            return emp.Employees.SingleOrDefault(p => p.EmployeeID == id);
        }

        public List<tDRCRequest> allReq()
        {
            return dc.tDRCRequests.ToList(); 
        }

        public void UnlockUser(string id)
        {
            dc.UnlockUser(id);
        }
        public void LockUser(string id)
        {
            dc.LockUser(id);
        }
        public IQueryable<Employee> getEmployees()
        {
           return emp.Employees.OrderBy(s=> s.EmployeeLastName);
        }

        public IQueryable<Employee> getEmployeesID(int id)
        {
            return emp.Employees.Where(c=> c.ID == id);
        }
        public void addEmp(string empid, string empfname, string emplname, string empemail)
        {
            emp.DOCR_Employee(empid, empfname, emplname, empemail);
        }
        public void addNAEmp(string empid, string empfname, string emplname, string empemail)
        {
            emp.DOCR_EmployeeNA(empid, empfname, emplname, empemail);
        }
        public void upEmp(string empid, string empfname, string emplname, string empemail)
        {
            emp.DOCR_UpdateEmployee(empid, empfname, emplname, empemail);
        }
        public List<PurchasingCode> purch()
        {
            return dc.PurchasingCodes.ToList();
        }
        public List<ResultsResult> allSearch()
        {
            return dc.Results().ToList();
        }
        public List<CustomResultsResult> rSearch44()
        {
            return dc.CustomResults().ToList();
        }
        public List<CustomSearchResult> rSearch()
        {
            return dc.CustomSearch().ToList();
        }
        public IQueryable<OACode> code1()
        {
            return dc.OACodes;
        }
        public string getDis(int id)
        {
           return dc.DisbCodes.SingleOrDefault(d => d.ID == id).DISABCODES.ToString();
           
        }
        public string getUserName(string id)
        {
            return dc.fn_getUserName(id).ToString();
        }
        public string getUserNameByEmail(string email)
        {
            return dc.fn_getUserNameBEmail(email).ToString();
        }
        public DateTime? openDate(int id)
        {
            tDRCRequest od = new tDRCRequest();
            od = dc.tDRCRequests.SingleOrDefault(d => d.ID == id);
            return od.assignedopenDate;
        }
        public bool isAssigned(int id)
        {
            if(id == 10000000)
            {
                return true;
            }
           // var test = dc.tDRCRequests.SingleOrDefault(d => d.ID == id).AnalystAssigned;
            if (dc.tDRCRequests.SingleOrDefault(d=> d.ID == id).AnalystAssigned == null)
            {
                return false;
            }
            return true;
        }
        public string getEmail(string id)
        {
            return dc.fn_getEmail(id).ToString();
        }
        public bool empExists(string empEmail, string empFname, string empLname)
        {
            Employee tr = new Employee();
            tr = emp.Employees.Where(u => u.EmployeeEmail == empEmail).SingleOrDefault();
            if(tr == null) 
            {
                return false;
            } else
            {
                if((tr.EmployeeFirstName == empFname) && (tr.EmployeeLastName == empLname))
                {
                    return false;
                } else
                {
                    return true;
                }
            }
        }

        public bool empNAExists(string empEmail, string empFname, string empLname)
        {
            Employee tr = new Employee();
            tr = emp.Employees.Where(u => u.EmployeeEmail == empEmail).Where(u=> u.EmployeeFirstName == empFname).Where(u=> u.EmployeeLastName == empLname).SingleOrDefault();
            if (tr == null)
            {
                return false;
            }
            else
            {
                /*if ((tr.EmployeeFirstName == empFname) && (tr.EmployeeLastName == empLname))
                {
                    return false;
                }
                else
                {*/
                    return true;
                //}
            }
        }
        public string empID(string empEmail)
        {
            string es = "test";
            try
            {
                es = emp.Employees.Where(u => u.EmployeeEmail == empEmail).SingleOrDefault().EmployeeID;
                
            } catch
            {
                es = emp.Employees.Count().ToString();
            }
            //return emp.DOCR_getEmployeeEM(empEmail).SingleOrDefault().ToString();
            /*if(es.Length == 0)
            {
                es = emp.Employees.Count().ToString();
            }*/
            return es;
        }
        public string empNAID(string empEmail, string empFname, string empLname)
        {
            string es = "test";
            try
            {
                es = emp.Employees.Where(u => u.EmployeeEmail == empEmail).Where(u=> u.EmployeeFirstName == empFname).Where(u => u.EmployeeLastName == empLname).SingleOrDefault().EmployeeID;

            }
            catch
            {
                es = emp.Employees.Count().ToString();
            }
            //return emp.DOCR_getEmployeeEM(empEmail).SingleOrDefault().ToString();
            /*if(es.Length == 0)
            {
                es = emp.Employees.Count().ToString();
            }*/
            return es;
        }


        public IQueryable<ANALYSTCODE> anaylistTemp()
        {
            return dc.ANALYSTCODEs.OrderBy(c => c.ANALYSTCODES);
        }
        public IQueryable<RTCode> DRCRequestType()
        {
            return dc.RTCodes.OrderBy(c => c.RequestTypeCodes);
        }
        public IQueryable<MD715Code> rMD715()
        {
            return dc.MD715Codes.Where(d => d.deleted == false).OrderBy(c => c.MD715Codes) ;
        }
        public IQueryable<GradeCode> getGrades()
        {
            return dc.GradeCodes.OrderBy(c => c.ID);
        }
        public IQueryable<AMD715Code> aMD715()
        {
            return dc.AMD715Codes.OrderBy(c => c.MD715Codes);
        }
        public IQueryable<DisbCode> Disability()
        {
            return dc.DisbCodes;
        }
        public IQueryable<NOTECODE> notes()
        {
            return dc.NOTECODEs.OrderBy(c => c.NOTECODES);
        }
        public void addRequest(tDRCRequest req)
        {
            
            dc.tDRCRequests.InsertOnSubmit(req);
        }
        public void UpdateRequest(RequestViewModel toTable, int id)
        {
            tDRCRequest nRequest = dc.tDRCRequests.Where(u => u.ID == id).SingleOrDefault();
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
            nRequest.Amount = toTable.Amount;
            nRequest.ProvidedAccom = toTable.ProvidedAccom;
            nRequest.UpdatedBy = toTable.UpdatedBy;
            nRequest.assignedopenDate = toTable.assignedopenDate;
            dc.SubmitChanges();
            

        }
        public List<ServiceReportResult> rptService(string year)
        {
            return dc.ServiceReport(year).ToList();
        }
        public List<DisabilityReportResult> rptDisability(string year)
        {
            return dc.DisabilityReport(year).ToList();
        }
        public List<StatusReportResult> rptStatus(string year)
        {
            return dc.StatusReport(year).ToList();
        }
        public List<MD715ReportResult> rptMD715(string year)
        {
            return dc.MD715Report(year).ToList();
        }

        public List<ReqMD715ReportResult> reqrptMD715(string year)
        {
            return dc.ReqMD715Report(year).ToList();
        }

        public List<RAAnylistResult> rptRAAnylist(string year)
        {
            return dc.RAAnylist(year).ToList();
        }
        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}