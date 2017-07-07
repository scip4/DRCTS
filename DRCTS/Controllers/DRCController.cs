using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRCTS.Models;
using System.Web.Security;
using M.Radwan.DevMagicFake.FakeRepositories;

namespace DRCTS.Controllers
{
    public class DRCController : Controller
    {
        drctsRepository drcRepo = new drctsRepository();
        
        // GET: DRC
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.User = User.Identity.Name;


            return View();
        }
        public ActionResult Index2()
        {
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
        public PartialViewResult ServiceReport()
        {
            List<ServiceReportResult> svr = new List<ServiceReportResult>();
            svr = drcRepo.rptService();
            return PartialView(svr);
        }

        public ActionResult SummaryReport()
        {
            return View();
        }

        //Authorize later [Authorize]
        public ActionResult AddRequest()
        {
            // tDRCRequest rqvm = new tDRCRequest();

            List<rSource> source = new List<rSource>()
            {
                new rSource {requestType = "Employee" },
                new rSource {requestType = "Applicant" }
            };
            List<UserAccountsResult> drcUsers = new List<UserAccountsResult>();
            drcUsers = drcRepo.DRCAnaylist();
            RequestViewModel rqvm = new RequestViewModel();
            ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
            //ViewBag.Analyst = new SelectList(drcRepo.anaylistTemp(), "ANALYSTCODES", "ANALYSTCODES");
            ViewBag.Analyst = new SelectList(drcRepo.DRCAnaylist(), "Name", "Name");
            ViewBag.drcReq = new SelectList(drcRepo.DRCRequestType(), "RequestTypeCodes", "RequestTypeCodes");
            ViewBag.dSource = new SelectList(source, "requestType", "requestType");
            ViewBag.MD715 = new SelectList(drcRepo.rMD715(), "MD715Codes", "MD715Codes");
            ViewBag.dCodes = new SelectList(drcRepo.Disability(), "DISABCODES", "DISABCODES");
            ViewBag.nCodes = new SelectList(drcRepo.notes(), "NOTECODES", "NOTECODES");
            rqvm.EmployeeFirstName = "test";
            rqvm.DateCompleted = new DateTime(2017, 5, 30);
            rqvm.DRCStatus = "Fulfilled";
            rqvm.CreatedBy = User.Identity.Name;
            return View(rqvm);
        }
        [HttpPost]
        public ActionResult AddRequest(RequestViewModel rvmSubModel)
        {
            List<rSource> source = new List<rSource>()
            {
                new rSource {requestType = "Employee" },
                new rSource {requestType = "Applicant" }
            };

           
            ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
            //ViewBag.Analyst = new SelectList(drcRepo.anaylistTemp(), "ANALYSTCODES", "ANALYSTCODES");
            ViewBag.Analyst = new SelectList(drcRepo.DRCAnaylist(), "Name", "Name");

            ViewBag.dSource = new SelectList(source, "requestType", "requestType");
            ViewBag.MD715 = new SelectList(drcRepo.rMD715(), "RequestTypeCodes", "RequestTypeCodes");
            ViewBag.dCodes = new SelectList(drcRepo.Disability(), "DISABCODES", "DISABCODES");
            ViewBag.nCodes = new SelectList(drcRepo.notes(), "NOTECODES", "NOTECODES");
            if (ModelState.IsValid)
            {
                 var nRequest = new tDRCRequest();
                rvmSubModel.CreatedBy = User.Identity.Name;
                rvmSubModel.UpdatedBy = User.Identity.Name;
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
                drcRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                // tDRCRequest rqvm = new tDRCRequest();
                RequestViewModel rqvm = new RequestViewModel();
                ViewBag.OACodes = new SelectList(drcRepo.code1(), "ID", "OA_CODES");
                rqvm.EmployeeFirstName = "Error";
                return View(rqvm);
            }
        }



        public ActionResult Edit(int id)
        {
            List<rSource> source = new List<rSource>()
            {
                new rSource {requestType = "Employee" },
                new rSource {requestType = "Applicant" }
            };
            tDRCRequest rTest = drcRepo.getRequest(id);
            List<UserAccountsResult> drcUsers = new List<UserAccountsResult>();
            drcUsers = drcRepo.DRCAnaylist();
            RequestViewModel rqvm = new RequestViewModel();
            ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
            //ViewBag.Analyst = new SelectList(drcRepo.anaylistTemp(), "ANALYSTCODES", "ANALYSTCODES");
            ViewBag.Analyst = new SelectList(drcRepo.DRCAnaylist(), "Name", "Name");
            ViewBag.drcReq = new SelectList(drcRepo.DRCRequestType(), "RequestTypeCodes", "RequestTypeCodes");
            ViewBag.dSource = new SelectList(source, "requestType", "requestType");
            ViewBag.MD715 = new SelectList(drcRepo.rMD715(), "MD715Codes", "MD715Codes");
            ViewBag.dCodes = new SelectList(drcRepo.Disability(), "DISABCODES", "DISABCODES");
            ViewBag.nCodes = new SelectList(drcRepo.notes(), "NOTECODES", "NOTECODES");
            //rqvm.EmployeeFirstName = "test";
            //rqvm.DateCompleted = new DateTime(2017, 5, 30);
            //rqvm.DRCStatus = "Fulfilled";
            rTest.UpdatedBy = User.Identity.Name;
            return View(new RequestViewModel(rTest));
        }
        [HttpPost]
        public ActionResult Edit(int id, RequestViewModel rvmSubModel)
        {
            tDRCRequest rTest = drcRepo.getRequest(id);

            //RequestViewModel rvmSubModel = new RequestViewModel();
            //rvmSubModel =  new RequestViewModel(rTest);
            if (ModelState.IsValid)
            {
                //var nRequest = new tDRCRequest();
                //rvmSubModel.CreatedBy = User.Identity.Name;
                rvmSubModel.UpdatedBy = User.Identity.Name;
                rTest = new RequestViewModel(rvmSubModel);

                UpdateModel(rTest);
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
                drcRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                // tDRCRequest rqvm = new tDRCRequest();
                RequestViewModel rqvm = new RequestViewModel();
                ViewBag.OACodes = new SelectList(drcRepo.code1(), "ID", "OA_CODES");
                rqvm.EmployeeFirstName = "Error";
                return View(rqvm);
            }
        }
        public ActionResult ReportsTest()
        {
            var repo = new FakeRepository<tDRCRequest>();

            return View(repo.GetAll());
        }


    }




    }
