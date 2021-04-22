using Homework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Classes
{
    public class Dog : Animal, IDog
    {
        public string Race { get; set; }
        public Dog(string name,string owner,int age,string race):base(name,owner,age)
        {
            Race = race;
        }
        public void Bark()
        {
            Console.WriteLine($"The dog {Name} says bark bark");
        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"Dog = Name: {Name} --- Age: {Age} --- Race: {Race} --- Owner: {Owner} ");

        }
    }
}
