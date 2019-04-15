using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRCTS.Models;
using System.Web.Security;
using M.Radwan.DevMagicFake.FakeRepositories;
using Faker;
using PublicHoliday;
using EmailValidation;
using Mail4Net;
using System.Net.Mail;
using NLog;


namespace DRCTS.Controllers
{
    public class DRCController : Controller
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        IdrctsRepository drcRepo;
        public DRCController() 
            : this(new drctsRepository())
        {

        }
        public DRCController(IdrctsRepository repo)
        {
            drcRepo = repo;
        }
        //drctsRepository drcRepo = new drctsRepository();
       // DRCTSClassesDataContext dc = new DRCTSClassesDataContext();
        // GET: DRC
        [Authorize, HandleError]
        public ActionResult Index()
        {
            ViewBag.User = User.Identity.Name;
            List<CustomSearchResult> nRes = drcRepo.rSearch();
            //IQueryable<tDRCRequest> query1 = query;
            IQueryable<CustomSearchResult> query1 = nRes.AsQueryable();
            //List<tDRCRequest> sResults = new List<tDRCRequest>();
            //var query = dc.tDRCRequests;
            //IQueryable<tDRCRequest> query1 = query;
            // query1 = query1.Where(h => h.OC == null); //.Where(e => e.deleted.Equals(false));
            IQueryable<CustomSearchResult> queryOpen = query1.Where(h => h.DRCStatus == "Open").Where(d => d.deleted == false);
            IQueryable<CustomSearchResult> queryNew = query1.Where(h => h.DRCStatus == "New").Where(d => d.deleted == false);
            IQueryable<CustomSearchResult> queryFull = query1.Where(h => h.DRCStatus == "Fulfilled").Where(d => d.deleted == false);
            IQueryable<CustomSearchResult> queryOther = query1.Where(h => h.DRCStatus == "Other").Where(d => d.deleted == false);
            IQueryable<CustomSearchResult> queryAss = query1.Where(h => h.AnalystAssigned == null).Where(d => d.deleted == false);
            ViewBag.open = queryOpen.ToList().Count;
            ViewBag.full = queryFull.ToList().Count;
            ViewBag.other = queryOther.ToList().Count;
            ViewBag.newR = queryNew.ToList().Count;
            ViewBag.testr = "sh!t";
            //TempData["Rm"] = "testing";
            return View();
        }
        public ActionResult Index2()
        {
            try
            {
                int x = 0;
                int y = 5;
                int z = y / x;
            }
            catch (Exception ex)
            {
                logger.Error(ex,"Error occured in Home controller Index Action");

            }
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }

        [Authorize]
        public PartialViewResult UserTasks()
        {
            List<OpenUserRequestsResult> oup = new List<OpenUserRequestsResult>();
            oup = drcRepo.DRCOpenAssigned(User.Identity.Name);
            return PartialView(oup);
        }
        public PartialViewResult Service_Report(string year)
        {
            List<ServiceReportResult> svr = new List<ServiceReportResult>();
            svr = drcRepo.rptService(year);
            return PartialView(svr);
        }
        public PartialViewResult Disability_Report(string year)
        {
            List<DisabilityReportResult> dbr = new List<DisabilityReportResult>();
            dbr = drcRepo.rptDisability(year);
            return PartialView(dbr);
        }
        public PartialViewResult Status_Report(string year)
        {
            List<StatusReportResult> srr = new List<StatusReportResult>();
            srr = drcRepo.rptStatus(year);
            return PartialView(srr);
        }
        public PartialViewResult MD715Report(string year)
        {
            List<MD715ReportResult> md = new List<MD715ReportResult>();
            md = drcRepo.rptMD715(year);
            return PartialView(md);
        }
        public PartialViewResult ReqMD715Report(string year)
        {
            List<ReqMD715ReportResult> md = new List<ReqMD715ReportResult>();
            md = drcRepo.reqrptMD715(year);
            return PartialView(md);
        }
        public PartialViewResult RAbyUser(string year)
        {
            List<RAAnylistResult> byRA = new List<RAAnylistResult>();
            byRA = drcRepo.rptRAAnylist(year);
            return PartialView(byRA);
        }
        public PartialViewResult CustomColumns()
        {
           
            var list = new List<CheckModel>
            {
                 new CheckModel{Id = 1, Name = "OA", Checked = true},
                 new CheckModel{Id = 2, Name = "Employee Last Name", Checked = true},
                 new CheckModel{Id = 3, Name = "Employee First Name", Checked = true},
                 new CheckModel{Id = 4, Name = "Position", Checked = false},
                 new CheckModel{Id = 5, Name = "Grade", Checked = false},
                 new CheckModel{Id = 6, Name = "Employee Phone", Checked = false},
                 new CheckModel{Id = 7, Name = "Employee Email", Checked = false},
                 new CheckModel{Id = 8, Name = "Disability", Checked = true},
                 new CheckModel{Id = 9, Name = "Supervisor Last Name", Checked = false},
                 new CheckModel{Id = 10, Name = "Supervisor First Name", Checked = false},
                 new CheckModel{Id = 11, Name = "Supervisor Email", Checked = false},
                 new CheckModel{Id = 12, Name = "Supervisor Phone", Checked = false},
                 new CheckModel{Id = 13, Name = "Description", Checked = true},
                 new CheckModel{Id = 14, Name = "Date Request Received", Checked = true},
                 new CheckModel{Id = 15, Name = "COWA Date", Checked = false},
                 new CheckModel{Id = 16, Name = "Quarter Received", Checked = false},
                 new CheckModel{Id = 17, Name = "Date Completed", Checked = false},
                 new CheckModel{Id = 18, Name = "Date Fulfilled", Checked = false},
                 new CheckModel{Id = 19, Name = "DRC Request Type", Checked = false},
                 new CheckModel{Id = 20, Name = "DRC Status", Checked = true},
                 new CheckModel{Id = 21, Name = "OC", Checked = false},
                 new CheckModel{Id = 22, Name = "Source", Checked = false},
                 new CheckModel{Id = 23, Name = "Requested MD715", Checked = false},
                 new CheckModel{Id = 24, Name = "MD-715 Category After RA process", Checked = false},
                 new CheckModel{Id = 25, Name = "Analyst Assigned", Checked = true},
                 new CheckModel{Id = 26, Name = "Describe Provided Accommodation", Checked = false},
                 new CheckModel{Id = 27, Name = "Time Frame today", Checked = false},
                 new CheckModel{Id = 28, Name = "Notes", Checked = false},
                 new CheckModel{Id = 29, Name = "Comments", Checked = false},
                 new CheckModel{Id = 30, Name = "Created By", Checked = false},
                 new CheckModel{Id = 31, Name = "Purchasing", Checked = false},
                new CheckModel{Id = 32, Name = "PR Number", Checked = false},
                new CheckModel{Id = 33, Name = "PR Amount", Checked = false},
                 new CheckModel{Id = 34, Name = "Updated By", Checked = false},
                 new CheckModel{Id = 35, Name = "Created Date", Checked = false},
                 new CheckModel{Id = 36, Name = "Updated Date", Checked = false},


            };
            return PartialView(list);
        }
        public ActionResult All_Open_Requests()
        {
            //List<CustomSearchResult> opRes = new List<CustomSearchResult>();
           // var query = dc.tDRCRequests;
             

            //List<ResultsResult> nRes = drcRepo.rSearch();
            //IQueryable<tDRCRequest> query1 = drcRepo.allReq().AsQueryable();
           IQueryable<ResultsResult> query1 = drcRepo.allSearch().AsQueryable();
            List<ResultsResult> sResults = new List<ResultsResult>();
            //var query = dc.tDRCRequests;
            //IQueryable<tDRCRequest> query1 = query;
            // query1 = query1.Where(h => h.OC == null); //.Where(e => e.deleted.Equals(false));
            query1 = query1.Where(h => h.DRCStatus == "Open").Where(d => d.deleted == false).OrderByDescending(c=> c.CreatedDate);
            //query1 = query1.Where(c => c.SupervisorLastName.Contains("Cummings"));
            //opRes = query1.ToList();
            sResults = query1.ToList();
            
            ViewBag.Header = "Open Requests";
            //return View();
            return View("searchresults", sResults);

        }
        public ActionResult All_Fulfilled_Requests()
        {
            //List<CustomSearchResult> opRes = new List<CustomSearchResult>();
            // var query = dc.tDRCRequests;


            //List<ResultsResult> nRes = drcRepo.rSearch();
            //IQueryable<tDRCRequest> query1 = drcRepo.allReq().AsQueryable();
            IQueryable<ResultsResult> query1 = drcRepo.allSearch().AsQueryable();
            List<ResultsResult> sResults = new List<ResultsResult>();
            //var query = dc.tDRCRequests;
            //IQueryable<tDRCRequest> query1 = query;
            // query1 = query1.Where(h => h.OC == null); //.Where(e => e.deleted.Equals(false));
            query1 = query1.Where(h => h.DRCStatus == "Fulfilled").Where(h => h.deleted == false).OrderByDescending(c => c.CreatedDate);
            //query1 = query1.Where(c => c.SupervisorLastName.Contains("Cummings"));
            //opRes = query1.ToList();
            sResults = query1.ToList();

            ViewBag.Header = "Fulfilled Requests";
            //return View();
            return View("searchresults", sResults);

        }
        public ActionResult All_Other_Requests()
        {
            //List<CustomSearchResult> opRes = new List<CustomSearchResult>();
            // var query = dc.tDRCRequests;


            //List<ResultsResult> nRes = drcRepo.rSearch();
            //IQueryable<tDRCRequest> query1 = drcRepo.allReq().AsQueryable();
            IQueryable<ResultsResult> query1 = drcRepo.allSearch().AsQueryable();
            List<ResultsResult> sResults = new List<ResultsResult>();
            //var query = dc.tDRCRequests;
            //IQueryable<tDRCRequest> query1 = query;
            // query1 = query1.Where(h => h.OC == null); //.Where(e => e.deleted.Equals(false));
            query1 = query1.Where(h => h.DRCStatus == "Other").Where(d => d.deleted == false).OrderByDescending(c => c.CreatedDate);
            //query1 = query1.Where(c => c.SupervisorLastName.Contains("Cummings"));
            //opRes = query1.ToList();
            sResults = query1.ToList();

            ViewBag.Header = "Other Requests";
            //return View();
            return View("searchresults", sResults);

        }


        public ActionResult Unassigned_Requests()
        {
           // List<CustomSearchResult> sResults = new List<CustomSearchResult>();
           // var query = dc.tDRCRequests;
            List<CustomSearchResult> nRes = drcRepo.rSearch();
            //IQueryable<tDRCRequest> query1 = drcRepo.allReq().AsQueryable();
            //IQueryable<CustomSearchResult> query1 = nRes.AsQueryable();
            //List<tDRCRequest> sResults = new List<tDRCRequest>();
            IQueryable<ResultsResult> query1 = drcRepo.allSearch().AsQueryable();
            List<ResultsResult> sResults = new List<ResultsResult>();
            //var query = dc.tDRCRequests;
            //IQueryable<tDRCRequest> query1 = query;
            // query1 = query1.Where(h => h.OC == null); //.Where(e => e.deleted.Equals(false));
            query1 = query1.Where(h => h.DRCStatus == "New").Where(d => d.deleted == false);
            sResults = query1.ToList();
            ViewBag.Header = "New Requests";
            return View("searchresults", sResults);

        }
        public ActionResult Analyst_Report()
        {
            List<fyYear> year = new List<fyYear>()
            {
                new fyYear {Year = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year),  Selected = true },
                new fyYear {Year = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year) - 1,  Selected = false },
                new fyYear {Year = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year) - 2,  Selected = false },
                new fyYear {Year = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year) - 3,  Selected = false },

            };
            DateTime d = DateTime.Now;
            Decimal i = d.Month / 3;
            //decimal j = 0;
            decimal m = Math.Floor(i) + 2;
            decimal j = m > 4 ? m - 4 : m;

            List<rptQuarter> qtr1 = new List<rptQuarter>()
            {
                new rptQuarter {qtr = 0, MyText="All" },
                new rptQuarter {qtr = 1 , MyText="First"},
                new rptQuarter {qtr = 2, MyText="Second" },
                new rptQuarter {qtr = 3, MyText="Third" },
                new rptQuarter {qtr = 4, MyText="Fourth" }
            };
            ViewBag.fyyear = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year);
            ViewBag.dSource = new SelectList(year, "Year", "Year", (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year));
            ViewBag.dSource2 = new SelectList(qtr1, "qtr", "MyText", 0);
            return View();
        }
        public ActionResult Summary_Report()
        {
            List<fyYear> year  = new List<fyYear>()
            {
                new fyYear {Year = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year),  Selected = true },
                new fyYear {Year = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year) - 1,  Selected = false },
                new fyYear {Year = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year) - 2,  Selected = false },

            };
            DateTime d = DateTime.Now;
            Decimal i = d.Month / 3;
            //decimal j = 0;
            decimal m = Math.Floor(i) + 2;
            decimal j =  m > 4 ? m - 4 : m;
           
            List<rptQuarter> qtr1 = new List<rptQuarter>()
            {
                new rptQuarter {qtr = 0, MyText="All" },
                new rptQuarter {qtr = 1 , MyText="First"},
                new rptQuarter {qtr = 2, MyText="Second" },
                new rptQuarter {qtr = 3, MyText="Third" },
                new rptQuarter {qtr = 4, MyText="Fourth" }
            };
            ViewBag.fyyear = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year);
            ViewBag.dSource = new SelectList(year, "Year", "Year", (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year));
            ViewBag.dSource2 = new SelectList(qtr1, "qtr", "MyText", 0);
            return View();
        }
        public ActionResult UserName(string id)
        {
            string User = "Unassigned";
            if (id != null)
            {try
                {
                    User = drcRepo.getUserName(id);
                }
                catch
                {
                    User = id;
                }
            }
            return Content(User);
        }
         [Authorize]
        public ActionResult Add_Request()
        {
            // tDRCRequest rqvm = new tDRCRequest();
           // TempData["Rm"] = "dinmo";
            List<rSource> source = new List<rSource>()
            {
                new rSource {requestType = "Employee" },
                new rSource {requestType = "Applicant" }
            };
            /*List<prStat> pur = new List<prStat>()
            {
                new prStat {id= 0, Purchasing = "None" },
                new prStat {id= 1, Purchasing  = "CAP" },
                new prStat {id= 2, Purchasing = "PR" }
            };*/
            List<PurchasingCode> pur = new List<PurchasingCode>();
            pur = drcRepo.purch();
            List<UserAccountsResult> drcUsers = new List<UserAccountsResult>();
            drcUsers = drcRepo.DRCAnaylist();
            
            string holi = "";
            string days2;
            int dyear = 2015;
           


            while (dyear <= DateTime.Now.Year)
            {
                IList<DateTime> result = new USAPublicHoliday().PublicHolidays(dyear);

                int i = 0;
                int count = result.Count();
                for (i = 0; i < count; i++)
                {
                    holi = holi + "\"" + result.ElementAt(i).Date.ToString("yyyy-MM-dd") + "\"" + ", ";
                }
                dyear++;
            }
            
            holi = holi.Remove(holi.Length - 1);
            days2 = "[" + holi.Remove(holi.Length - 1) + "]";
            ViewBag.Holiday = days2;
            ViewBag.CreateUpdate = "Add Request";
            RequestViewModel rqvm = new RequestViewModel();
            ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
            //ViewBag.Analyst = new SelectList(drcRepo.anaylistTemp(), "ANALYSTCODES", "ANALYSTCODES");
            ViewBag.Analyst = new SelectList(drcRepo.DRCAnaylist(), "Id", "Name");
            ViewBag.drcReq = new SelectList(drcRepo.DRCRequestType(), "RequestTypeCodes", "RequestTypeCodes");
            ViewBag.dSource = new SelectList(source, "requestType", "requestType");
            ViewBag.purch = new SelectList(pur, "Purchasing", "Purchasing");
            ViewBag.gsgrade = new SelectList(drcRepo.getGrades(), "Grade", "Grade");
            ViewBag.MD715 = new SelectList(drcRepo.rMD715(), "ID", "MD715Codes");
            ViewBag.eMD715 = new SelectList(drcRepo.aMD715(), "ID", "MD715Codes");
            ViewBag.dCodes = new SelectList(drcRepo.Disability(), "DISABCODES", "DISABCODES");
            ViewBag.nCodes = new SelectList(drcRepo.notes(), "NOTECODES", "NOTECODES");
            /*Quick Fake data

            rqvm.DateCompleted = new DateTime(2017, 5, 30);
            rqvm.DRCStatus = "Fulfilled";
            rqvm.EmployeeFirstName = Faker.Name.First();
            rqvm.EmployeeLastName = Faker.Name.Last();
            rqvm.EmployeeEmail = Faker.Internet.Email();
            rqvm.SupervisorFirstName = Faker.Name.First();
            rqvm.SupervisorLastName = Faker.Name.Last();
            rqvm.Description = Faker.Lorem.Paragraph();
            rqvm.Comments = Faker.Lorem.Paragraph();
            rqvm.SupervisorPhone = Faker.Phone.Number();
            rqvm.EmployeePhone = Faker.Phone.Number();
            */
            rqvm.CreatedBy = User.Identity.Name;
           

           

            return View(rqvm);
        }
        public void assignEmail(string analyst, string CaseID)
        {
            string aEmail = drcRepo.getEmail(analyst);
            var from = "DRCInbox@dot.gov";
            var to = aEmail;
            var subject = "DRC case Assigned: " + CaseID.ToString();
            var body = "DRC case " + CaseID.ToString() + " has been assigned to you";
            var client = new System.Net.Mail.SmtpClient("skyland-.startlogic.com", 587);
            client.Credentials = new System.Net.NetworkCredential("support@skyland-technologies.com", "Pa33word");
            client.Send(from, to, subject, body);
        }
        public void QACheck(RequestViewModel rvmSubModel)
        {

            if (rvmSubModel.COWADate != null)
            {
                if (rvmSubModel.COWADate < rvmSubModel.DateRequestReceived)
                {
                    this.ModelState.AddModelError("COWADate", "This date must occur after the date the request was recivied");
                }
            }
            if (rvmSubModel.DateFulfilled != null)
            {
                if (rvmSubModel.DateFulfilled < rvmSubModel.DateRequestReceived)
                {
                    this.ModelState.AddModelError("DateFulfilled", "This date must occur after the date the request was recivied");
                }
            }
            if(rvmSubModel.SupervisorEmail != null)
            {
                if (!EmailValidator.Validate(rvmSubModel.SupervisorEmail))
                {
                    this.ModelState.AddModelError("SupervisorEmail", "Supervisor email is not valid");
                }
            }
            if ((rvmSubModel.EmployeeEmail != null) && (rvmSubModel.EmployeeFirstName != null) && (rvmSubModel.EmployeeLastName != null) ) {
                if (rvmSubModel.EmployeeEmail != "N/A")
                {
                    if (!EmailValidator.Validate(rvmSubModel.EmployeeEmail))
                    {
                        this.ModelState.AddModelError("EmployeeEmail", "Employee email is not valid");
                    }

                   /* bool empCheck = drcRepo.empExists(rvmSubModel.EmployeeEmail, rvmSubModel.EmployeeFirstName, rvmSubModel.EmployeeLastName);
                    if (empCheck == true)
                    {
                        this.ModelState.AddModelError("Employee/Applicant email already exists", "There is a user that already uses the email address that you have entered with a different first and last name. Please make sure that the email is correct.");
                    }*/
                }
                if ((rvmSubModel.EmployeeFirstName != null) || (rvmSubModel.EmployeeLastName != null) || (rvmSubModel.EmployeeEmail != null))
            {

                if ((rvmSubModel.EmployeeFirstName == " ") || (rvmSubModel.EmployeeFirstName.Any(Char.IsWhiteSpace)))
                {
                    this.ModelState.AddModelError("FirstName", "First name has spaces");
                }
                if ((rvmSubModel.EmployeeLastName == " ") || (rvmSubModel.EmployeeLastName.Any(Char.IsWhiteSpace)))
                {
                    this.ModelState.AddModelError("LastName", "Employee last name has spaces");
                }
                /*if ((rvmSubModel.EmployeeEmail == "") || (rvmSubModel.EmployeeEmail.Any(Char.IsWhiteSpace)))
                {
                    this.ModelState.AddModelError("EmployeeEmail", "Employee email has spaces");
                }*/
            }
        }
        }
        [HttpPost, Authorize]
        public ActionResult Add_Request(RequestViewModel rvmSubModel)
        {
            List<rSource> source = new List<rSource>()
            {
                new rSource {requestType = "Employee" },
                new rSource {requestType = "Applicant" }
            };
            /*List<prStat> pur = new List<prStat>()
            {
                new prStat {id= 0, Purchasing = "None" },
                new prStat {id= 1, Purchasing  = "CAP" },
                new prStat {id= 2, Purchasing = "PR" }
            };*/
            List<PurchasingCode> pur = new List<PurchasingCode>();
            pur = drcRepo.purch();

            Random r = new Random();
            int num = r.Next(1, 999);
            ViewBag.CreateUpdate = "Add Request";
            ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
            //ViewBag.Analyst = new SelectList(drcRepo.anaylistTemp(), "ANALYSTCODES", "ANALYSTCODES");
            ViewBag.Analyst = new SelectList(drcRepo.DRCAnaylist(), "Id", "Name");
            ViewBag.drcReq = new SelectList(drcRepo.DRCRequestType(), "RequestTypeCodes", "RequestTypeCodes");
            ViewBag.dSource = new SelectList(source, "requestType", "requestType");
            ViewBag.purch = new SelectList(pur, "Purchasing", "Purchasing");
            ViewBag.gsgrade = new SelectList(drcRepo.getGrades(), "Grade", "Grade");
            ViewBag.MD715 = new SelectList(drcRepo.rMD715(), "ID", "MD715Codes");
            ViewBag.eMD715 = new SelectList(drcRepo.aMD715(), "ID", "MD715Codes");
            ViewBag.dCodes = new SelectList(drcRepo.Disability(), "DISABCODES", "DISABCODES");
            ViewBag.nCodes = new SelectList(drcRepo.notes(), "NOTECODES", "NOTECODES");
            QACheck(rvmSubModel);
            if (ModelState.IsValid)
            {

                int total = drcRepo.allReq().Count() + 1; //dc.tDRCRequests.Count();
                                                      // int aLen = 6 - total.ToString().Length;

                var nRequest = new tDRCRequest();
                rvmSubModel.CreatedBy = User.Identity.Name;
                rvmSubModel.UpdatedBy = User.Identity.Name;
                rvmSubModel.UpdatedDate = DateTime.Now.Date;
                rvmSubModel.CreatedDate = DateTime.Now.Date;
                rvmSubModel.CaseID = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year) + "-" + total.ToString("D5");// + "-" + rvmSubModel.OA;
                string empID;
                string empIDL;
                if (rvmSubModel.EmployeeEmail == "N/A")
                {
                    empIDL = drcRepo.empNAID(rvmSubModel.EmployeeEmail, rvmSubModel.EmployeeFirstName, rvmSubModel.EmployeeLastName);
                } else {

                empIDL = drcRepo.empID(rvmSubModel.EmployeeEmail);
                }
                /***************************************************/
                // int t1 = rvmSubModel.EmployeePhone.Length;
                //string extent = rvmSubModel.EmployeePhone.Substring(16);
                //string pmain = rvmSubModel.EmployeePhone.Substring(0,14);
                //int ext;
                //try
                //{
                //    ext = Convert.ToInt32(extent);
                //} catch
                //{
                // //   ext = 0;
                //    rvmSubModel.EmployeePhone = pmain;
                //}
                /***************************************************/
                if (rvmSubModel.AnalystAssigned != null)
                {
                    rvmSubModel.assignedopenDate = DateTime.Now.Date;
                }
                    if ((rvmSubModel.EmployeeID == null) || (empIDL.Length < 8 ))
                {

                    string eid = empIDL; //drcRepo.empID(rvmSubModel.EmployeeEmail);
                    int nlen = eid.ToString().Length;
                    if ( nlen < 8)
                    {
                        int etemp = Int32.Parse(eid.ToString());
                        etemp = etemp + 1;
                        int dlen = 6 - etemp.ToString().Length;
                        empID = "EID" + etemp.ToString("D5");
                        if ((rvmSubModel.EmployeeEmail != null) && (rvmSubModel.EmployeeEmail != "N/A"))
                        {
                            drcRepo.addEmp(empID, rvmSubModel.EmployeeFirstName, rvmSubModel.EmployeeLastName, rvmSubModel.EmployeeEmail);
                        } else if((rvmSubModel.EmployeeEmail == "N/A"))
                        {
                            drcRepo.addNAEmp(empID, rvmSubModel.EmployeeFirstName, rvmSubModel.EmployeeLastName, rvmSubModel.EmployeeEmail);
                        }
                    } else
                    {
                       
                        empID = eid.ToString();
                    }
                    rvmSubModel.EmployeeID = empID.ToString();
                } 
               
                rvmSubModel.deleted = false;
                nRequest =  new RequestViewModel(rvmSubModel);
                
                /* nRequest.OA = rvmSubModel.OA;
                 nRequest.AnalystAssigned = rvmSubModel.AnalystAssigned;
                 nRequest.CaseID = rvmSubModel.CaseID; //Need to come up with format I.E. 2015OST1
                 nRequest.Comments = rvmSubModel.Comments;
                 nRequest.COWADate = rvmSubModel.COWADate;
                nRequest.DateCompleted = rvmSubModel.DateCompleted;
                nRequest.Source = rvmSubModel.Source;
                */

                drcRepo.addRequest(nRequest);
                //drcRepo.addRequest(rvmSubModel);

                try
                {
                    drcRepo.Save();
                    if (rvmSubModel.AnalystAssigned != null)
                    {
                        assignEmail(rvmSubModel.AnalystAssigned, rvmSubModel.CaseID);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Error occured for user: " + User.Identity.Name + "     " );
                    //logger.ErrorException("Error occured in Home controller Index Action", ex);

                }
                TempData["Rm"] = "Your request has been submitted successfully";
                return RedirectToAction("Index");
            }
            else
            {
                // tDRCRequest rqvm = new tDRCRequest();
                  RequestViewModel rqvm = new RequestViewModel();




                  ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
                  //ViewBag.Analyst = new SelectList(drcRepo.anaylistTemp(), "ANALYSTCODES", "ANALYSTCODES");
                  ViewBag.Analyst = new SelectList(drcRepo.DRCAnaylist(), "ID", "Name");
                  ViewBag.drcReq = new SelectList(drcRepo.DRCRequestType(), "RequestTypeCodes", "RequestTypeCodes");
                  ViewBag.dSource = new SelectList(source, "requestType", "requestType");
                  ViewBag.purch = new SelectList(pur, "Purchasing", "Purchasing");
                ViewBag.gsgrade = new SelectList(drcRepo.getGrades(), "Grade", "Grade");
                ViewBag.MD715 = new SelectList(drcRepo.rMD715(), "ID", "MD715Codes");
                ViewBag.eMD715 = new SelectList(drcRepo.aMD715(), "ID", "MD715Codes");
                ViewBag.dCodes = new SelectList(drcRepo.Disability(), "DISABCODES", "DISABCODES");
                  ViewBag.nCodes = new SelectList(drcRepo.notes(), "NOTECODES", "NOTECODES");
                  //rqvm.EmployeeFirstName = "Error";
                  rqvm.deleted = false;
                ViewBag.test = "dvsdvsdvsdvsd";
                TempData["RegisterMessage"] = "Hello User, You have successfully registered";
                
                return View(rqvm);
              /*  var message = string.Join(" | ", ModelState.Values
       .SelectMany(v => v.Errors)
       .Select(e => e.ErrorMessage));
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, message);*/
            }
        }
        [Authorize]
        public ActionResult SearchForm()
        {
            List<rSource> source = new List<rSource>()
            {
                new rSource {requestType = "Employee" },
                new rSource {requestType = "Applicant" }
            };
            List<status> trunew = new List<status>()
            {
                new status {caseStatus = "Open" },
                new status {caseStatus = "Closed" }
            };
            /*List<prStat> pur = new List<prStat>()
            {
                new prStat {id= 0, Purchasing = "None" },
                new prStat {id= 1, Purchasing  = "CAP" },
                new prStat {id= 2, Purchasing = "PR" }
            };*/
            List<PurchasingCode> pur = new List<PurchasingCode>();
            pur = drcRepo.purch();

            List<pfStatus> drange = new List<pfStatus>()
            {
                new pfStatus {  prstatus = "Equals" },
                new pfStatus { prstatus = "Between" }
            };

            List<pfStatus> drcstat = new List<pfStatus>()
            {
                new pfStatus {prstatus = "New" },
                new pfStatus {prstatus = "Open" },
                new pfStatus {prstatus = "Fulfilled" },
                new pfStatus {prstatus = "Other" }
            };
            List<pfStatus> tftoption = new List<pfStatus>()
            {
                new pfStatus {prstatus = "Equals" },
                new pfStatus {prstatus = "Greater Than" },
                new pfStatus {prstatus = "Less Than" }
                
            };
            int dyear = 2015;
            List<rptYear> FYear = new List<rptYear>() {
            new rptYear { Year = (DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year).ToString(), Selected = true },
                new rptYear { Year = ((DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year) - 1).ToString(), Selected = false },
                new rptYear { Year = ((DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year) - 2).ToString(), Selected = false },
                new rptYear { Year = ((DateTime.Now.Month >= 10 ? DateTime.Now.Year + 1 : DateTime.Now.Year) - 3).ToString(), Selected = false },
           };
           /* while (dyear <= DateTime.Now.Year)
            {
                FYear.Add(new rptYear { Year = dyear.ToString() });
                dyear++;
            }*/
         
            ViewBag.fsYear = new SelectList(FYear, "Year", "Year");
            ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
            //ViewBag.Analyst = new SelectList(drcRepo.anaylistTemp(), "ANALYSTCODES", "ANALYSTCODES");
            ViewBag.Analyst = new SelectList(drcRepo.DRCAnaylist(), "Name", "Name");
            ViewBag.drcReq = new SelectList(drcRepo.DRCRequestType(), "RequestTypeCodes", "RequestTypeCodes");
            ViewBag.dSource = new SelectList(source, "requestType", "requestType");
            ViewBag.cstatus = new SelectList(trunew, "caseStatus", "caseStatus");
            ViewBag.purch = new SelectList(pur, "Purchasing", "Purchasing");
            ViewBag.dstat = new SelectList(drcstat, "prstatus", "prstatus");
            ViewBag.gsgrade = new SelectList(drcRepo.getGrades(), "Grade", "Grade");
            ViewBag.option = new SelectList(tftoption, "prstatus", "prstatus");
            ViewBag.MD715 = new SelectList(drcRepo.rMD715(), "ID", "MD715Codes");
            ViewBag.eMD715 = new SelectList(drcRepo.aMD715(), "ID", "MD715Codes");
            ViewBag.dCodes = new SelectList(drcRepo.Disability(), "DISABCODES", "DISABCODES");
            ViewBag.nCodes = new SelectList(drcRepo.notes(), "NOTECODES", "NOTECODES");
            ViewBag.drange = new SelectList(drange, "prstatus", "prstatus");
            searchModel sm = new searchModel();
            return View(sm);
            //var query = (from t in Model)
        }

        public static decimal ParseCurr(string input)
        {
            if (input == null)
            {
                return 0;
            }
            else
            {
                return decimal.Parse(System.Text.RegularExpressions.Regex.Replace(input, @"[^\d.]", ""));
            }
        }


        [HttpPost]
        public ActionResult SearchForm(searchModel sm1)
        {
            //List<tDRCRequest> sResults = new List<tDRCRequest>();
            List<ResultsResult> sResults = new List<ResultsResult>();
            //var query = dc.tDRCRequests;
            //List<CustomSearchResult> nRes = drcRepo.rSearch();
            //IQueryable<tDRCRequest> query1 = drcRepo.allReq().AsQueryable();
            IQueryable<ResultsResult> query1 = drcRepo.allSearch().AsQueryable();
            
            if (ModelState.IsValid)
            {
                if (sm1.OA != null)
                {
                    query1 = query1.Where(u => u.OA == sm1.OA);
                }
                if (sm1.CaseID != null)
                {
                    query1 = query1.Where(c => c.CaseID.Contains(sm1.CaseID));
                }
                if (sm1.EmployeeLastName != null)
                {
                    query1 = query1.Where(e => e.EmployeeLastName == sm1.EmployeeLastName);
                }
                if (sm1.EmployeeFirstName != null)
                {
                    query1 = query1.Where(e => e.EmployeeFirstName == sm1.EmployeeFirstName);
                }
                if (sm1.Position != null)
                {
                    query1 = query1.Where(e => e.Position == sm1.Position);
                }
                if (sm1.Purchasing != null)
                {
                    query1 = query1.Where(e => e.Purchasing == sm1.Purchasing);
                }
                if (sm1.PRNumber != null)
                {
                    query1 = query1.Where(e => e.PRNumber == sm1.PRNumber);
                }
                if (sm1.Grade != null)
                {
                    query1 = query1.Where(e => e.Grade == sm1.Grade);
                }
                if (sm1.EmployeePhone != null)
                {

                    query1 = query1.Where(e => e.EmployeePhone == sm1.EmployeePhone);
                }
                if (sm1.EmployeeEmail != null)
                {
                    query1 = query1.Where(e => e.EmployeeEmail == sm1.EmployeeEmail);
                }
                if (sm1.SupervisorFirstName != null)
                {
                    query1 = query1.Where(e => e.SupervisorFirstName == sm1.SupervisorFirstName);
                }
                if (sm1.SupervisorLastName != null)
                {
                    query1 = query1.Where(e => e.SupervisorLastName == sm1.SupervisorLastName);
                }
                if (sm1.SupervisorEmail != null)
                {
                    query1 = query1.Where(e => e.SupervisorEmail == sm1.SupervisorEmail);
                }
                if (sm1.SupervisorPhone != null)
                {
                    query1 = query1.Where(e => e.SupervisorPhone == sm1.SupervisorPhone);
                }
                if (sm1.AnalystAssigned != null)
                {
                    query1 = query1.Where(a => a.AnalystAssigned == sm1.AnalystAssigned);
                }
                if (sm1.Source != null)
                {
                    query1 = query1.Where(e => e.Source == sm1.Source);
                }
                if (sm1.Disability != null)
                {
                    query1 = query1.Where(e => e.Disability == sm1.Disability);
                }
                if (sm1.DRCRequestType != null)
                {
                    query1 = query1.Where(e => e.DRCRequestType == sm1.DRCRequestType);
                }
                if (sm1.OC != null)
                {
                    query1 = query1.Where(e => e.OC == sm1.OC);
                }
                if (sm1.DRCStatus != null)
                {
                    query1 = query1.Where(e => e.DRCStatus == sm1.DRCStatus);
                }
                if (sm1.RequestedMD715 != null)
                {
                    query1 = query1.Where(e => e.RequestedMD715 == sm1.RequestedMD715);
                }
                if (sm1.EndMD715 != null)
                {
                    query1 = query1.Where(e => e.EndMD715 == sm1.EndMD715);
                }
                if (sm1.OC != null)
                {
                    query1 = query1.Where(e => e.OC == sm1.OC);
                }
                if (( sm1.DateCompleted != null) && (sm1.endDateCompleted != null))
                {
                    query1 = query1.Where(e => e.DateCompleted >= sm1.DateCompleted).Where(e => e.DateCompleted <= sm1.endDateCompleted);
                }
                if ((sm1.DateCompleted != null) && (sm1.endDateCompleted == null))
                {
                    query1 = query1.Where(e => e.DateCompleted.Equals(sm1.DateCompleted));
                }
                if ((sm1.COWADate != null) && (sm1.endCOWADate != null))
                {
                    query1 = query1.Where(e => e.COWADate >= sm1.COWADate).Where(e => e.COWADate <= sm1.endCOWADate);
                }
                if ((sm1.COWADate != null) && (sm1.endCOWADate == null))
                {
                    query1 = query1.Where(e => e.COWADate.Equals(sm1.COWADate));
                }
                if ((sm1.DateFulfilled != null) && (sm1.endDateFulfilled != null))
                {
                    query1 = query1.Where(e => e.DateFulfilled >= sm1.DateFulfilled).Where(e => e.DateFulfilled <= sm1.endDateFulfilled);
                }
                if ((sm1.DateFulfilled != null) && (sm1.endDateFulfilled == null))
                {
                    query1 = query1.Where(e => e.DateFulfilled.Equals(sm1.DateFulfilled));
                }
                if ((sm1.DateRequestReceived != null) && (sm1.endDateRequestReceived != null))
                {
                    //query1 = query1.Where(e => e.DateRequestReceived.Value >= sm1.endDateRequestReceived.Value && e.DateRequestReceived.Value <= sm1.endDateRequestReceived.Value);
                    query1 = query1.Where(e => e.DateRequestReceived >= sm1.DateRequestReceived).Where(e => e.DateRequestReceived <= sm1.endDateRequestReceived);
                }
                if ((sm1.DateRequestReceived != null) && (sm1.endDateRequestReceived == null))
                {
                    query1 = query1.Where(e => e.DateRequestReceived.Equals(sm1.DateRequestReceived));
                }
                if (sm1.TFToday > 0)
                {
                    if(sm1.TFoption == "Greater Than")
                    {
                        query1 = query1.Where(g => g.TFToday >= sm1.TFToday);
                    } else if (sm1.TFoption == "Less Than")
                    {
                        query1 = query1.Where(g => g.TFToday <= sm1.TFToday);
                    } else
                    {
                        query1 = query1.Where(g => g.TFToday == sm1.TFToday);
                    }
                }


                if (sm1.Amount != null)
                {
                    decimal tdex = ParseCurr(sm1.Amount);
                    if (tdex > 0)
                    {
                        if (sm1.amOption == "Greater Than")
                        {
                            query1 = query1.Where(g => ParseCurr(g.Amount) >= tdex);
                        }
                        else if (sm1.amOption == "Less Than")
                        {
                            query1 = query1.Where(g => ParseCurr(g.Amount) <= tdex);
                        }
                        else
                        {
                            query1 = query1.Where(g => ParseCurr(g.Amount) == tdex);
                        }
                    }

                }


                if (sm1.CreatedBy != null)
                {
                    //string username = drcRepo.getUserName(sm1.CreatedBy);
                    query1 = query1.Where(e => e.CreatedBy == sm1.CreatedBy.ToString());
                }
                if (sm1.UpdatedBy != null)
                {
                    //string username = drcRepo.getUserName(sm1.UpdatedBy);
                    query1 = query1.Where(e => e.UpdatedBy == sm1.UpdatedBy.ToString());
                }
                if (sm1.Notes != null)
                {
                    query1 = query1.Where(e => e.Notes == sm1.Notes);
                }
                if (sm1.Description != null)
                {
                    query1 = query1.Where(e => e.Description.Contains(sm1.Description));// || e.Description.EndsWith("sit"));
                    //query1 = query1.Where(e => e.Description == "sit");
                }
                if (sm1.Comments != null)
                {
                    query1 = query1.Where(e => e.Comments.Contains(sm1.Comments));
                }
                if (sm1.deleted == true)
                {
                    query1 = query1.Where(n => n.deleted == true);
                } else
                {
                    query1 = query1.Where(n => n.deleted.Equals(false));
                }
                sResults = query1.ToList();
                //RequestViewModel temp = new RequestViewModel(query1);
                ViewBag.Header = "Search Results";
                return View("searchresults", sResults);
            }
             else
            {
                return View();
            }
        }
        
        public ActionResult Results(IQueryable<tDRCRequest> rm)
        {
            List<tDRCRequest> sResults = new List<tDRCRequest>();
            sResults = rm.ToList();
            return View(sResults);
        }
        [HttpPost]
        public ActionResult QuickSearch (string qSearch)
        {
            List<tDRCRequest> sResults = new List<tDRCRequest>();
           // var query = dc.tDRCRequests;
            IQueryable<tDRCRequest> query1 = drcRepo.allReq().Where(x => x.deleted == false).AsQueryable();
            query1 = query1.Where(b => b.CaseID.Contains(qSearch)).Where(n => n.deleted.Equals(false));
            sResults = query1.ToList();
            //return View("searchresults", sResults);
            ViewBag.Header = "Search Results";
            return View(sResults);

        }
       /* public ActionResult Searchresults(List<tDRCRequest> tesrr)
        {
            List<tDRCRequest> sResults = new List<tDRCRequest>();
            //var query = dc.tDRCRequests;
            IQueryable<tDRCRequest> query1 = query.Where(u => u.OA == "FTA");
            query1 = query1.Where(b => b.EmployeeLastName == "Marks");
            //sResults = dc.tDRCRequests.Where(u => u.OA == "FTA").ToList();
            sResults = query1.ToList();
            return View(tesrr);
        }*/

        public ActionResult Edit(int id)
        {
  
            List<rSource> source = new List<rSource>()
            {
                new rSource {requestType = "Employee" },
                new rSource {requestType = "Applicant" }
            };
           /* List<prStat> pur = new List<prStat>()
            {
                new prStat {id= 0, Purchasing = "None" },
                new prStat {id= 1, Purchasing = "CAP" },
                new prStat {id= 2, Purchasing = "PR" }
            };*/
            List<PurchasingCode> pur = new List<PurchasingCode>();
            pur = drcRepo.purch();
            tDRCRequest rTest = new tDRCRequest(); 
             rTest = drcRepo.getRequest(id);
            int cl = drcRepo.getCaseLength(rTest.CaseID);
            rTest.TFToday = cl;
            //List<tDRCRequest> rTest = new List<tDRCRequest>();
            //rTest = drcRepo.getRequestList(id);
            List<UserAccountsResult> drcUsers = new List<UserAccountsResult>();
            drcUsers = drcRepo.DRCAnaylist();
            RequestViewModel rqvm = new RequestViewModel();
            ViewBag.CreateUpdate = "Save Request";
            ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
            //ViewBag.Analyst = new SelectList(drcRepo.anaylistTemp(), "ANALYSTCODES", "ANALYSTCODES");
            ViewBag.Analyst = new SelectList(drcRepo.DRCAnaylist(), "Id", "Name");
            ViewBag.drcReq = new SelectList(drcRepo.DRCRequestType(), "RequestTypeCodes", "RequestTypeCodes");
            ViewBag.dSource = new SelectList(source, "requestType", "requestType");
            ViewBag.purch = new SelectList(pur, "Purchasing", "Purchasing");
            
            ViewBag.gsgrade = new SelectList(drcRepo.getGrades(), "Grade", "Grade");
            ViewBag.MD715 = new SelectList(drcRepo.rMD715(), "ID", "MD715Codes");
            ViewBag.eMD715 = new SelectList(drcRepo.aMD715(), "ID", "MD715Codes");
            ViewBag.dCodes = new SelectList(drcRepo.Disability(), "DISABCODES", "DISABCODES");
            ViewBag.nCodes = new SelectList(drcRepo.notes(), "NOTECODES", "NOTECODES");
                //rqvm.EmployeeFirstName = "test";
                //rqvm.DateCompleted = new DateTime(2017, 5, 30);
                //rqvm.DRCStatus = "Fulfilled";


                //rTest.ElementAt(0).UpdatedBy = User.Identity.Name;
                // rTest.EndMD715 = new SelectList(drcRepo.rMD715(), "ID", "Name");
                if (rTest == null)
                    return View("NotFound");
                else
                    rTest.UpdatedBy = User.Identity.Name;
                return View(new RequestViewModel(rTest));
            
            
            //return View(rTest);
        }
        [HttpPost]
        public ActionResult Edit(int id, RequestViewModel rvmSubModel)
        {
            bool assigned;
            if (rvmSubModel.EmployeeLastName == "Tews")
            {
                assigned = true;
            }
            else
            {
                assigned = drcRepo.isAssigned(id);
            }
            tDRCRequest rTest = drcRepo.getRequest(id);
            if (rTest.OA != rvmSubModel.OA)
            {

                string nCaseID = rvmSubModel.CaseID.Substring(0, 11);
                rvmSubModel.CaseID = nCaseID + rvmSubModel.OA;
            }
            List<rSource> source = new List<rSource>()
            {
                new rSource {requestType = "Employee" },
                new rSource {requestType = "Applicant" }
            };
            /* List<prStat> pur = new List<prStat>()
             {
                 new prStat {id= 0, Purchasing = "None" },
                 new prStat {id= 1, Purchasing = "CAP" },
                 new prStat {id= 2, Purchasing = "PR" }
             };*/
            int cl = drcRepo.getCaseLength(rTest.CaseID);
            rTest.TFToday = cl;
            List<PurchasingCode> pur = new List<PurchasingCode>();
            pur = drcRepo.purch();
            //RequestViewModel rvmSubModel = new RequestViewModel();
            //rvmSubModel =  new RequestViewModel(rTest);
            QACheck(rvmSubModel);
            if (ModelState.IsValid)
            {

                //var nRequest = new tDRCRequest();
                //rvmSubModel.CreatedBy = User.Identity.Name;
                rvmSubModel.UpdatedBy = User.Identity.Name;
                rvmSubModel.UpdatedDate = DateTime.Now ;
                DateTime? opd = drcRepo.openDate(id);
                if (opd == null)
                {
                    if ((assigned == false) && (rvmSubModel.AnalystAssigned != null))
                    {
                        rvmSubModel.assignedopenDate = DateTime.Now.Date;
                    }
                   /* else if (rvmSubModel.AnalystAssigned != null)
                    {
                        rvmSubModel.assignedopenDate = rvmSubModel.DateRequestReceived;
                    }*/
                }
                //rvmSubModel.deleted = true;
                rTest = new RequestViewModel(rvmSubModel);
                Random r = new Random();
                int num = r.Next(1, 999);
                string eid = "";
                bool ommNA = drcRepo.empNAExists("N/A", rvmSubModel.EmployeeFirstName, rvmSubModel.EmployeeLastName);
                if (ommNA == true)
                {
                    eid = drcRepo.empNAID("N/A", rvmSubModel.EmployeeFirstName, rvmSubModel.EmployeeLastName);
                    if (rvmSubModel.EmployeeEmail != "N/A")
                    {
                        drcRepo.upEmp(eid, rvmSubModel.EmployeeFirstName, rvmSubModel.EmployeeLastName, rvmSubModel.EmployeeEmail);
                    }

                }
                else
                {
                    eid = drcRepo.empID(rvmSubModel.EmployeeEmail);
                    Employee upEmp =  drcRepo.getEMP(eid.ToString());
                    if ((upEmp.EmployeeFirstName != rvmSubModel.EmployeeFirstName) || (upEmp.EmployeeLastName != rvmSubModel.EmployeeLastName)) {
                        drcRepo.upEmp(eid, rvmSubModel.EmployeeFirstName, rvmSubModel.EmployeeLastName, rvmSubModel.EmployeeEmail);
                    }
                }
                if (eid.Length < 8)
                {

                    
                   
                        int etemp = Int32.Parse(eid.ToString());
                        int dlen = 6 - etemp.ToString().Length;
                       string  empID = "EID" + etemp.ToString("D5");
                    if (rvmSubModel.EmployeeEmail != null)
                    {
                        drcRepo.addEmp(empID, rvmSubModel.EmployeeFirstName, rvmSubModel.EmployeeLastName, rvmSubModel.EmployeeEmail);
                    }
                    
                        //empID = eid.ToString();
                   
                    rvmSubModel.EmployeeID = empID.ToString();
                } 


                //drcRepo.addEmp(rTest.EmployeeID, rTest.EmployeeFirstName, rTest.EmployeeLastName, rTest.EmployeeEmail);
               // UpdateModel(rTest);
                /* nRequest.OA = rvmSubModel.OA;
                 nRequest.AnalystAssigned = rvmSubModel.AnalystAssigned;
                 nRequest.CaseID = rvmSubModel.CaseID; //Need to come up with format I.E. 2015OST1
                 nRequest.Comments = rvmSubModel.Comments;
                 nRequest.COWADate = rvmSubModel.COWADate;
                nRequest.DateCompleted = rvmSubModel.DateCompleted;
                nRequest.Source = rvmSubModel.Source;
                */

                //drcRepo.addRequest(nRequest);
                //drcRepo.addRequest(rvmSubModel);
                drcRepo.UpdateRequest(rvmSubModel, id);

                try
                {
                    drcRepo.Save();
                    if ((assigned == false) && (rvmSubModel.AnalystAssigned != null))
                    {
                        assignEmail(rvmSubModel.AnalystAssigned, rvmSubModel.CaseID);
                    };
                }
            catch (Exception ex)
            {
                logger.Error(ex, "ter");
                //logger.ErrorException("Error occured in Home controller Index Action", ex);

            }
            return RedirectToAction("Index");
            }
            else
            {
                // tDRCRequest rqvm = new tDRCRequest();
                RequestViewModel rqvm = new RequestViewModel();
                ViewBag.CreateUpdate = "Save Request";
                ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
                //ViewBag.Analyst = new SelectList(drcRepo.anaylistTemp(), "ANALYSTCODES", "ANALYSTCODES");
                ViewBag.Analyst = new SelectList(drcRepo.DRCAnaylist(), "Id", "Name");
                ViewBag.drcReq = new SelectList(drcRepo.DRCRequestType(), "RequestTypeCodes", "RequestTypeCodes");
                ViewBag.dSource = new SelectList(source, "requestType", "requestType");
                ViewBag.purch = new SelectList(pur, "Purchasing", "Purchasing");
                ViewBag.gsgrade = new SelectList(drcRepo.getGrades(), "Grade", "Grade");
                ViewBag.MD715 = new SelectList(drcRepo.rMD715(), "ID", "MD715Codes");
                ViewBag.eMD715 = new SelectList(drcRepo.aMD715(), "ID", "MD715Codes");
                ViewBag.dCodes = new SelectList(drcRepo.Disability(), "DISABCODES", "DISABCODES");
                ViewBag.nCodes = new SelectList(drcRepo.notes(), "NOTECODES", "NOTECODES");
                rqvm.EmployeeFirstName = "Error";
               
                return View(rqvm);
            }
        }
        public ActionResult ReportsTest()
        {
            var repo = new FakeRepository<tDRCRequest>();
            //repo.Save();
            return View(repo.GetAll());
        }


    }




    }
