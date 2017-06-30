using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRCTS.Models;
using System.Web.Security;

namespace DRCTS.Controllers
{
    public class DRCController : Controller
    {
        drctsRepository drcRepo = new drctsRepository();
        // GET: DRC
        [Authorize]
        public ActionResult Index()
        {
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
        //Authorize later [Authorize]
        public ActionResult AddRequest()
        {
            // tDRCRequest rqvm = new tDRCRequest();
            RequestViewModel rqvm = new RequestViewModel();
            ViewBag.OACodes = new SelectList(drcRepo.code1(), "OA_CODES", "OA_CODES");
            rqvm.EmployeeFirstName = "test";
            return View(rqvm);
        }
        [HttpPost]
        public ActionResult AddRequest(RequestViewModel rvmSubModel)
        {
            if (ModelState.IsValid)
            {
                 var nRequest = new tDRCRequest();
                 nRequest.OA = rvmSubModel.OA;
                 nRequest.AnalystAssigned = rvmSubModel.AnalystAssigned;
                 nRequest.CaseID = rvmSubModel.CaseID; //Need to come up with format I.E. 2015OST1
                 nRequest.Comments = rvmSubModel.Comments;
                 nRequest.COWADate = rvmSubModel.COWADate;
                nRequest.DateCompleted = rvmSubModel.DateCompleted;


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
    }
    }
