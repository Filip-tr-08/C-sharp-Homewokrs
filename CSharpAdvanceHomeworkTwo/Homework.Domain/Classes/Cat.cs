using Homework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Classes
{
    public class Cat : Animal, ICat
    {
        public string Color { get; set; }
        public Cat(string name,string owner,int age,string color):base(name,owner,age)
        {
            Color = color;
        }
        public void Eat(string food)
        {
            Console.WriteLine($"The cat {Name} is eating {food}");
        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"Cat = Name: {Name} --- Age: {Age} --- Color: {Color} --- Owner: {Owner} ");
        }
    }
}
