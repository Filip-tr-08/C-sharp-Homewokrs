using System;
using Task2.Domain.Classes;
using Task2.Domain.Enums;
using Task2.Domain.Generics;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog("dog1", PetType.Dog, 4, "bones");
            Dog dog2 = new Dog("dog2", PetType.Dog, 6, "meat");

            Cat cat1 = new Cat("cat1", PetType.Cat, 2, true, 5);
            Cat cat2 = new Cat("cat2", PetType.Cat, 2, false, 8);

            Fish fish1 = new Fish("fish1", PetType.Fish, 1, "red", 20);
            Fish fish2 = new Fish("fish2", PetType.Fish, 2, "blue", 15);
            PetStore<Dog>.Pets.Add(dog1);
            PetStore<Dog>.Pets.Add(dog2);

            PetStore<Cat>.Pets.Add(cat1);
            PetStore<Cat>.Pets.Add(cat2);

            PetStore<Fish>.Pets.Add(fish1);
            PetStore<Fish>.Pets.Add(fish2);

            Console.WriteLine("Before buying the dog");
            PetStore<Dog>.PrintPets();
            PetStore<Dog>.BuyPet("dog1");
            PetStore<Dog>.BuyPet("dog3");
            Console.WriteLine("After buying the dog");
            PetStore<Dog>.PrintPets();

            Console.WriteLine("Before buying the cat");
            PetStore<Cat>.PrintPets();
            PetStore<Cat>.BuyPet("cat1");
            Console.WriteLine("After buying the cat");
            PetStore<Cat>.PrintPets();

            Console.WriteLine("Fish Store:");
            PetStore<Fish>.PrintPets();
        }
    }
}
