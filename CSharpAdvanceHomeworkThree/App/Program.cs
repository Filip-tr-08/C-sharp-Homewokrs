using System;
using HomeworkThree.Domain;
using HomeworkThree.Domain.Static_Classes;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Vehicle vehicle in VehicleDB.VehicleList)
            {

                vehicle.PrintVehicle();
                Console.WriteLine($"The vehicle {vehicle.Type} is well implemented in the list : {Vallidator.Validate(vehicle)}");
            }
        }
    }
}
