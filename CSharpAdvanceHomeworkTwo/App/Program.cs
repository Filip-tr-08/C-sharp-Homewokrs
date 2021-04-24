using Homework.Domain.Classes;
using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            string catFood = "cat food";
            Dog tifa=new Dog("Tifa", "Petko", 8, "Dobermann");
            Dog max=new Dog("Max", "Stanko", 4, "Golden Retriever");
            Cat maca=new Cat("Maca", "Jane", 6, "Brown");
            Cat mimi=new Cat("Mimi", "James", 2, "Black");
            tifa.PrintAnimal();
            max.Bark();
            maca.PrintAnimal();
            mimi.Eat(catFood);
            List<Animal> animals = new List<Animal>
            {
                tifa,
                max,
                maca,
                mimi
            };
            try
            {
                if (animals != null)
                {
                    foreach (Animal animal in animals)
                    {
                        animal.PrintAnimal();
                        if (animal.GetType() == typeof(Dog))
                        {
                            ((Dog)animal).Bark();
                        }
                        else if (animal.GetType() == typeof(Cat))
                        {
                            ((Cat)animal).Eat(catFood);
                        }
                        else
                        {
                            throw new Exception("There are not any cats or dogs in the list");
                        }
                    }
                }
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
