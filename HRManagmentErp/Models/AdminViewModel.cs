using HRMDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagmentErp.Models
{
    public class AdminViewModel
    {
        public EmployeeExtendedDto AdminEmployee { get; set; }

        public IEnumerable<NewUser> UnApprovedUsers { get; set;}
        public IEnumerable<NewUser> ApprovedUsers { get; set; }

    }
}