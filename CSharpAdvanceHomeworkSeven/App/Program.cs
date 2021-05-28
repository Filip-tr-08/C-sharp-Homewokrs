using Domain;
using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        public static Database DogsDb = new Database();
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            while (true)
            {
                Console.WriteLine("Enter dog data:");
                bool flagName = true;
                while (flagName)
                {
                    Console.WriteLine("Enter name");
                    string name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Invalid name");
                        flagName = true;
                    }
                    else
                    {
                        dog.Name = name;
                        flagName = false;
                    }
                }
                bool flagColor = true;
                while (flagColor)
                {
                    Console.WriteLine("Enter color");
                    string color = Console.ReadLine();
                    if (string.IsNullOrEmpty(color))
                    {
                        Console.WriteLine("Invalid color");
                        flagColor = true;
                    }
                    else
                    {
                        dog.Color = color;
                        flagColor = false;
                    }
                }
                bool flagAge = true;
                while (flagAge)
                {
                    Console.WriteLine("Enter age");
                    bool success = int.TryParse(Console.ReadLine(), out int age);
                    if (success)
                    {
                        dog.Age = age;
                        flagAge = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid age");
                        flagAge = true;
                    }
                }
                DogsDb.InsertDog(dog);     
                Console.WriteLine("do you want to enter another dog? y/n");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            List<Dog>dogs=DogsDb.GetAll();
            Console.WriteLine("Dogs data:");
            foreach(Dog d in dogs)
            {
                Console.WriteLine($"NAME: {d.Name} COLOR: {d.Color} AGE: {d.Age}");
            }
            Console.ReadLine();
        }
    }
}
