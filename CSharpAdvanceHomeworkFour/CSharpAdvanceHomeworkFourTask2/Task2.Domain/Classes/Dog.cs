using System;
using System.Collections.Generic;
using System.Text;
using Task2.Domain.Enums;

namespace Task2.Domain.Classes
{
    public class Dog : Pet
    {
        public string FavouriteFood { get; set; }
        public Dog(string name, PetType type, int age, string favouriteFood) : base(name, type, age)
        {
            FavouriteFood = favouriteFood;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name} -- type: {Type} -- age:{Age} -- Favourite food: {FavouriteFood}");
        }
    }
}
