using System;


namespace HRMDal.Models
{
    public class Employee
    {

        public int ExUserID { get; set; }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string EmpAddress { get; set; }

        public int ReportingOfficerID { get; set; }
        public int PayScale { get; set; }
        public int DepartmentCode { get; set; }

        public int RoleID { get; set; }

        public int CountryCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }


    }
}
