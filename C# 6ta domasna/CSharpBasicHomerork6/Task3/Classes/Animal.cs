using System;
using System.Collections.Generic;
using System.Text;
using Task3.Enums;

namespace Task3.Classes
{
    public class Animal
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }

        public Animal(string name,string color,int age, GenderEnum gender )
        {
            Name = name;
            Color = color;
            Age = age;
            Gender = gender;
        }
    }
}
