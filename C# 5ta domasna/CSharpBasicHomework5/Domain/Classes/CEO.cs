using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Classes
{
    public class CEO :Employee
    {
        public Employee[] Employees { get; set; }
        public int Shares { get; set; }
        private double _sharesPrice { get; set; }

        public CEO(string fName, string lName, Employee[] arrayOfEmployees ,double salary, int shares) : base(fName,lName)
        {
            Salary = salary;
            Shares = shares;
            Role = RoleEnum.CEO;
            Employees = arrayOfEmployees;
        }
        public void AddSharesPrice(int price)
        {
            if (price == 0)
            {
                price = 5;
            }
            _sharesPrice += price;
        }
        public void PrintEmployees()
        {
            foreach(Employee employee in Employees)
            {
                Console.WriteLine(employee.GetInfo());
            }
        }
        public override double GetSalary()
        {
            
            return Salary + Shares * _sharesPrice;
        }
    }
}
