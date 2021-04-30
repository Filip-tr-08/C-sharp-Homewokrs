using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Domain.Classes
{
   public abstract class Shape
    {
        public int Id { get; set; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public Shape(int id)
        {
            Id = id;
        }
    }
}
