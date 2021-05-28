using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace App
{
   public class Database
    {
        private string _folderPath;
        private string _filePath;
        private int _id;
        public Database()
        {
            _id = 0;
            _folderPath = @"..\..\..\DB";
            _filePath = _folderPath + "\\Dogs.json";
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
            List<Dog> dogs = Read();
            if (dogs == null)
            {
                Write(new List<Dog>());
            }
            else if (dogs.Count > 0)
            {
                _id = dogs[dogs.Count - 1].Id;
            }
        }
        private List<Dog> Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string text = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Dog>>(text);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        private void Write(List<Dog> dogs)
        {
            try { 
                using(StreamWriter sw=new StreamWriter(_filePath))
                {
                    string jsonString = JsonConvert.SerializeObject(dogs);
                    sw.WriteLine(jsonString);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                    return;
            }
        }
        public List<Dog> GetAll()
        {
            return Read();
        }
        public Dog GetById(int id)
        {
            return Read().SingleOrDefault(x => x.Id == id);
        }
        public int InsertDog(Dog dog)
        {
            List<Dog> dogs = Read();
            _id++;
            dog.Id = _id;
            dogs.Add(dog);
            Write(dogs);
            return dog.Id;
        }
        private void ClearDb()
        {
            Write(new List<Dog>());
        }
        private void DeleteOneDog(int id)
        {
            List<Dog> dogs = Read();
           Dog dogForRemoving= GetById(id);
            dogs.Remove(dogForRemoving);
            Write(dogs);
        }
    }
}
