using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;


namespace Domain.Classes
{
   public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public RoleEnum Role { get; set; }

        public Employee()
        {
            Salary = 500;
        }
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = 500;
        }
        public string GetInfo()
        {
            return $"{FirstName} {LastName} {Role}";
        }
        public virtual double GetSalary()
        {
            return Salary;
        }
    }
}
