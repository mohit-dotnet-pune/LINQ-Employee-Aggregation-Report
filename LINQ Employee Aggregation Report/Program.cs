using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Employee_Aggregation_Report
{
    class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employees> employees = new List<Employees>()
            {
                new Employees{Id=1,Name="Mohit",Department="CSE",Salary=60000,Age=21},
                new Employees{Id=2,Name="Rohan",Department="IT",Salary=50000,Age=23},
                new Employees{Id=3,Name="Vaibhav",Department="CSE",Salary=100000,Age=29},
                new Employees{Id=4,Name="Uttam",Department="IT",Salary=70000,Age=22},
                new Employees{Id=5,Name="Shriyash",Department="Devops",Salary=60000,Age=24},  
            };

            Console.WriteLine("Total employees : "+employees.Count());
            Console.WriteLine("Sum : " + employees.Sum(e => e.Salary));
            Console.WriteLine("Average : "+employees.Average(e=>e.Salary));
            Console.WriteLine("Youngest employee : "+employees.Min(e => e.Age));
            Console.WriteLine("Oldest employee : "+employees.Max(e => e.Age));

            Console.WriteLine();

            var deptStats = employees.GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    TotalEmployees = g.Count(),
                    AverageSalary = g.Average(e => e.Salary),
                    MinSalary = g.Min(e => e.Salary),
                    MaxSalary = g.Max(e => e.Salary)
                }
                );

            Console.WriteLine("\n=== Department-wise Statistics ===");

            foreach (var dept in deptStats)
            {
                Console.WriteLine($"\nDepartment: {dept.Department}");
                Console.WriteLine($" Total Employees: {dept.TotalEmployees}");
                Console.WriteLine($" Average Salary: {dept.AverageSalary}");
                Console.WriteLine($" Minimum Salary: {dept.MinSalary}");
                Console.WriteLine($" Maximum Salary: {dept.MaxSalary}");
            }
        }
    }
}
