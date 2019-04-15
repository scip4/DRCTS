using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentitySample.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Sub Application")]
        public string SubApp { get; set; }
    }

    public class UserAdminModel
    {
        //au.Id, au.LastName, au.FirstName, au.UserName, ar.Name as 'Role', au.LastAccess, au.LockoutEndDateUtc
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Role")]
        public string Role { get; set; }
      
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
    }
    public class AuditLogViewModel
    {
        [Display(Name = "Audit Type")]
        public string AuditType { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }

    }
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /* [Required]
         [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
         [DataType(DataType.Password)]
         [Display(Name = "Password")]
         public string Password { get; set; }

         [DataType(DataType.Password)]*/
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        // Add the new address properties:
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        public string Organization { get; set; }
        [Display(Name = "Job title")]
        public string JobTitle { get; set; }
        // Use a sensible display name for views:
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}