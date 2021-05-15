using CSharpAdvanceHomeworkFive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceHomeworkFive.Domain.Database
{
    public class GenericDB<T>:IGenericDb<T> where T:BaseEntity
    {
        private List<T> _table { get; set; }
        public  int Id { get; set; }
        public GenericDB() {
            _table = new List<T>();
            Id = 1;
        }
        public List<T> GetAll()
        {
            return _table;
        }
        public T GetById(int id)
        {
            try
            {
                T dbEntity = _table.FirstOrDefault(x => x.Id == id);
                if (dbEntity == null)
                {
                    throw new Exception($"Entity with id {id} doesn't exists");
                }
                return dbEntity;
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return null;
            }
        }
        public int Insert(T entity)
        {
            entity.Id = Id++;
            _table.Add(entity);
            return entity.Id;
        }
        public void RemoveById(int id)
        {
            T dbEntity = _table.FirstOrDefault(x => x.Id == id);
            if(dbEntity == null)
            {
                throw new Exception($"Entity with id {id} doesn't exists ");
            }
            _table.Remove(dbEntity);
        }
        public void Update(T entity)
        {
            T dbEntity = _table.FirstOrDefault(x => x.Id == entity.Id);
            if (dbEntity == null)
            {
                throw new Exception($"Entity with id {entity.Id} doesn't exists ");
            }
            dbEntity = entity;
        }
    }
}
