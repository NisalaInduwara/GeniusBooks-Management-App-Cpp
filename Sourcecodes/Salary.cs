// defining a class for salary component
    public class SalaryComponent
    {
        private readonly EmployeeContext context;

        public SalaryComponent()
        {
            context = new EmployeeContext();
        }

        // method to calculate the nopay value
        public decimal CalculateNoPayValue(int employeeId, DateTime startDate, DateTime endDate, int noOfAbsentDays){

            // getting the employee details using ID
            var employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);
            // checking whther the employee is exist
            if (employee == null)
            {
                Console.WriteLine("Invalid employee ID.");
                return 0;
            }

            decimal noPayValue = 0;
        
            if (noOfAbsentDays > 0)
            {
                decimal totalSalary = employee.MonthlySalary + employee.Allowances;
                int totalDays = (int)(endDate - startDate).TotalDays;
                decimal salaryPerDay = totalSalary / totalDays;
            
                noPayValue = salaryPerDay * noOfAbsentDays;
            }
        
            return noPayValue;
        }






        // method to calculate the base pay value
        public decimal CalculateBasepay(int employeeId, int noOfAbsentDays){

            // getting the employee details using ID
            var employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);
             // checking whther the employee is exist
                if (employee == null)
                {
                    Console.WriteLine("Invalid employee ID.");
                    return 0;
                }

            decimal basePay = 0;

            // calculating the base pay value
            basePay = employee.MonthlySalary + employee.Allowances + employee.OvertimeRate*noOfAbsentDays;

            return basePay;
        }

        // method to calculate the gross pay value
        public decimal CalculateGrosspay(int employeeId, int taxRate, decimal basePay, decimal noPayValue){

             // getting the employee details using ID
            var employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);
             // checking whther the employee is exist
            if (employee == null)
            {
                Console.WriteLine("Invalid employee ID.");
                return 0;
            }

            decimal grossPay;

            // calculating the gross pay value
            grossPay = basePay - (noPayValue + basePay*taxRate);

            return grossPay;
        }



        // method to store the salary into the database
        public void storeSalary(int employeeId, decimal noPayvalue, decimal BasePay, decimal grossPay, DateTime month){

            // getting the employee details using ID
            var employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);
            // checking whther the employee is exist
            if (employee == null)
            {
                Console.WriteLine("Invalid employee ID.");
                return;
            }
 
            // assigning values into the parameters
            var salary = new Salary{
                Id = employee.Id,
                month = month,
                NoPayValue = noPayvalue,
                BasePayValue = BasePay,
                GrossPay = grossPay
            };

            // adding salary
            context.Salaries.Add(salary);
            // save changes
            context.SaveChanges();
        }


        // method to print the salary report
        public void PrintSalaryReport(int employeeId, DateTime month){
            
            // getting the employee details using ID
            var employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);
            // checking whther the employee is exist
            if (employee == null)
            {
                Console.WriteLine("Invalid employee ID.");
                return;
            }




            // getting the salary details using ID
            var salary = context.Salaries.FirstOrDefault(s => s.Id == employeeId && s.month == month);
            // checking whther the employee is exist
            if (salary == null)
            {
                Console.WriteLine($"No salary information found for employee {employee.Name} in {month.ToString("MMMM yyyy")}.");
                return;
            }

            // printing the salary report
            Console.WriteLine($"Salary Report for {employee.Name} - {month.ToString("MMMM yyyy")}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Monthly Salary: {employee.MonthlySalary:C}");
            Console.WriteLine($"Allowances: {employee.Allowances:C}");
            Console.WriteLine($"Overtime Rate: {employee.OvertimeRate:C}/hour");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Base Pay: {salary.BasePayValue:C}");
            Console.WriteLine($"No Pay Deduction: {salary.NoPayValue:C}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Gross Pay: {salary.GrossPay:C}");
            Console.WriteLine("----------------------------------------------");
        }
    }

