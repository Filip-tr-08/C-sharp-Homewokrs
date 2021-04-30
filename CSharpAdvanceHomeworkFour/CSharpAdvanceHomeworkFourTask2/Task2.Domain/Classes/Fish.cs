using System;
using System.Collections.Generic;
using System.Text;
using Task2.Domain.Enums;

namespace Task2.Domain.Classes
{
   public class Fish:Pet
    {
        public string Color { get; set; }
        public int Size { get; set; }
        public Fish(string name, PetType type, int age,string color,int size):base(name,type,age)
        {
            Color = color;
            Size = size;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name} -- type: {Type} -- age:{Age} -- color: {Color} -- size: {Size} ");

        }
    }
}
