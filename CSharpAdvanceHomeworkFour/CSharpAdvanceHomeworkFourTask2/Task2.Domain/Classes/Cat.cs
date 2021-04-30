using System;
using System.Collections.Generic;
using System.Text;
using Task2.Domain.Enums;

namespace Task2.Domain.Classes
{
   public class Cat:Pet
    {
        public bool Lazy { get; set; }
        public int LivesLeft { get; set; }

        public Cat(string name, PetType type, int age,bool lazy, int lives):base(name,type,age)
        {
            Lazy = lazy;
            LivesLeft = lives;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name} -- type: {Type} -- age:{Age} -- lazy: {Lazy} -- Lives left:{LivesLeft} ");
        }
    }
}
