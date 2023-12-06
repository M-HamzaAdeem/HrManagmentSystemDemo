using HRMDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMDal.Repositories.Interfaces
{
    internal interface IUserRepository
    {
        IEnumerable<NewUser> GetUnApprovedUsers();
        IEnumerable<NewUser> GetApprovedUsers();
        IEnumerable<NewUser> GetUsers();
        NewUser GetUserByUserName(string id);
        int AddUser (NewUser user);

        int ApproveUserByUserName (string userName);
        bool UserNameIsAvailable(string userName);
        bool PasswordIsAvailable(string userPassword);
        bool MobileNoIsAvailable(string MobileNo);

    }
}
