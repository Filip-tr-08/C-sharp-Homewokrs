using System;
using System.Collections.Generic;
using System.Text;
using Task2.Domain.Enums;

namespace Task2.Domain.Classes
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public PetType Type { get; set; }
        public int Age { get; set; }
        public Pet(string name,PetType type,int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }
        public abstract void PrintInfo();
    }
}
