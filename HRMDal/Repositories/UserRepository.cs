using Dapper;
using HRMDal.Models;
using HRMDal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace HRMDal.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly string  _connectionString;
        public UserRepository(string connectionString = "Server=HAMZA-DELL-LETI\\MSSQLSERVER2;Database=HRManagment;User Id=sa;Password=1234")
        {
            _connectionString = connectionString;
        }

        public int AddUser(NewUser user)
        {
            using (var connection = new SqlConnection(_connectionString) )
            {
                var sql = @"INSERT 
                                INTO NewUser (FirstName, LastName, UserName, UserPassword, Email, MobileNo,EmpAddress)
                                Values 
                                   ( @FirstName,@LastName, @UserName,@UserPassword, @Email,@MobileNo,@EmpAddress)";
                


                var affectedRows = connection.Execute(sql,user);
                return affectedRows;
            }
        }

        public int ApproveUserByUserName(string userName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE NewUser 
                                SET IsApproved = 1 
                                    WHERE UserName = @userName";

                var affectedRows = connection.Execute(sql, new { userName });
                return affectedRows;
            }
        }

        public NewUser GetUserByUserName(string userName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM NewUser WHERE UserName = @userName";
                var user = connection.QuerySingleOrDefault<NewUser>(sql, new { userName });
                return user;
            }
        }

        public bool UserNameIsAvailable(string userName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM NewUser WHERE UserName = @userName";
                var user = connection.QuerySingleOrDefault<NewUser>(sql, new { userName });
                if(user != null){
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
        }

        public bool PasswordIsAvailable(string userPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM NewUser WHERE UserPassword = @userPassword";
                var user = connection.QuerySingleOrDefault<NewUser>(sql, new { userPassword });
                if (user != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public bool MobileNoIsAvailable(string MobileNo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM NewUser WHERE MobileNo = @MobileNo";
                var user = connection.QuerySingleOrDefault<NewUser>(sql, new { MobileNo });
                if (user != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public IEnumerable<NewUser> GetUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM NewUser";
                IEnumerable<NewUser> users = connection.Query<NewUser>(sql);
                return users;
            }
        }

        public IEnumerable<NewUser> GetUnApprovedUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM NewUser WHERE IsApproved = 0";
                IEnumerable<NewUser> users = connection.Query<NewUser>(sql);
                return users;
            }
        }

        public IEnumerable<NewUser> GetApprovedUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM NewUser WHERE IsApproved = 1";
                IEnumerable<NewUser> users = connection.Query<NewUser>(sql);
                return users;
            }
        }


    }
}
