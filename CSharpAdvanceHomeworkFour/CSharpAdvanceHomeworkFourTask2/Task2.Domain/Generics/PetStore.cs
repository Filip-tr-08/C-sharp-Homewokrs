using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task2.Domain.Classes;

namespace Task2.Domain.Generics
{
    public static class PetStore<T>where T:Pet
    {
        public static List<T> Pets;
        static PetStore()
        {
            Pets = new List<T>();
        }
        public static void PrintPets()
        {
            foreach(T pet in Pets)
            {
                pet.PrintInfo();
            }
        }
        public static void BuyPet(string name)
        {
            T pet = Pets.FirstOrDefault(p => p.Name == name);
            if (pet == null)
            {
                Console.WriteLine($"Sorry in the moment we don't have a pet with the name {name}");
            }
            else
            {
                Pets.Remove(pet);
                Console.WriteLine("The pet is bought succesfully");
            }
        }
    }
}
