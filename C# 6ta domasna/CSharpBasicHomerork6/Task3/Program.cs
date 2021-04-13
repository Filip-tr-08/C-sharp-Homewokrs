using System;
using System.Collections.Generic;
using System.Linq;
using Task3.Classes;
using Task3.Enums;
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal("Bear", "brown", 4, GenderEnum.Female));
            animals.Add(new Animal("Ant", "black", 1, GenderEnum.Female));
            animals.Add(new Animal("Dalmadoodle", "white", 6, GenderEnum.Male));
            animals.Add(new Animal("Aligator", "green", 7, GenderEnum.Male));
            animals.Add(new Animal("Squirrel", "brown", 2, GenderEnum.Female));
            animals.Add(new Animal("Tiger", "brown", 8, GenderEnum.Male));
            animals.Add(new Animal("Tortoise", "green", 15, GenderEnum.Female));
            animals.Add(new Animal("Lion", "brown", 8, GenderEnum.Male));
            animals.Add(new Animal("Cat", "black", 5, GenderEnum.Female));
            animals.Add(new Animal("Monkey", "grey", 3, GenderEnum.Male));

            List<Animal> animalsAged5 = (animals.Where(a => a.Age >= 5)).ToList();
            List<Animal> animalsStartsWithA = (animals.Where(a=>a.Name.StartsWith("A"))).ToList();
            List<Animal> animalsMaleBrown = (animals.Where(a => a.Gender == GenderEnum.Male && a.Color == "brown")).ToList();
            Animal animalFirst10Characters = animals.FirstOrDefault(a => a.Name.Length > 10);
            Console.WriteLine("All the Animals: ");
            foreach(Animal animal in animals)
            {
                Console.WriteLine(animal.Name);
            }
            Console.WriteLine("======================");
            Console.WriteLine("All the Animals aged 5 or more: ");
            foreach (Animal animal in animalsAged5)
            {
                Console.WriteLine(animal.Name);
            }
            Console.WriteLine("======================");
            Console.WriteLine("All the Animals whose name starts with 'A' ");
            foreach (Animal animal in animalsStartsWithA)
            {
                Console.WriteLine(animal.Name);
            }
            Console.WriteLine("======================");
            Console.WriteLine("All the brown male Animals: ");
            foreach (Animal animal in animalsMaleBrown)
            {
                Console.WriteLine(animal.Name);
            }
            Console.WriteLine("======================");
            Console.WriteLine("The first Animal whose name is longer than 10 characters: ");
            Console.WriteLine(animalFirst10Characters.Name);
        }
    }
}
