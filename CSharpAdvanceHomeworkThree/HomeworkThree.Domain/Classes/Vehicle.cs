using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkThree.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int YearOfProduction { get; set; }
        public int BatchNumber { get; set; }
        public Vehicle(int id,string type,int year,int batchNumber)
        {
            Id = id;
            Type = type;
            YearOfProduction = year;
            BatchNumber = batchNumber;
        }

        public virtual void PrintVehicle()
        {
            Console.WriteLine($"{Id}. {Type} -- {YearOfProduction}");
        }

    }
}
