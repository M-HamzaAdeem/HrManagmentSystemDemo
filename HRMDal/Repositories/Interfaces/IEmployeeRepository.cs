using HRMDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMDal.Repositories.Interfaces
{
    internal interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        IEnumerable<EmployeeExtendedDto> GetExtendedEmployees();
        Employee GetById(int id);

        Employee GetByUserName(string userName);
        EmployeeExtendedDto GetExtendedByUserName(string userName);

        int UpdateDepartment(string userName, DepartmentCode departmentCode);
        int UpdatePayScale(string userName, PayScale payScale);

        int UpdateRo(string userName, string Ro);

    }
}
