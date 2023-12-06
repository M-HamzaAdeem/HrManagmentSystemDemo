using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMDal.Models
{
    public class NewUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string EmpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsApproved { get; set; }
    }
}
