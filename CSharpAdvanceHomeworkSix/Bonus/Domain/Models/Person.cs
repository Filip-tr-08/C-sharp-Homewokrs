using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("[ERROR] Age must be greater than 0");
                _age = value;
            }
        }
    }
}
