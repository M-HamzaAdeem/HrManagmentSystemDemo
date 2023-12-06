using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManagmentErp.Models
{
    public class LoginDetails
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        public string UserPassword { get; set; }
    }
}