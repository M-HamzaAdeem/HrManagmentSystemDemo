using Dapper;
using HRMDal.Models;
using HRMDal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMDal.Repositories
{
    internal class EmployeeRepository :IEmployeeRepository
    {
        private readonly string _connectionString;
        public EmployeeRepository(string connectionString = "Server=HAMZA-DELL-LETI\\MSSQLSERVER2;Database=HRManagment;User Id=sa;Password=1234")
        {
            _connectionString = connectionString;
        }


        public Employee GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM NewUser WHERE Employee = @id";
                var employee = connection.QuerySingleOrDefault<Employee>(sql, new { id });
                return employee;
            }
        }

        public Employee GetByUserName(string userName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Employee WHERE UserName = @UserName";
                var employee = connection.QuerySingleOrDefault<Employee>(sql, new { userName });
                return employee;
            }
        }

        public EmployeeExtendedDto GetExtendedByUserName(string userName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"select 
                            Employee.EmployeeID, Employee.FirstName, Employee.LastName, Employee.UserName, Employee.UserPassword, Employee.Email, 
                            Employee.MobileNo,Employee.EmpAddress,i.FirstName + ' '+ i.LastName as RoName,i.UserName as RoUserName,Designation.DesiginationName,Department.DepartmentName,Country.CountryName,Employee.CreatedOn
                            from Employee
                            left join Designation on Employee.PayScale = Designation.PayScale
                            left join Country on Employee.CountryCode = Country.CountryCode
                            left join Employee as i on i.EmployeeID = Employee.ReportingOfficerID
                            left join Department on Employee.DepartmentCode = Department.DepartmentCode
                            WHERE Employee.UserName = @UserName";
                var employee = connection.QuerySingleOrDefault<EmployeeExtendedDto>(sql, new { userName });
                return employee;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Employee";
                IEnumerable<Employee> employees = connection.Query<Employee>(sql);
                return employees;
            }
        }

        public IEnumerable<EmployeeExtendedDto> GetExtendedEmployees()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"select 
                            Employee.EmployeeID, Employee.FirstName, Employee.LastName, Employee.UserName, Employee.UserPassword, Employee.Email, 
                            Employee.MobileNo,Employee.EmpAddress,i.FirstName + ' '+ i.LastName as RoName,i.UserName as RoUserName,Designation.DesiginationName,Department.DepartmentName,Country.CountryName,Employee.CreatedOn
                            from Employee
                            left join Designation on Employee.PayScale = Designation.PayScale
                            left join Country on Employee.CountryCode = Country.CountryCode
                            left join Employee as i on i.EmployeeID = Employee.ReportingOfficerID
                            left join Department on Employee.DepartmentCode = Department.DepartmentCode";
                IEnumerable<EmployeeExtendedDto> employees = connection.Query<EmployeeExtendedDto>(sql);
                return employees;
            }
        }


        public int UpdateDepartment(string userName, DepartmentCode departmentCode )
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Employee 
                                SET DepartmentCode = @departmentCode 
                                    WHERE UserName = @userName";

                var affectedRows = connection.Execute(sql, new { userName, departmentCode });
                return affectedRows;
            }
        }
        public int UpdatePayScale(string userName, PayScale payScale)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Employee 
                                SET PayScale = @payScale 
                                    WHERE UserName = @userName";

                var affectedRows = connection.Execute(sql, new { userName, payScale });
                return affectedRows;
            }
        }
        public int UpdateRo(string userName, string Ro)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Employee 
                            SET ReportingOfficerID = (SELECT TOP 1 EmployeeID FROM Employee WHERE UserName = @Ro)
                            WHERE UserName = @userName";

                var affectedRows = connection.Execute(sql, new { userName, Ro });
                return affectedRows;
            }
        }

    }
}
