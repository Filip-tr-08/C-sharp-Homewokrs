using Homework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Classes
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Age{get;set;}
        public abstract void PrintAnimal();
        public Animal(string name,string owner,int age)
        {
            Name = name;
            Owner = owner;
            Age = age;
        }
        
    }
}
