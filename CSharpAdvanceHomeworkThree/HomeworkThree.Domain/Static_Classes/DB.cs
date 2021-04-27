using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkThree.Domain.Static_Classes
{
    public static class VehicleDB
    {
        public static List<Vehicle> VehicleList { get; set; }
        static VehicleDB()
        {
            VehicleList = new List<Vehicle>()
            {
                new Car(1,"BMW",2004,234,6,new List<string>(){ "Germany","France"}),
                new Car(2,"Ford",2012,578,8,new List<string>(){ "England","Belgium"}),
                new Car(3,"Ford",0,578,8,new List<string>(){ "England","Belgium"}),
                new Bike(4,"Santa Cruz",2018,147,"Black"),
                new Bike(5,"GT",2020,532,"White"),
                new Vehicle(6,"Some Vehicle",2013,763)
            };
        }
    }
}
