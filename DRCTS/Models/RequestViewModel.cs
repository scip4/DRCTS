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
        [Display(Name = "Employee First Name")]
        public string EmployeeFirstName { get; set; }
        public string Position { get; set; }
        public string Grade { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Employee Phone")]
        public string EmployeePhone { get; set; }
        [Display(Name = "Employee Email")]
        public string EmployeeEmail { get; set; }
        public string Disability { get; set; }
        [Display(Name = "Supervisor Last Name")]
        public string SupervisorLastName { get; set; }
        [Display(Name = "Supervisor First Name")]
        public string SupervisorFirstName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Supervisor Phone")]
        public string SupervisorPhone { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Request Receivied")]
        public Nullable<System.DateTime> DateRequestReceived { get; set; }
        [Display(Name = "COWA Date")]
        public Nullable<System.DateTime> COWADate { get; set; }
        [Display(Name = "Qtr. Receivied")]
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
        public string Source { get; set; }
        [Display(Name = "Requested MD715 Category")]
        public string RequestedMD715 { get; set; }
        [Display(Name = "MD-715 Category After RA process")]
        public string EndMD715 { get; set; }
        [Display(Name = "Analyst Assigned")]
        public string AnalystAssigned { get; set; }
        [Display(Name = "Time Frame Today")]
        public string TFToday { get; set; }
        public Nullable<System.DateTime> TFReportDate { get; set; }
        [Display(Name = "Report In/Out")]
        public string ReportInOut { get; set; }
        [Display(Name = "Notes on Status")]
        public string Notes { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [Display(Name = "Purchasing Source")]
        public string Purchasing { get; set; }
        [Display(Name = "PR Number")]
        public string PRNumber { get; set; }
        public bool? deleted { get; internal set; }
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
                EmployeeEmail = toTable.EmployeeEmail,
                Disability = toTable.Disability,
                SupervisorLastName = toTable.SupervisorLastName,
                SupervisorFirstName = toTable.SupervisorFirstName,
                SupervisorPhone = toTable.SupervisorPhone,
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
                UpdatedBy = toTable.UpdatedBy

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
                EmployeeEmail = drcTable.EmployeeEmail;
                Disability = drcTable.Disability;
                SupervisorLastName = drcTable.SupervisorLastName;
                SupervisorFirstName = drcTable.SupervisorFirstName;
                SupervisorPhone = drcTable.SupervisorPhone;
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
                TFToday = drcTable.TFToday;
                TFReportDate = drcTable.TFReportDate;
                ReportInOut = drcTable.ReportInOut;
                Notes = drcTable.Notes;
                Comments = drcTable.Comments;
                deleted = drcTable.deleted;
                CreatedBy = drcTable.CreatedBy;
                Purchasing = drcTable.Purchasing;
                PRNumber = drcTable.PRNumber;
            UpdatedBy = drcTable.UpdatedBy;

           
        }


    }

    



    public class rSource
    {
        public string requestType { get; set; }
    }

}