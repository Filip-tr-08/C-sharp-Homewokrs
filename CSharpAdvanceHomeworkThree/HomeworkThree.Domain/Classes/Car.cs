using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkThree.Domain
{
    public class Car:Vehicle
    {
        public int FuelTank { get; set; }
        public List<string> Countries { get; set; }
        public Car(int id, string type, int year, int batchNumber,int fuel,List<string> countries):base(id,type,year,batchNumber)
        {
            FuelTank = fuel;
            Countries = countries;
        }

        public override void PrintVehicle()
        {
            Console.Write($"{Type} -- ");
            foreach(string country in Countries)
            {
                Console.Write($"{country} ");
            }
            Console.WriteLine();
        }
    }
}
