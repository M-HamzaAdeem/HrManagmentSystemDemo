using HRMDal.Models;
using HRMDal.Repositories.Interfaces;
using HRMDal.Repositories;
using System.Collections.Generic;


namespace HRMDal.Services
{
    public class EmployeeDal
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeDal()
        {
            _employeeRepository = new EmployeeRepository();
        }


        public Employee GetEmployee(string userName)
        {
            var employee = _employeeRepository.GetByUserName(userName);
            return employee;
        }
        public EmployeeExtendedDto GetExtendedEmployee(string userName)
        {
            var employee = _employeeRepository.GetExtendedByUserName(userName);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _employeeRepository.GetEmployees();
            return employees;
        }

        public IEnumerable<EmployeeExtendedDto> GetAllExtended()
        {
            var employees = _employeeRepository.GetExtendedEmployees();
            return employees;
        }
        public int UpdatePayScale(string userName, PayScale payScale)
        {
            int i = _employeeRepository.UpdatePayScale(userName, payScale);
            return i;

        }
        public int UpdateDepartment(string userName, DepartmentCode departmentCode)
        {
            int i = _employeeRepository.UpdateDepartment(userName, departmentCode);
            return i;

        }

        public int UpdateRo(string userName, string Ro)
        {
            int i = _employeeRepository.UpdateRo(userName, Ro);
            return i;

        }


    }
}
