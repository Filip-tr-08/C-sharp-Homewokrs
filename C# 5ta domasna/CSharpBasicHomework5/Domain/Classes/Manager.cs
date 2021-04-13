using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Classes
{
   public class Manager: Employee
    {
        public string Department { get; set; }
        private double _bonus { get; set; }
        public Manager(string firstName, string lastName, string department, double salary) : base(firstName, lastName)
        {
           
            Salary = salary;
            Department = department;
            _bonus = 0;
            Role = RoleEnum.Manager;
        }

        public void AddBonus(double bonus)
        {
            _bonus += bonus;
        }

        public override double GetSalary()
        {
            return Salary + _bonus;
        }
    }
}
