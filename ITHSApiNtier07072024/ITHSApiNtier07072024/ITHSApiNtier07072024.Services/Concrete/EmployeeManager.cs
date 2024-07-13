using ITHSApiNtier07072024.Entities;
using ITHSApiNtier07072024.Repositories.Abstract;
using ITHSApiNtier07072024.Repositories.Concrete;
using ITHSApiNtier07072024.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHSApiNtier07072024.Services.Concrete
{
    public class EmployeeManager : IEmployeeServices
    {
        public readonly IEmployeeRepository employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
                this.employeeRepository = employeeRepository;
        }


        public Employee CreateEmployee(Employee employee)
        {
           if(employee is not null)
            {
                return employeeRepository.CreateEmployee(employee);
            }

           else

            {
                throw new Exception("Employee null olamaz");
            }
        }

        public void DeleteEmployee(int id)
        {
            if (id != 0)
           
                employeeRepository.DeleteEmployee(id);
          else


            throw new Exception("Silme işleminde ID NULL olmamalıdır!");
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        public List<Employee> GetEmployeesByDepartment(string department)
        {

            if(department != null)
                return employeeRepository.GetEmployeesByDepartment(department);
            else

            throw new Exception("Departman adı boş olamaz!...");
        }

        public async Task<Employee> GetEmployeesById(int employeeId)
        {
            if(employeeId>0)
            return await employeeRepository.GetEmployeesById(employeeId);

            else
            throw new Exception("ID parametresi 1 den küçük olamaz!");
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return employeeRepository.UpdateEmployee(employee);
        }
    }
}
