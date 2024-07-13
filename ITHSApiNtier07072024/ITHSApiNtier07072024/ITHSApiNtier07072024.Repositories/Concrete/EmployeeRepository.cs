using ITHSApiNtier07072024.Entities;
using ITHSApiNtier07072024.Repositories.Abstract;
using ITHSApiNtier07072024.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHSApiNtier07072024.Repositories.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }


        public Employee CreateEmployee(Employee employee)
        {
            context.Employees.Add(employee); 
            context.SaveChanges();  
            return employee;
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = context.Employees.SingleOrDefault(x => x.ID == employeeId);
            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            return context.Employees.ToList();  
        }

        public List<Employee> GetEmployeesByDepartment(string department)
        {
            var employeeList = context.Employees.Where(x => x.Department.ToLower().Contains(department.ToLower())).ToList(); 
            return employeeList;    
        }

        public async Task<Employee> GetEmployeesById(int employeeId)
        {
            return await context.Employees.FindAsync(employeeId);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
            return employee;
        }
    }
}
