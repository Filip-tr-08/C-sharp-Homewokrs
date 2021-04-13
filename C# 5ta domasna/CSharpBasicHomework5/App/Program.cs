using System;
using Domain.Classes;
using Domain.Enums;
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager bob = new Manager("Bob", "Bobert","Development department",1200);
            Manager rick = new Manager("Rick", "Rickert","HR department",1300);
            Contratcor mona = new Contratcor("Mona", "Monalisa", 20.5, 70, bob);
            Contratcor igor = new Contratcor("Igor", "Igorsky", 12.2, 80, rick);
            Sales lea = new Sales("Lea", "Leova");
            lea.AddSuccessRevenue(1800);

            Employee[] employees = new Employee[] { bob, rick, mona, igor, lea };
            
            Console.WriteLine($"{mona.GetInfo()} - salary: {mona.Salary}$ - department: {mona.CurrentPossition()}");

            Console.WriteLine("----------------");

            CEO ceo = new CEO("Ron", "Ronsky",employees ,1500, 140);
            ceo.AddSharesPrice(10);
            Console.WriteLine($"{ceo.GetInfo()} - salary: {ceo.Salary}");
            Console.WriteLine($"Salary of CEO is: {ceo.GetSalary()}");
            Console.WriteLine("Employees:");
            ceo.PrintEmployees();
            Console.ReadLine();
           

        }
    }

}


