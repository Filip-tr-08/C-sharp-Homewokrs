using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Classes
{
   public class Contratcor :Employee
    {
        public double WorkHours { get; set; }
        public int PayPerHour { get; set; }
        public Manager Responsible { get; set; }

        public override double GetSalary()
        {
            return WorkHours * PayPerHour;
        }

        public Contratcor(string fName, string lName, double WH, int payHour, Manager responsible) : base( fName, lName)
        {
            WorkHours = WH;
            PayPerHour = payHour;
            Responsible = responsible;
            Role = RoleEnum.Contractor;
            Salary = GetSalary();
        }
        public string CurrentPossition()
        {
            if (Responsible == null)
            {
                return "Uknown";
            }
            return Responsible.Department;
        }

    }
}
