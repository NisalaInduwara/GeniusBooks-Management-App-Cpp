// importing namespaces to work with entity framework
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


// defining the namespace
namespace GrifindoToysPayrollSystem
{
    // defining a class for the employee
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal OvertimeRate { get; set; }
        public decimal Allowances { get; set; }
    }
    
    // Creating a session with the database
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        
        // defining the parameters of the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=GrifindoToysPayrollSystem;Trusted_Connection=True;");
        }
    }
    
    // creating a class for the employee component
    public class EmployeeComponent
    {
        // accessing the database
        private readonly EmployeeContext context;
    public EmployeeComponent()
        {
            // Initialize a new instance of the EmployeeContext class.
            context = new EmployeeContext();
        }
        
        // Register a new employee to the system
        public void RegisterEmployee(Employee employee)
        {
            // Add the employee object to the Employees DbSet in the context.
            context.Employees.Add(employee);
            // Save changes made to the context to the database.
            context.SaveChanges();
        }
        
        // Update an existing employee in the system
        public void UpdateEmployee(Employee employee)
        {
            // getting the emplopyee from database using given ID
            var existingEmployee = context.Employees.Find(employee.Id);
            
            if (existingEmployee != null)
            {
                // updating the all parameters of employee
                existingEmployee.Name = employee.Name;
                existingEmployee.MonthlySalary = employee.MonthlySalary;
                existingEmployee.OvertimeRate = employee.OvertimeRate;
                existingEmployee.Allowances = employee.Allowances;
                
                // saving the changes in the database
                context.SaveChanges();
            }
        }

// Delete an existing employee from the system
        public void DeleteEmployee(int employeeId)
        {
            // acessing the emplopyee from database using given ID
            var employee = context.Employees.Find(employeeId);
            
            if (employee != null)
            { 
                // deleting the relevent employee
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
        
        // Get details of a single employee
        public Employee GetEmployeeDetails(int employeeId)
        {
            return context.Employees.Find(employeeId);
        }
        
        // Get details of all employees
        public List<Employee> GetAllEmployees()
        {
            return context.Employees.ToList();
        }
        
        // Search for employees based on their name
        public List<Employee> SearchEmployees(string keyword)
        {
            return context.Employees.Where(e => e.Name.Contains(keyword)).ToList();
        }
    }
}
