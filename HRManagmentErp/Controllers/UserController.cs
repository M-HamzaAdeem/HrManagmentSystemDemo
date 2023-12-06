
using HRManagmentErp.Models;
using HRMDal.Models;
using HRMDal.Services;
using System.Web.Mvc;

namespace HRManagmentErp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginDetails userCredentionals)
        {
            if (ModelState.IsValid)
            {

                EmployeeDal employeeDal = new EmployeeDal();
                var EmployeeData = employeeDal.GetEmployee(userCredentionals.UserName);

                if (EmployeeData != null && EmployeeData.UserPassword == userCredentionals.UserPassword)
                {
                    var EmployeeExtendedData = employeeDal.GetExtendedEmployee(userCredentionals.UserName);
                    Session["EmployeeData"] = EmployeeExtendedData;

                    if (EmployeeData.DepartmentCode == (int)DepartmentCode.Admin)
                    {
                        return RedirectToAction("Index","Admin");
                    }
                    else
                    {

                        return RedirectToAction("Employee"); 
                    }
                }
                else
                {
                    if (EmployeeData != null)
                    {
                        ViewBag.Message = "Wrong Pasword";
                    }
                    else
                    {
                        UserDal userData = new UserDal();
                        var UserData = userData.GetUser(userCredentionals.UserName);
                        if (UserData != null && UserData.UserPassword == userCredentionals.UserPassword)
                        {
                            ViewBag.Message = "Your account is not yet approved";
                        }
                        else if (UserData != null)
                        {
                            ViewBag.Message = "Wrong Pasword";
                        }
                        else
                        {
                            ViewBag.Message = "Username is wrong ";
                        }
                    }
                    return View();
                }



            }
            else
            {
                return View();
            }


        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserDetails userErp)
        {
            if (ModelState.IsValid)
            {
                UserDal userData = new UserDal();
                if(userData.UserNameIsAvailable(userErp.UserName) && userData.PasswordIsAvailable(userErp.UserPassword) && userData.MobileNoIsAvailable(userErp.MobileNo))
                {
                    NewUser userDalModel = new NewUser
                    {
                        FirstName = userErp.FirstName,
                        LastName = userErp.LastName,
                        UserName = userErp.UserName,
                        UserPassword = userErp.UserPassword,
                        Email = userErp.Email,
                        MobileNo = userErp.MobileNo,
                        EmpAddress = userErp.EmpAddress,

                    };

                    UserDal userDal = new UserDal();
                    userDal.AddUser(userDalModel);
                    return View("SignUpSuccesfull");
                }
               else if (!userData.UserNameIsAvailable(userErp.UserName))
                {
                    ViewBag.Message = "User Name is not available";
                    return View("SignUp");
                }
                else if (!userData.UserNameIsAvailable(userErp.UserName))
                {
                    ViewBag.Message = "Password is weak, try a differet pasword";
                    return View("SignUp");
                }
                else if (!userData.UserNameIsAvailable(userErp.UserName))
                {
                    ViewBag.Message = "Incorrect Mobile Numeber ";
                    return View("SignUp");
                }
                else
                {
                    return View("SignUp");

                }
            }
            else
            {
                return View("SignUp");
            }
        }
        public ActionResult SignUpSuccesfull()
        {
            return RedirectToAction("Index", "User");
        }
        public ActionResult Employee()
        {
            if (Session["EmployeeData"] != null)
            {
                var EmployeeExtendedData = Session["EmployeeData"] as EmployeeExtendedDto;
                return View(EmployeeExtendedData);
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
            
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "User");
        }


    }
}