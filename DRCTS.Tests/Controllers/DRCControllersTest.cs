using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M.Radwan.DevMagicFake.FakeRepositories;
using DRCTS.Models;
using DRCTS.Controllers;
using System.Web.Mvc;
using Faker;
using System.Collections.Generic;
using DRCTS.Tests.Fakes;
using System.Linq;
using Moq;

namespace DRCTS.Tests.Controllers
{
    [TestClass]
    public class DRCControllersTest
    {

        List<tDRCRequest> testData;
        List<UserAccountsResult> analyst;
        List<ResultsResult> searchData;


        List<DisbCode> CreateDisTest()
        {
            List<DisbCode> Disa = new List<DisbCode>()
            {
                new DisbCode {ID=1, DISABCODES="Cognaticve" },
                new DisbCode {ID=2, DISABCODES="Communication" },
                new DisbCode {ID=3, DISABCODES="Dexterity" },
                new DisbCode {ID= 4, DISABCODES="General" },
                new DisbCode {ID=5, DISABCODES="Hearing" },
                new DisbCode {ID=6, DISABCODES="Hidden" },
                new DisbCode {ID=7, DISABCODES="Mobility"},
                new DisbCode {ID=8, DISABCODES="Other" },
                new DisbCode {ID=9, DISABCODES="Unknown" },
                new DisbCode {ID=9, DISABCODES="Vision" }

            };
            return Disa;
        }
        List<NOTECODE> CreateNoteTest()
        {
            List<NOTECODE> note = new List<NOTECODE>()
            {
                new NOTECODE {ID=1, NOTECODES="No response from employee" },
                new NOTECODE {ID=2, NOTECODES="No Response from supervisor" },
                new NOTECODE {ID=3, NOTECODES="Waiting for disability determination" },
                new NOTECODE {ID=4, NOTECODES="Arranging RA meeting" },
                new NOTECODE {ID=5, NOTECODES="Obtaining Product/Services" },
                new NOTECODE {ID=6, NOTECODES="Waiting for completion of training" },
                new NOTECODE {ID=7, NOTECODES="OA Provided" },
                new NOTECODE {ID=8, NOTECODES="Withdrawn by Employee" },
                new NOTECODE {ID=9, NOTECODES="Other" }
            };
            return note;
        }
        List<GradeCode> CreateGradeTest()
        {
            List<GradeCode> gs1 = new List<GradeCode>()
            {
                new GradeCode {ID=1, Grade="GS-1" },
                 new GradeCode {ID=2, Grade="GS-2" },
                  new GradeCode {ID=3, Grade="GS-3" },
                   new GradeCode {ID=4, Grade="GS-4" },
                    new GradeCode {ID=5, Grade="GS-5" }
            };
            return gs1;
        }
        List<MD715Code> CreateMD715Test()
        {
            List<MD715Code> md = new List<MD715Code>()
            {

            new MD715Code {ID= 1, MD715Codes="AT" },
             new MD715Code {ID= 2, MD715Codes="CapTel" },
                 new MD715Code {ID= 3, MD715Codes="CART" },
                 new MD715Code {ID= 4, MD715Codes="Chair" },
                 new MD715Code {ID= 5, MD715Codes="Ergonomics" },
                 new MD715Code {ID= 6, MD715Codes="Interpreting" },
                 new MD715Code {ID= 7, MD715Codes="Note Taking" },
                 new MD715Code {ID= 8, MD715Codes="Other" },
                 new MD715Code {ID= 9, MD715Codes="PAS" }
            };
            return md;
        }
        List<ResultsResult> CreateSearch()
        {
            List<UserAccountsResult> analyst = CreateUsersTest();
            List<OACode> os = CreateOATest();
            List<RTCode> rc = CreateReqType();
            List<MD715Code> md7 = CreateMD715Test();
            List<AMD715Code> amd7 = CreateAMD715Test();
            List<NOTECODE> notes = CreateNoteTest();
            List<DisbCode> dis = CreateDisTest();
            List<ResultsResult> trequest = new List<ResultsResult>();
            for (int i = 0; i < 101; i++)
            {
               
                Random r = new Random();
                int num = r.Next(1, 9);
                ResultsResult sampleRequest = new ResultsResult()
                {
                    AnalystAssigned = analyst.ElementAt(num).Id,
                    OA = os.ElementAt(num).OA_CODES,
                    CaseID = "2017-" + i + os.ElementAt(num).OA_CODES.ToString(),
                    CreatedBy = "Moore",
                    DRCRequestType = rc.ElementAt(num).RequestTypeCodes,
                    DateRequestReceived = DateTime.Now.AddDays(i),
                    Disability = dis.ElementAt(num).DISABCODES,
                    RequestedMD715 = num.ToString(),
                    EndMD715 = num.ToString(),
                    Notes = notes.ElementAt(num).NOTECODES,
                    EmployeeFirstName = Faker.Name.First(),
                    EmployeeLastName = Faker.Name.Last(),
                    EmployeeEmail = Faker.Internet.Email(),
                    SupervisorEmail = Faker.Internet.Email(),
                    Description = Faker.Lorem.Paragraph(),
                    Comments = Faker.Lorem.Paragraph(),
                    UpdatedBy = "SomeUser1",
                    ID = i,
                    TFToday = 0,
                    deleted = false,
                    Source = "Employee"



                };
                trequest.Add(sampleRequest);
            }
            return trequest;
        }
        List<AMD715Code> CreateAMD715Test()
        {
            List<AMD715Code> md = new List<AMD715Code>()
            {
               
            new AMD715Code {ID= 1, MD715Codes="AT" },
             new AMD715Code {ID= 2, MD715Codes="CapTel" },
                 new AMD715Code {ID= 3, MD715Codes="CART" },
                 new AMD715Code {ID= 4, MD715Codes="Chair" },
                 new AMD715Code {ID= 5, MD715Codes="Ergonomics" },
                 new AMD715Code {ID= 6, MD715Codes="Interpreting" },
                 new AMD715Code {ID= 7, MD715Codes="Note Taking" },
                 new AMD715Code {ID= 8, MD715Codes="Other" },
                 new AMD715Code {ID= 9, MD715Codes="PAS" }
            };
            return md;
        }
        List<RTCode> CreateReqType()
        {
            List<RTCode> rt = new List<RTCode>()
            {
                new RTCode {ID= 1, RequestTypeCodes= "RA" },
                new RTCode {ID=2, RequestTypeCodes="TA" },
                new RTCode {ID=3, RequestTypeCodes="Invitational Travel" },
                 new RTCode {ID=4, RequestTypeCodes="PA Travel" },
                 new RTCode {ID=5, RequestTypeCodes="Meeting" },
                 new RTCode {ID=6, RequestTypeCodes="Presentation" },
                 new RTCode {ID=7, RequestTypeCodes="Work Group" },
                 new RTCode {ID=8, RequestTypeCodes="Other" },
                 new RTCode {ID=9, RequestTypeCodes="Test" }
        };
            return rt;
        }
        List<OACode> CreateOATest()
        {
            List<OACode> OA = new List<OACode>()
            {
                new OACode { ID=1, OA_CODES="FAA" },
                new OACode { ID=2, OA_CODES="FHWA" },
                new OACode { ID=3, OA_CODES="FTA" },
                new OACode { ID=4, OA_CODES="FMCSA" },
                new OACode { ID=5, OA_CODES="RITA" },
                new OACode { ID=6, OA_CODES="OST" },
                new OACode { ID=7, OA_CODES="OIG" },
                new OACode { ID=8, OA_CODES="MARAD" },
                new OACode { ID=9, OA_CODES="FRA" }

            };
            return OA;
        }
        List<UserAccountsResult> CreateUsersTest()
        {
            List<UserAccountsResult> gap = new List<UserAccountsResult>()
            {
                new UserAccountsResult { Id="1", Name= Faker.Name.Last() },
                new UserAccountsResult { Id="2", Name= Faker.Name.Last() },
                new UserAccountsResult { Id="3", Name= Faker.Name.Last() },
                new UserAccountsResult { Id="4", Name= Faker.Name.Last() },
                new UserAccountsResult { Id="5", Name= Faker.Name.Last() },
                new UserAccountsResult { Id="6", Name= Faker.Name.Last() },
                new UserAccountsResult { Id="7", Name= Faker.Name.Last() },
                new UserAccountsResult { Id="8", Name= Faker.Name.Last() },
                new UserAccountsResult { Id="9", Name= Faker.Name.Last() },
            };
            return gap;
        }
        List<tDRCRequest> CreateRequestTest()
        {
            List<UserAccountsResult> analyst = CreateUsersTest();
            List<OACode> os = CreateOATest();
            List<RTCode> rc = CreateReqType();
            List<MD715Code> md7 = CreateMD715Test();
            List<AMD715Code> amd7 = CreateAMD715Test();
            List<NOTECODE> notes = CreateNoteTest();
            List<DisbCode> dis = CreateDisTest();
           // IQueryable test = .AsQueryable(); 
            List<tDRCRequest> trequest = new List<tDRCRequest>();
            for (int i = 0; i <101; i++)
            {
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
                Random r = new Random();
                int num = r.Next(1, 9);
                tDRCRequest sampleRequest = new tDRCRequest()
                {
                    AnalystAssigned = analyst.ElementAt(num).Id,
                    OA = os.ElementAt(num).OA_CODES,
                    CaseID = "2017-" + i + os.ElementAt(num).OA_CODES.ToString(),
                    CreatedBy = "Moore",
                    DRCRequestType = rc.ElementAt(num).RequestTypeCodes,
                    DateRequestReceived = DateTime.Now.AddDays(i),
                    Disability = dis.ElementAt(num).DISABCODES,
                    RequestedMD715 = num.ToString(),
                    EndMD715 = num.ToString(),
                    Notes = notes.ElementAt(num).NOTECODES,
                    EmployeeFirstName = Faker.Name.First(),
                    EmployeeLastName = Faker.Name.Last(),
                    EmployeeEmail = Faker.Internet.Email(),
                    SupervisorEmail = Faker.Internet.Email(),
                    Description = Faker.Lorem.Paragraph(),
                    Comments = Faker.Lorem.Paragraph(),
                    UpdatedBy = "SomeUser1",
                    ID = i,
                    TFToday = 0,
                    deleted = false,
                    Source = "Employee"



            };
                trequest.Add(sampleRequest);
            }
            return trequest;
        }
        DRCController CreateDRCControllerAs(string userName, List<tDRCRequest> nData)
        {

            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(userName);
            mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var controller = CreateDRCController(nData);
            controller.ControllerContext = mock.Object;

            return controller;
        }
        DRCController CreateDRCController(List<tDRCRequest> nData)
        {
            List<ResultsResult> temp = new List<ResultsResult>();
            var repo = new FakedrctsRepo(nData, CreateUsersTest(), CreateOATest(), CreateReqType(), CreateMD715Test(), CreateAMD715Test(), CreateDisTest(), CreateNoteTest(), CreateGradeTest(), temp );
            return new DRCController(repo);
        }
        DRCController CreateDRCControllerS(string userName, List<tDRCRequest> nData, List<ResultsResult> sData)
        {
            var repo = new FakedrctsRepo(nData, CreateUsersTest(), CreateOATest(), CreateReqType(), CreateMD715Test(), CreateAMD715Test(), CreateDisTest(), CreateNoteTest(), CreateGradeTest(), sData);
            return new DRCController(repo);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            testData = CreateRequestTest();
            analyst = CreateUsersTest();
            searchData = CreateSearch();
        }


        [TestMethod]
        public void DetailsView1EditAction_Should_Return_View_For_Valid()
        {
            var controller = CreateDRCControllerAs("SomeUser", testData);
            var result = controller.Edit(1) as ViewResult;
            
            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(RequestViewModel));
        }

        [TestMethod]
        public void DetailsAction_Should_Return_NotFoundView()
        {
            //List<tDRCRequest> testData = CreateRequestTest();
            // Arrange
            var controller = CreateDRCControllerAs("SomeUser", testData);

            // Act
            var result = controller.Edit(999) as ViewResult;

            // Assert
            Assert.AreEqual("NotFound", result.ViewName);
        }

        [TestMethod]
        public void AddRequestAction_Should_Return_View()
        {
            //List<tDRCRequest> testData = CreateRequestTest();
            // Arrange
            var controller = CreateDRCControllerAs("SomeUser", testData);

            // Act
            var result = controller.Add_Request() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(RequestViewModel));
        }
        [TestMethod]
        public void AddRequestAction_No_Analyst_Should_Redirect_When_Update_Successful()
        {

            // Arrange     
            var controller = CreateDRCControllerAs("SomeUser", testData);
            // List<tDRCRequest> testData = CreateRequestTest();
            //List<tDRCRequest> updateData = testData;
            //updateData.ElementAt(1).EmployeeLastName = "Test";
            var formValues = new RequestViewModel();
            //formValues.AnalystAssigned = analyst.ElementAt(2).Id;
            formValues.OA = CreateOATest().ElementAt(2).OA_CODES;
            //CaseID = "2017-" + i + os.ElementAt(num).OA_CODES.ToString(),
            //formValues.CreatedBy = "Moore";
            formValues.DRCRequestType = CreateReqType().ElementAt(2).RequestTypeCodes;
            formValues.DateRequestReceived = DateTime.Now;
            formValues.Disability = CreateDisTest().ElementAt(4).DISABCODES;
            formValues.RequestedMD715 = "5";
            formValues.EndMD715 = "5";
            formValues.Notes = CreateNoteTest().ElementAt(4).NOTECODES;
            formValues.EmployeeFirstName =  Faker.Name.First();
            formValues.EmployeeLastName = Faker.Name.Last();
            formValues.EmployeeEmail = Faker.Internet.Email();
            formValues.Description = Faker.Lorem.Paragraph();
            formValues.Comments = Faker.Lorem.Paragraph();
            //UpdatedBy = "SomeUser1",
            //ID = i,
            //TFToday = 0,
            //deleted = false,
            formValues.Source = "Employee";

            //controller.ValueProvider = formValues;
            controller.ViewData.ModelState.Clear();
            // Act
            var result = controller.Add_Request(formValues) as RedirectToRouteResult;
            //var test = testData.ElementAt(1).EmployeeLastName;
            //var test2 = formValues.EmployeeLastName;
            // Assert
            var ttt = controller.ViewData.ModelState.Count;
            //Assert.AreEqual(test, test2);
            //Assert.IsTrue(controller.ViewData.ModelState["FirstName"].Errors.Count > 0);
               Assert.AreEqual("Index", result.RouteValues["Action"]);
        }
        [TestMethod]
        public void AddRequestAction_Should_Fail_on_Update()
        {

            // Arrange     
            var controller = CreateDRCControllerAs("SomeUser", testData);
            // List<tDRCRequest> testData = CreateRequestTest();
            //List<tDRCRequest> updateData = testData;
            //updateData.ElementAt(1).EmployeeLastName = "Test";
            var formValues = new RequestViewModel();
            formValues.AnalystAssigned = analyst.ElementAt(2).Id;
            formValues.OA = CreateOATest().ElementAt(2).OA_CODES;
            //CaseID = "2017-" + i + os.ElementAt(num).OA_CODES.ToString(),
            //formValues.CreatedBy = "Moore";
            formValues.DRCRequestType = CreateReqType().ElementAt(2).RequestTypeCodes;
            formValues.DateRequestReceived = DateTime.Now;
            formValues.Disability = CreateDisTest().ElementAt(4).DISABCODES;
            formValues.RequestedMD715 = "5";
            formValues.EndMD715 = "5";
            formValues.Notes = CreateNoteTest().ElementAt(4).NOTECODES;
            formValues.EmployeeFirstName = " ExtraSpace"; //Faker.Name.First();
            formValues.EmployeeLastName = Faker.Name.Last();
            formValues.EmployeeEmail = Faker.Internet.Email();
            formValues.Description = Faker.Lorem.Paragraph();
            formValues.Comments = Faker.Lorem.Paragraph();
            //UpdatedBy = "SomeUser1",
            //ID = i,
            //TFToday = 0,
            //deleted = false,
            formValues.Source = "Employee";

            //controller.ValueProvider = formValues;
            controller.ViewData.ModelState.Clear();
            // Act
            var result = controller.Add_Request(formValues) as RedirectToRouteResult;
            //var test = testData.ElementAt(1).EmployeeLastName;
            //var test2 = formValues.EmployeeLastName;
            // Assert
           // var ttt = controller.ViewData.ModelState.Count;
            //Assert.AreEqual(test, test2);
            Assert.IsTrue(controller.ViewData.ModelState.Count > 0);
            //Assert.AreEqual("Index", result.RouteValues["Action"]);
        }
        [TestMethod]
        public void SearchFormAction_Should_Return_View()
        {
            //List<tDRCRequest> testData = CreateRequestTest();
            // Arrange
            var controller = CreateDRCControllerAs("SomeUser", testData);

            // Act
            var result = controller.SearchForm() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(searchModel));
        }
        [TestMethod]
        public void SearchTest_ByOA()
        {
            var controller = CreateDRCControllerS("SomeUser", testData, searchData);
            var sTotal = searchData.Where(x => x.OA == "FRA").Count();
            var formValues = new searchModel();
            formValues.OA = "FRA";
            var result = controller.SearchForm(formValues); //as RedirectToRouteResult;
            var model = ((ViewResult)result).Model as List<ResultsResult>;
            //var sTotal = model.Count;
            Assert.IsNotNull(model, "model is not of type List<ResultsResult>");
            Assert.AreEqual(model.Count, sTotal);

        }
        [TestMethod]
        public void SearchTest_CreatedBy()
        {
            var controller = CreateDRCControllerS("SomeUser", testData, searchData);
            var sTotal = searchData.Where(x => x.CreatedBy == searchData.ElementAt(5).CreatedBy).Count();
            var formValues = new searchModel();
            formValues.CreatedBy = "Moore";
            var result = controller.SearchForm(formValues); //as RedirectToRouteResult;
            var model = ((ViewResult)result).Model as List<ResultsResult>;
            //var sTotal = model.Count;
            Assert.IsNotNull(model, "model is not of type List<ResultsResult>");
            Assert.AreEqual(model.Count, sTotal);

        }


        [TestMethod]
        public void SearchTest_RequestDate()
        {
            var controller = CreateDRCControllerS("SomeUser", testData, searchData);
           // Where(e => e.DateRequestReceived >= sm1.DateRequestReceived).Where(e => e.DateRequestReceived <= sm1.endDateRequestReceived);
            var sTotal = searchData.Where(x => x.DateRequestReceived >= DateTime.Now).Where(e => e.DateRequestReceived <= DateTime.Now.AddDays(5)).Count();
            var formValues = new searchModel();
            formValues.DateRequestReceived = DateTime.Now;
            formValues.endDateRequestReceived = DateTime.Now.AddDays(5);
            var result = controller.SearchForm(formValues); //as RedirectToRouteResult;
            var model = ((ViewResult)result).Model as List<ResultsResult>;
            //var sTotal = model.Count;
            Assert.IsNotNull(model, "model is not of type List<ResultsResult>");
            Assert.AreEqual(model.Count, sTotal);

        }
        [TestMethod]
        public void SummaryReportAction_Should_Return_View()
        {
            //List<tDRCRequest> testData = CreateRequestTest();
            // Arrange
            var controller = CreateDRCControllerAs("SomeUser", testData);

            // Act
            var result = controller.Summary_Report() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AnalystReportAction_Should_Return_View()
        {
            //List<tDRCRequest> testData = CreateRequestTest();
            // Arrange
            var controller = CreateDRCControllerAs("SomeUser", testData);

            // Act
            var result = controller.Analyst_Report() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /*  [TestMethod]
          public void DisabilityReportAction_Should_Return_PartialView()
          {
              //List<tDRCRequest> testData = CreateRequestTest();
              // Arrange
              var controller = CreateDRCControllerAs("SomeUser", testData);
              List<DisabilityReportResult> testr = new List<DisabilityReportResult>()
              {
                  new DisabilityReportResult {  }
              }
              // Act
              var result = controller.DisabilityReport("2016") as PartialViewResult;

              // Assert
              //Assert.IsInstanceOfType(result.ViewData.Model, typeof(searchModel));
              Assert.AreEqual("DisabilityReport", result.ViewName, "All action on Status Filter  controller did not return a partial view called _StatusFilter.");
          }

      */

        [TestMethod]
        public void EditAction_Should_Redirect_When_Update_Successful()
        {

            // Arrange     
            var controller = CreateDRCControllerAs("SomeUser", testData);
            // List<tDRCRequest> testData = CreateRequestTest();
            //List<tDRCRequest> updateData = testData;
            //updateData.ElementAt(1).EmployeeLastName = "Test";
            var formValues = new RequestViewModel(testData.ElementAt(1));
            formValues.EmployeeLastName = "Tews";
           // formValues.AnalystAssigned = 10000000;

            //controller.ValueProvider = formValues;

            // Act
            var result = controller.Edit(1, formValues) as RedirectToRouteResult;
            //var test = testData.ElementAt(1).EmployeeLastName;
            //var test2 = formValues.EmployeeLastName;

            // Assert
            //Assert.AreEqual(test, test2);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }


       

        [TestMethod]
        public void Delete_Request()
        {

            // Arrange     
            var controller = CreateDRCControllerAs("SomeUser", testData);
            // List<tDRCRequest> testData = CreateRequestTest();
            //List<tDRCRequest> updateData = testData;
            //updateData.ElementAt(1).EmployeeLastName = "Test";
            var testStart = testData.ElementAt(1).deleted;
            var formValues = new RequestViewModel(testData.ElementAt(1));
            formValues.EmployeeLastName = "Delete";
            formValues.deleted = true;
            // formValues.AnalystAssigned = 10000000;

            //controller.ValueProvider = formValues;

            // Act
            var result = controller.Edit(1, formValues) as RedirectToRouteResult;
            
            var testEnd = testData.ElementAt(1).deleted;
            //var test2 = formValues.EmployeeLastName;
            // Assert
            Assert.AreNotEqual(testStart, testEnd);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void Search_Delete_Request_find()
        {

            // Arrange     
            var controller = CreateDRCControllerS("SomeUser", testData, searchData);
            // List<tDRCRequest> testData = CreateRequestTest();
            //List<tDRCRequest> updateData = testData;
            //updateData.ElementAt(1).EmployeeLastName = "Test";
            
            searchData.ElementAt(1).EmployeeLastName = "DelSearch";
            var sTotal = searchData.Where(x => x.EmployeeLastName == "DelSearch").Count();
             searchData.ElementAt(1).deleted = true;
            var formValues = new searchModel();
            formValues.deleted = true;
            formValues.EmployeeLastName = "DelSearch";
            var result = controller.SearchForm(formValues); //as RedirectToRouteResult;
            var model = ((ViewResult)result).Model as List<ResultsResult>;
            //var sTotal = model.Count;
            Assert.IsNotNull(model, "model is not of type List<ResultsResult>");
            Assert.AreEqual(model.Count, sTotal);
            
        }
        [TestMethod]
        public void Search_Delete_Request_No_find()
        {

            // Arrange     
            var controller = CreateDRCControllerS("SomeUser", testData, searchData);
            // List<tDRCRequest> testData = CreateRequestTest();
            //List<tDRCRequest> updateData = testData;
            //updateData.ElementAt(1).EmployeeLastName = "Test";

           searchData.ElementAt(1).EmployeeLastName = "DelSearch";
            var sTotal = searchData.Where(x => x.EmployeeLastName == "DelSearch").Count();
            //var testStart = testData.ElementAt(1).deleted;
            var formValues = new searchModel();
            //formValues.deleted = true;
            formValues.EmployeeLastName = "DelSearch";
            var result = controller.SearchForm(formValues); //as RedirectToRouteResult;
            var model = ((ViewResult)result).Model as List<ResultsResult>;
            //var sTotal = model.Count;
            Assert.IsNotNull(model, "model is not of type List<ResultsResult>");
            Assert.AreEqual(model.Count, sTotal);

        }

    }
}
