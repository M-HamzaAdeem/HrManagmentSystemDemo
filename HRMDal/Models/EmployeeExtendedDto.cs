using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMDal.Models
{
    public class EmployeeExtendedDto
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string EmpAddress { get; set; }

        public string RoName { get; set; }
        public string RoUserName { get; set; }
        public string DesiginationName { get; set; }
        public string DepartmentName { get; set; }


        public string CountryName { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
