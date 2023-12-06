using System;
using System.ComponentModel.DataAnnotations;


namespace HRManagmentErp.Models
{
    public class UserDetails
    {
        public int UserID { get; set; }


        [Required(ErrorMessage ="Please Enter First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Emai; Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public string MobileNo { get; set; }


        [Required(ErrorMessage = "Please Enter Your Address")]
        public string EmpAddress { get; set; }


        public DateTime CreatedOn { get; set; }
        public bool IsApproved { get; set; }
    }
}