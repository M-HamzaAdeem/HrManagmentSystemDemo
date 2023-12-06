using HRManagmentErp.Models;
using HRMDal.Models;
using HRMDal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRManagmentErp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Index()
        {
            var AdminUserData = Session["EmployeeData"] as EmployeeExtendedDto;
            
            if (AdminUserData != null)
            {
                AdminViewModel adminViewModel = new AdminViewModel();
                adminViewModel.AdminEmployee = AdminUserData;

                UserDal userDal = new UserDal();
                adminViewModel.ApprovedUsers = userDal.GetAllApproved();

                adminViewModel.UnApprovedUsers = userDal.GetAllUnApproved();
                return View(adminViewModel);
            }

            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [HttpPost]
        public ActionResult UserConfig(NewUser currentUser)
        {
            UserDal userDal = new UserDal();
           if (Session["EmployeeData"] != null)
            {
                return RedirectToAction("Index", "User");
            }

            if (currentUser.IsApproved)
            {

                userDal.ApproveUser(currentUser.UserName);
                EmployeeDal employeeDal = new EmployeeDal();
                var EmployeeExtendedData = employeeDal.GetExtendedEmployee(currentUser.UserName);
                return View("EmployeeConfig", EmployeeExtendedData);
            }
            else
            {
                var User = userDal.GetUser(currentUser.UserName);
                return View(User);
            }

            
        }


        [HttpPost]
        public ActionResult EmployeeConfig(EmployeeExtendedDto employeeDetails)
        {
            if (Session["EmployeeData"] != null)
            {
                return RedirectToAction("Index", "User");
            }

            EmployeeDal employeeDal = new EmployeeDal();

            var EmployeeExtendedData = employeeDal.GetExtendedEmployee(employeeDetails.UserName);

                if (employeeDetails.DesiginationName != EmployeeExtendedData.DesiginationName)
                {
                    switch (employeeDetails.DesiginationName)
                    {
                        case "Assistant Manager":
                            employeeDal.UpdatePayScale(employeeDetails.UserName, PayScale.AssistantManager);
                            break;
                        case "Manager":
                            employeeDal.UpdatePayScale(employeeDetails.UserName, PayScale.Manager);
                            break;
                        case "General Manager":
                            employeeDal.UpdatePayScale(employeeDetails.UserName, PayScale.GeneralManager);
                            break;
                        case "Director General":
                            employeeDal.UpdatePayScale(employeeDetails.UserName, PayScale.DirectorGeneral);
                            break;
                    }


                }

                if (employeeDetails.DepartmentName != EmployeeExtendedData.DepartmentName)
                {
                    switch (employeeDetails.DepartmentName)
                    {
                        case "Human Resource":
                            employeeDal.UpdateDepartment(employeeDetails.UserName, DepartmentCode.HumanResource);
                            break;
                        case "Admin":
                            employeeDal.UpdateDepartment(employeeDetails.UserName, DepartmentCode.Admin);
                            break;
                        case "Technical Support":
                            employeeDal.UpdateDepartment(employeeDetails.UserName, DepartmentCode.TechnicalSupport);
                            break;
                        case "Frontend Department":
                            employeeDal.UpdateDepartment(employeeDetails.UserName, DepartmentCode.FrontendDepartment);
                            break;
                        case "Backend Department":
                            employeeDal.UpdateDepartment(employeeDetails.UserName, DepartmentCode.BackendDepartment);
                            break;
                    }

                }

                if (employeeDetails.RoUserName != EmployeeExtendedData.RoUserName)
                {

                    if (employeeDal.GetEmployee(employeeDetails.RoUserName) != null)
                    {
                        employeeDal.UpdateRo(employeeDetails.UserName, employeeDetails.RoUserName);
                    }
                    else
                    {
                        ViewBag.Message = "Reporting officer with given username Don't Exist ";
                    }
                }
            EmployeeExtendedData = employeeDal.GetExtendedEmployee(employeeDetails.UserName);
            return View("EmployeeConfig", EmployeeExtendedData);

            
           
        }


    }
}