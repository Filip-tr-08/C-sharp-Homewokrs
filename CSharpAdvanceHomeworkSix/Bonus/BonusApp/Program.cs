using Domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace BonusApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\People";
            string filePath = folderPath + @"\listOfPeople.txt";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            WriteReadPeople(filePath);
            Console.ReadLine();
        }
        public static void WriteReadPeople(string filePath)
        {
            List<Person> people = new List<Person>()
            {
                new Person{ FirstName="Paul", LastName="Paulsky", Age=20 },
                new Person{ FirstName="Bob", LastName="Bobsky", Age=30 }
            };
            List<Person> newPeople = new List<Person>();
            using (StreamWriter sw=new StreamWriter(filePath))
            {
                foreach(Person person in people)
                {
                    sw.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");
                }
                Console.WriteLine("All people are written in the txt file");
            }
           using (StreamReader sr=new StreamReader(filePath))
            {
                for(int i = 0; i < people.Count; i++)
                {
                    string personFromTxt = sr.ReadLine();
                    string[] personFromTxtSplit = personFromTxt.Split(" ");
                    newPeople.Add(new Person { FirstName = personFromTxtSplit[0], LastName = personFromTxtSplit[1], Age=int.Parse(personFromTxtSplit[2]) });
                }
            }
            Console.WriteLine("Copy of the list of people:");
            foreach(Person person in newPeople)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");
            }
        }
    }
}
