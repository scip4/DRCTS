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
        public string EmployeeLastName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string Position { get; set; }
        public string Grade { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string Disability { get; set; }
        public string SupervisorLastName { get; set; }
        public string SupervisorFirstName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string SupervisorPhone { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DateRequestReceived { get; set; }
        public Nullable<System.DateTime> COWADate { get; set; }
        public string QuarterReceived { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<System.DateTime> DateFulfilled { get; set; }
        public string DRCRequestType { get; set; }
        public string DRCStatus { get; set; }
        public string OC { get; set; }
        public string Source { get; set; }
        public string RequestedMD715 { get; set; }
        public string EndMD715 { get; set; }
        public string AnalystAssigned { get; set; }
        public string TFToday { get; set; }
        public Nullable<System.DateTime> TFReportDate { get; set; }
        public string ReportInOut { get; set; }
        public string Notes { get; set; }
        public string Comments { get; set; }
    }
}