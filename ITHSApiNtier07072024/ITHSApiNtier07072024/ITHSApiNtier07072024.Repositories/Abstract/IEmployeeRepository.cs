using ITHSApiNtier07072024.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHSApiNtier07072024.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Task<Employee> GetEmployeesById(int employeeId);

        List<Employee> GetEmployeesByDepartment(string department);

        Employee CreateEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);

        void DeleteEmployee(int employeeId);
    }
}
