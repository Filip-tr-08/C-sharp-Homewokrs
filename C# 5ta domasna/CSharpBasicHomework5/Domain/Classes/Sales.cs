using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Classes
{
    public class Sales :Employee
    {
        private double _successSaleRevenue { get; set; }
        public Sales(string firstName, string lastName) : base( firstName,lastName)
        {
            Salary = 500;
            Role = RoleEnum.Sales;
            FirstName = firstName;
            LastName = lastName;
        }

        
        public void AddSuccessRevenue(double revenue)
        {
            _successSaleRevenue = revenue;
        }

        public override double GetSalary()
        {
            if (_successSaleRevenue <= 2000)
            {
                return Salary + 500;
            }
            else if (_successSaleRevenue > 2000 && _successSaleRevenue <= 5000)
            {
                return Salary + 800;
            }
            else if (_successSaleRevenue > 5000)
            {
                return Salary + 1500;
            }
            else
            {
                return Salary;
            }
        }
    }
}
