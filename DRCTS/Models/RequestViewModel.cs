using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DRCTS.Models
{
    
    public class RequestViewModel
    {
        public int ID { get; set; }
        [Required]
        public string OA { get; set; }
        public string CaseID { get; set; }
        public string EmployeeID { get; set; }
        [Required]
        [Display(Name = "Employee Last Name")]
        public string EmployeeLastName { get; set; }
        [Required]
        [Display(Name = "Employee First Name")]
        public string EmployeeFirstName { get; set; }
        public string Position { get; set; }
        public string Grade { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Employee Phone")]
        public string EmployeePhone { get; set; }
        [Display(Name = "Extention")]
        public string EmployeePhoneExt { get; set; }
        [Required]
        [Display(Name = "Employee Email")]
        public string EmployeeEmail { get; set; }
        [Required]
        public string Disability { get; set; }
        [Display(Name = "Supervisor Last Name")]
        public string SupervisorLastName { get; set; }
        [Display(Name = "Supervisor First Name")]
        public string SupervisorFirstName { get; set; }
        [Display(Name = "Supervisor Email")]
        public string SupervisorEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Supervisor Phone")]
        public string SupervisorPhone { get; set; }
        [Display(Name = "Extention")]
        public string SupervisorPhoneExt { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Request Received")]
        [Required]
        public Nullable<System.DateTime> DateRequestReceived { get; set; }
        [Display(Name = "COWA Date")]
        public Nullable<System.DateTime> COWADate { get; set; }
        [Display(Name = "Qtr. Received")]
        public string QuarterReceived { get; set; }
        [Display(Name = "Date Completed")]
        public Nullable<System.DateTime> DateCompleted { get; set; }
        [Display(Name = "Date Fulfilled")]
        public Nullable<System.DateTime> DateFulfilled { get; set; }
        [Display(Name = "DRC Request Type")]
        public string DRCRequestType { get; set; }
        [Display(Name = "DRC Status")]
        public string DRCStatus { get; set; }
        public string OC { get; set; }
        [Required]
        public string Source { get; set; }
        [Display(Name = "Requested MD715 Category")]
        public string RequestedMD715 { get; set; }
        [Display(Name = "MD-715 Category After RA process")]
        public string EndMD715 { get; set; }
        [Display(Name = "Analyst Assigned")]
        public string AnalystAssigned { get; set; }
        [Display(Name = "Time Frame Today (days)")]
        public int TFToday { get; set; }
        public Nullable<System.DateTime> TFReportDate { get; set; }
        [Display(Name = "Report In/Out")]
        public string ReportInOut { get; set; }
        [Display(Name = "Notes on Status")]
        public string Notes { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Updated Date")]
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        [Display(Name = "Purchasing Source")]
        public string Purchasing { get; set; }
        [Display(Name = "PR Number")]
        public string PRNumber { get; set; }
        [Display(Name = "PR Amount")]
        public string Amount { get; set; }
        // public bool? deleted { get; internal set; }
        [Display(Name = "Delete Case")]
        public bool deleted { get; set; }
        [Display(Name = "Describe Provided Accommodation")]
        public string ProvidedAccom { get; set; }
        [Display(Name = "Opened Date")]
        public Nullable<System.DateTime> assignedopenDate { get; set; }
        public RequestViewModel()
        {
           // ID = ID;
        }
        

        public static implicit operator tDRCRequest(RequestViewModel toTable)
        {
            return new tDRCRequest
            {
                ID = toTable.ID,
                OA = toTable.OA,
                CaseID = toTable.CaseID,
                EmployeeID = toTable.EmployeeID,
                EmployeeLastName = toTable.EmployeeLastName,
                EmployeeFirstName = toTable.EmployeeFirstName,
                Position = toTable.Position,
                Grade = toTable.Grade,
                EmployeePhone = toTable.EmployeePhone,
                EmployeePhoneExt = toTable.EmployeePhoneExt,
                EmployeeEmail = toTable.EmployeeEmail,
                Disability = toTable.Disability,
                SupervisorLastName = toTable.SupervisorLastName,
                SupervisorFirstName = toTable.SupervisorFirstName,
                SupervisorEmail = toTable.SupervisorEmail,
                SupervisorPhone = toTable.SupervisorPhone,
                SupervisorPhoneExt = toTable.SupervisorPhoneExt,
                Description = toTable.Description,
                DateRequestReceived = toTable.DateRequestReceived,
                COWADate = toTable.COWADate,
                QuarterReceived = toTable.QuarterReceived,
                DateCompleted = toTable.DateCompleted,
                DateFulfilled = toTable.DateFulfilled,
                DRCRequestType = toTable.DRCRequestType,
                DRCStatus = toTable.DRCStatus,
                OC = toTable.OC,
                Source = toTable.Source,
                RequestedMD715 = toTable.RequestedMD715,
                EndMD715 = toTable.EndMD715,
                AnalystAssigned = toTable.AnalystAssigned,
                TFToday = toTable.TFToday,
                TFReportDate = toTable.TFReportDate,
                ReportInOut = toTable.ReportInOut,
                Notes = toTable.Notes,
                Comments = toTable.Comments,
                deleted = toTable.deleted,
                CreatedBy = toTable.CreatedBy,
                Purchasing = toTable.Purchasing,
                PRNumber = toTable.PRNumber,
                Amount = toTable.Amount,
                UpdatedBy = toTable.UpdatedBy,
                CreatedDate = toTable.CreatedDate,
                UpdatedDate = toTable.UpdatedDate,
                ProvidedAccom = toTable.ProvidedAccom,
                assignedopenDate = toTable.assignedopenDate

            };

        }
        public  RequestViewModel(tDRCRequest drcTable)
        {
           
                ID = drcTable.ID;
                OA = drcTable.OA;
                CaseID = drcTable.CaseID;
                EmployeeID = drcTable.EmployeeID;
                EmployeeLastName = drcTable.EmployeeLastName;
                EmployeeFirstName = drcTable.EmployeeFirstName;
                Position = drcTable.Position;
                Grade = drcTable.Grade;
                EmployeePhone = drcTable.EmployeePhone;
            EmployeePhoneExt = drcTable.EmployeePhoneExt;
                EmployeeEmail = drcTable.EmployeeEmail;
                Disability = drcTable.Disability;
                SupervisorLastName = drcTable.SupervisorLastName;
                SupervisorFirstName = drcTable.SupervisorFirstName;
            SupervisorEmail = drcTable.SupervisorEmail;
                SupervisorPhone = drcTable.SupervisorPhone;
            SupervisorPhoneExt = drcTable.SupervisorPhoneExt;
                Description = drcTable.Description;
                DateRequestReceived = drcTable.DateRequestReceived;
                COWADate = drcTable.COWADate;
                QuarterReceived = drcTable.QuarterReceived;
                DateCompleted = drcTable.DateCompleted;
                DateFulfilled = drcTable.DateFulfilled;
                DRCRequestType = drcTable.DRCRequestType;
                DRCStatus = drcTable.DRCStatus;
                OC = drcTable.OC;
                Source = drcTable.Source;
                RequestedMD715 = drcTable.RequestedMD715;
                EndMD715 = drcTable.EndMD715;
                AnalystAssigned = drcTable.AnalystAssigned;
                TFToday = (int)drcTable.TFToday;
                TFReportDate = drcTable.TFReportDate;
                ReportInOut = drcTable.ReportInOut;
                Notes = drcTable.Notes;
                Comments = drcTable.Comments;
                deleted = (bool)drcTable.deleted;
                CreatedBy = drcTable.CreatedBy;
                Purchasing = drcTable.Purchasing;
                PRNumber = drcTable.PRNumber;
            Amount = drcTable.Amount;
            UpdatedBy = drcTable.UpdatedBy;
            CreatedDate = drcTable.CreatedDate;
            UpdatedDate = drcTable.UpdatedDate;
            ProvidedAccom = drcTable.ProvidedAccom;
            assignedopenDate = drcTable.assignedopenDate;

           
        }
        public RequestViewModel(List<tDRCRequest> drcTable)
        {

            ID = drcTable.ElementAt(0).ID;
            OA = drcTable.ElementAt(0).OA;
            CaseID = drcTable.ElementAt(0).CaseID;
            EmployeeID = drcTable.ElementAt(0).EmployeeID;
            EmployeeLastName = drcTable.ElementAt(0).EmployeeLastName;
            EmployeeFirstName = drcTable.ElementAt(0).EmployeeFirstName;
            Position = drcTable.ElementAt(0).Position;
            Grade = drcTable.ElementAt(0).Grade;
            EmployeePhone = drcTable.ElementAt(0).EmployeePhone;
            EmployeePhoneExt = drcTable.ElementAt(0).EmployeePhoneExt;
            EmployeeEmail = drcTable.ElementAt(0).EmployeeEmail;
            Disability = drcTable.ElementAt(0).Disability;
            SupervisorLastName = drcTable.ElementAt(0).SupervisorLastName;
            SupervisorFirstName = drcTable.ElementAt(0).SupervisorFirstName;
            SupervisorEmail = drcTable.ElementAt(0).SupervisorEmail;
            SupervisorPhone = drcTable.ElementAt(0).SupervisorPhone;
            SupervisorPhoneExt = drcTable.ElementAt(0).SupervisorPhoneExt;
            Description = drcTable.ElementAt(0).Description;
            DateRequestReceived = drcTable.ElementAt(0).DateRequestReceived;
            COWADate = drcTable.ElementAt(0).COWADate;
            QuarterReceived = drcTable.ElementAt(0).QuarterReceived;
            DateCompleted = drcTable.ElementAt(0).DateCompleted;
            DateFulfilled = drcTable.ElementAt(0).DateFulfilled;
            DRCRequestType = drcTable.ElementAt(0).DRCRequestType;
            DRCStatus = drcTable.ElementAt(0).DRCStatus;
            OC = drcTable.ElementAt(0).OC;
            Source = drcTable.ElementAt(0).Source;
            RequestedMD715 = drcTable.ElementAt(0).RequestedMD715;
            EndMD715 = drcTable.ElementAt(0).EndMD715;
            AnalystAssigned = drcTable.ElementAt(0).AnalystAssigned;
            TFToday = (int)drcTable.ElementAt(0).TFToday;
            TFReportDate = drcTable.ElementAt(0).TFReportDate;
            ReportInOut = drcTable.ElementAt(0).ReportInOut;
            Notes = drcTable.ElementAt(0).Notes;
            Comments = drcTable.ElementAt(0).Comments;
            deleted = (bool)drcTable.ElementAt(0).deleted;
            CreatedBy = drcTable.ElementAt(0).CreatedBy;
            Purchasing = drcTable.ElementAt(0).Purchasing;
            PRNumber = drcTable.ElementAt(0).PRNumber;
            Amount = drcTable.ElementAt(0).Amount;
            UpdatedBy = drcTable.ElementAt(0).UpdatedBy;
            CreatedDate = drcTable.ElementAt(0).CreatedDate;
            UpdatedDate = drcTable.ElementAt(0).UpdatedDate;
            ProvidedAccom = drcTable.ElementAt(0).ProvidedAccom;
            assignedopenDate = drcTable.ElementAt(0).assignedopenDate;


        }
        public RequestViewModel(CustomSearchResult drcTable)
        {

            ID = drcTable.ID;
            OA = drcTable.OA;
            CaseID = drcTable.CaseID;
            EmployeeID = drcTable.EmployeeID;
            EmployeeLastName = drcTable.EmployeeLastName;
            EmployeeFirstName = drcTable.EmployeeFirstName;
            Position = drcTable.Position;
            Grade = drcTable.Grade;
            EmployeePhone = drcTable.EmployeePhone;
            EmployeePhoneExt = drcTable.EmployeePhoneExt;
            EmployeeEmail = drcTable.EmployeeEmail;
            Disability = drcTable.Disability;
            SupervisorLastName = drcTable.SupervisorLastName;
            SupervisorFirstName = drcTable.SupervisorFirstName;
            SupervisorEmail = drcTable.SupervisorEmail;
            SupervisorPhone = drcTable.SupervisorPhone;
            SupervisorPhoneExt = drcTable.SupervisorPhoneExt;
            Description = drcTable.Description;
            DateRequestReceived = drcTable.DateRequestReceived;
            COWADate = drcTable.COWADate;
            QuarterReceived = drcTable.QuarterReceived;
            DateCompleted = drcTable.DateCompleted;
            DateFulfilled = drcTable.DateFulfilled;
            DRCRequestType = drcTable.DRCRequestType;
            DRCStatus = drcTable.DRCStatus;
            OC = drcTable.OC;
            Source = drcTable.Source;
            RequestedMD715 = drcTable.RequestedMD715;
            EndMD715 = drcTable.EndMD715;
            AnalystAssigned = drcTable.AnalystAssigned;
            TFToday = (int)drcTable.TFToday;
            TFReportDate = drcTable.TFReportDate;
            ReportInOut = drcTable.ReportInOut;
            Notes = drcTable.Notes;
            Comments = drcTable.Comments;
            deleted = (bool)drcTable.deleted;
            CreatedBy = drcTable.CreatedBy;
            Purchasing = drcTable.Purchasing;
            PRNumber = drcTable.PRNumber;
            Amount = drcTable.Amount;
            UpdatedBy = drcTable.UpdatedBy;
            CreatedDate = drcTable.CreatedDate;
            UpdatedDate = drcTable.UpdatedDate;
            ProvidedAccom = drcTable.ProvidedAccom;

        }

    }

    



    public class rSource
    {
        public string requestType { get; set; }
    }
    public class status
    {
        public string caseStatus { get; set; }
    }
    public class CheckModel
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public bool Checked
        {
            get;
            set;
        }
    }
    public class pfStatus
    {
        public int id { get; set; }
        public string prstatus { get; set; }
    }
   public class prStat
    {
        public int id { get; set; }
        public string Purchasing { get; set; }
    }
    public class rptYear
    {
        public bool Selected { get; internal set; }
        public string Year { get; set; }
    }
    public class fyYear
    {
        public int Year { get; set; }
        public bool Selected { get; set; }
    }
    public class rptQuarter
    {
        public int qtr { get; set; }
        public string MyText { get; set; }
    }
    public class searchModel
    {
        public string OA { get; set; }
        public string CaseID { get; set; }
        public string EmployeeID { get; set; }
        
        [Display(Name = "Employee Last Name")]
        public string EmployeeLastName { get; set; }
        [Display(Name = "Employee First Name")]
        public string EmployeeFirstName { get; set; }
        public string Position { get; set; }
        public string Grade { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Employee Phone")]
        public string EmployeePhone { get; set; }
        [Display(Name = "Extention")]
        public string EmployeePhoneExt { get; set; }
        [Display(Name = "Employee Email")]
        public string EmployeeEmail { get; set; }
        public string Disability { get; set; }
        [Display(Name = "Supervisor Last Name")]
        public string SupervisorLastName { get; set; }
        [Display(Name = "Supervisor First Name")]
        public string SupervisorFirstName { get; set; }
        [Display(Name = "Supervisor Email")]
        public string SupervisorEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Supervisor Phone")]
        public string SupervisorPhone { get; set; }
        [Display(Name = "Extention")]
        public string SupervisorPhoneExt { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Request Received")]
        public Nullable<System.DateTime> DateRequestReceived { get; set; }
        [Display(Name = "End Date Request Received")]
        public Nullable<System.DateTime> endDateRequestReceived { get; set; }
        [Display(Name = "COWA Date")]
        public Nullable<System.DateTime> COWADate { get; set; }
        [Display(Name = " End COWA Date")]
        public Nullable<System.DateTime> endCOWADate { get; set; }
        [Display(Name = "Qtr. Received")]
        public string QuarterReceived { get; set; }
        [Display(Name = "Date Completed")]
        public Nullable<System.DateTime> DateCompleted { get; set; }
        [Display(Name = "End Date Completed")]
        public Nullable<System.DateTime> endDateCompleted { get; set; }
        [Display(Name = "Date Fulfilled")]
        public Nullable<System.DateTime> DateFulfilled { get; set; }
        [Display(Name = "End Date Fulfilled")]
        public Nullable<System.DateTime> endDateFulfilled { get; set; }
        [Display(Name = "DRC Request Type")]
        public string DRCRequestType { get; set; }
        [Display(Name = "DRC Status")]
        public string DRCStatus { get; set; }
        public string OC { get; set; }
        public string Source { get; set; }
        [Display(Name = "Requested MD715 Category")]
        public string RequestedMD715 { get; set; }
        [Display(Name = "MD-715 Category After RA process")]
        public string EndMD715 { get; set; }
        [Display(Name = "Analyst Assigned")]
        public string AnalystAssigned { get; set; }
        [Display(Name = "Time Frame")]
        public int TFToday { get; set; }
        public string TFoption { get; set; }
        public Nullable<System.DateTime> TFReportDate { get; set; }
        [Display(Name = "Report In/Out")]
        public string ReportInOut { get; set; }
        [Display(Name = "Notes on Status")]
        public string Notes { get; set; }
        public string Comments { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Purchasing Source")]
        public string Purchasing { get; set; }
        [Display(Name = "PR Number")]
        public string PRNumber { get; set; }
        [Display(Name = "PR Amount")]
        public string Amount { get; set; }
        public string amOption { get; set; }
        [Display(Name = "Search for Deleted Requests")]
        public bool deleted { get; set; }
        [Display(Name = "Describe Provided Accommodation")]
        public string ProvidedAccom { get; set; }
    }
}