using HRMDal.Models;
using HRMDal.Repositories;
using HRMDal.Repositories.Interfaces;
using HRMDal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMDal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NewUser user = new NewUser() 
            //{
            //    FirstName = "li",
            //    LastName = "Cho",
            //    UserName = "Cho_li",
            //    UserPassword = "securassword123",
            //    Email = "john.doe@example.com",
            //    MobileNo = "12345670",
            //    EmpAddress = "123 Main St, Anytown, USA",
            //};

            //UserDal userData = new UserDal();

            //if (userData.isAvailable(user.UserName)) // use try catch
            //{
            //    int i = userData.AddUser(user);
            //    Console.WriteLine(i);
            //}
            //else
            //{
            //    Console.WriteLine("User Name already takes");
            //}

            //var i = userData.GetUser(user.UserName);
            //Console.WriteLine(i.FirstName);

            //var i = userData.ApproveUser(user.UserName);
            //Console.WriteLine(i);



            //  EmployeeDal employeeDal = new EmployeeDal();

            //var employee = employeeDal.GetEmployee(user.UserName);
            //Console.WriteLine(employee.FirstName);


            //var i = employeeDal.UpdatePayScale(user.UserName, PayScale.DirectorGeneral);
            //var employee = employeeDal.GetEmployee(user.UserName);
            //Console.WriteLine(employee.FirstName);
            //Console.WriteLine(employee.PayScale);
            //Console.WriteLine(i);


            //var i = employeeDal.UpdateDepartment(user.UserName, DepartmentCode.TechnicalSupport);
            //var employee = employeeDal.GetEmployee(user.UserName);
            //Console.WriteLine(employee.FirstName);
            //Console.WriteLine(employee.DepartmentCode);
            //Console.WriteLine(i);
          //  Console.WriteLine(userData.MobileNoIsAvailable("09007802"));



            //    var i = employeeDal.GetAllEmployees();
            //    foreach (var employee in i)
            //    {
            //      Console.WriteLine(employee.DepartmentCode);
            //    }
            //    Console.WriteLine(" ");
            //    Console.WriteLine(" ");
            //    var j = employeeDal.GetAllExtended();
            //    foreach (var employee in j)
            //    {
            //        Console.WriteLine(employee.DepartmentName);
            //    }
            //    Console.WriteLine(" ");
            //    Console.WriteLine(" ");


            //    var k = employeeDal.GetExtendedEmployee("Hamza1");

            //        Console.WriteLine(k.FirstName);

                Console.ReadLine();
        }

        


    }
}
