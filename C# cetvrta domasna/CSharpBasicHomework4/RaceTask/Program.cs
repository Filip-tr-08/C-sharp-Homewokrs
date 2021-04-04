using System;
using RaceTask.Models;
namespace RaceTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver[] drivers = new Driver[] {
            new Driver("Bob", 5),
            new Driver("Greg", 7),
            new Driver("Jill", 6),
            new Driver("Anne", 8)
        };
            Car[] cars = new Car[] {
                new Car("Hyundai", 200),
                new Car("Mazda", 180),
                new Car("Ferrari", 280),
                new Car("Porsche", 300)
            };
            bool again = false;
            do
            {
                Console.WriteLine("Please choose the car for the first user:");
                foreach (Car car in cars)
                {
                    Console.WriteLine(car.Model);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                string firstCar = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                string firstModel = "";
                int firstSpeed = 0;
                int numOfCars = 0;
                Car[] newCars = new Car[] { };
                for (int i = 0; i < cars.Length; i++)
                {
                    if (firstCar.ToLower() == cars[i].Model.ToLower())
                    {
                        firstModel = cars[i].Model;
                        firstSpeed = cars[i].Speed;
                        continue;
                    }
                    else if (firstCar.ToLower() != cars[i].Model.ToLower())
                    {
                        Array.Resize(ref newCars, newCars.Length + 1);
                        newCars[numOfCars++] = cars[i];
                    }
                }
                if (cars.Length == newCars.Length)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is not such a car");
                Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                Console.WriteLine("Please choose the driver for the first user:");
                foreach (Driver driver in drivers)
                {
                    Console.WriteLine(driver.Name);
                }
                string firstName = "";
                int firstSkill = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                string firstDriverName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                int numOfDrivers = 0;
                Driver[] newDrivers = new Driver[] { };
                for (int i = 0; i < cars.Length; i++)
                {
                    if (firstDriverName.ToLower() == drivers[i].Name.ToLower())
                    {
                        firstName = drivers[i].Name;
                        firstSkill = drivers[i].skill;
                        continue;
                    }
                    else if (firstDriverName.ToLower() != drivers[i].Name.ToLower())
                    {
                        Array.Resize(ref newDrivers, newDrivers.Length + 1);
                        newDrivers[numOfDrivers++] = drivers[i];
                    }
                }
                if (drivers.Length == newDrivers.Length)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is not such a driver");
                Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                Console.WriteLine("Please choose the car for the second user:");
                foreach (Car car in newCars)
                {
                    Console.WriteLine(car.Model);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                string secondCar = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                string secondModel = "";
                int secondSpeed = 0;
                for (int i = 0; i < newCars.Length; i++)
                {
                    if (secondCar.ToLower() == newCars[i].Model.ToLower())
                    {
                        secondModel = newCars[i].Model;
                        secondSpeed = newCars[i].Speed;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (secondModel == "" && secondSpeed == 0)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is not such a car");
                Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                Console.WriteLine("Please choose the driver for the second user:");
                foreach (Driver driver in newDrivers)
                {
                    Console.WriteLine(driver.Name);
                }
                string secondName = "";
                int secondSkill = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                string secondDriverName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < newDrivers.Length; i++)
                {
                    if (secondDriverName.ToLower() == newDrivers[i].Name.ToLower())
                    {
                        secondName = newDrivers[i].Name;
                        secondSkill = newDrivers[i].skill;
                        break;
                    }
                    else if (secondDriverName.ToLower() != newDrivers[i].Name.ToLower())
                    {
                        continue;
                    }
                }
                if (secondName == "" && secondSkill == 0)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is not such a driver");
                Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                Driver firstUserDriver = new Driver(firstName, firstSkill);
                Driver secondUseDriver = new Driver(secondName, secondSkill);
                Car firstCarDriver = new Car(firstModel, firstSpeed, firstUserDriver);
                Car secondCarDriver = new Car(secondModel, secondSpeed, secondUseDriver);
                RaceCars(firstCarDriver, secondCarDriver);
                Console.WriteLine("Do you want to race again (y or n)");
                string answer = Console.ReadLine();
                if (answer != "y")
                {
                    Console.WriteLine("Okey GoodBye then");
                    break;
                }
                else
                {
                    Console.Clear();
                    again = true;
                    Console.WriteLine("Let's start again");
                }
            } while (again == true);
            Console.ReadLine();
        }
        static void RaceCars(Car car1, Car car2)
        {
            int faster = car1.CalculateSpeed(car1.Driver) - car2.CalculateSpeed(car2.Driver);
            if (faster == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("It is a draw");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (faster < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The Car No.2 ( Model:{car2.Model} Driver: {car2.Driver.Name}) was faster with speed: {car2.CalculateSpeed(car2.Driver)}km/h");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (faster > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"The Car No.1 ( Model:{car1.Model} Driver: {car1.Driver.Name}) was faster with speed: {car1.CalculateSpeed(car1.Driver)}km/h");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
