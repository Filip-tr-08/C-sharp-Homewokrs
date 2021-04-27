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
               
            }
            
            Console.WriteLine($"The vehicle {VehicleDB.VehicleList[0].Type} is well implemented in the list : {Vallidator.Validate(VehicleDB.VehicleList[0])}");
            Console.WriteLine($"The vehicle {VehicleDB.VehicleList[1].Type} is well implemented in the list : {Vallidator.Validate(VehicleDB.VehicleList[1])}");
            Console.WriteLine($"The vehicle {VehicleDB.VehicleList[2].Type} is well implemented in the list : {Vallidator.Validate(VehicleDB.VehicleList[2])}");
            Console.WriteLine($"The vehicle {VehicleDB.VehicleList[3].Type} is well implemented in the list : {Vallidator.Validate(VehicleDB.VehicleList[3])}");
            Console.WriteLine($"The vehicle {VehicleDB.VehicleList[4].Type} is well implemented in the list : {Vallidator.Validate(VehicleDB.VehicleList[4])}");
            Console.WriteLine($"The vehicle {VehicleDB.VehicleList[5].Type} is well implemented in the list : {Vallidator.Validate(VehicleDB.VehicleList[5])}");


        }
    }
}
