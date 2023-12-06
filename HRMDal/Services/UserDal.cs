using HRMDal.Repositories.Interfaces;
using HRMDal.Repositories;
using HRMDal.Models;
using System.Collections.Generic;

namespace HRMDal.Services
{
    public class UserDal
    {
        private readonly IUserRepository _userRepository;


        public UserDal()
        {
            _userRepository = new UserRepository();
        }

        public int AddUser(NewUser user)
        {
            int i = _userRepository.AddUser(user);
            return i;
        }

        public NewUser GetUser(string userName)
        {
            var user = _userRepository.GetUserByUserName(userName);
            return user;
        }

        public int ApproveUser(string userName)
        {
            int i = _userRepository.ApproveUserByUserName(userName);
            return i;
        }

        public bool isAvailable(string userName)
        {
            bool isAvailable = _userRepository.UserNameIsAvailable(userName);
            return isAvailable;
        }

        public IEnumerable<NewUser> GetAll()
        {
            var users = _userRepository.GetUsers();
            return users;
        }

        public IEnumerable<NewUser> GetAllApproved()
        {
            var users = _userRepository.GetApprovedUsers();
            return users;
        }

        public IEnumerable<NewUser> GetAllUnApproved()
        {
            var users = _userRepository.GetUnApprovedUsers();
            return users;
        }

        public bool UserNameIsAvailable(string userName)
        {
            return _userRepository.UserNameIsAvailable(userName);
        }
        public bool PasswordIsAvailable(string userName)
        {
            return _userRepository.PasswordIsAvailable(userName);
        }
        public bool MobileNoIsAvailable(string userName)
        {
            return _userRepository.MobileNoIsAvailable(userName);
        }
    }
}
