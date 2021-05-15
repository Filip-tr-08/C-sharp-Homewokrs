using CSharpAdvanceHomeworkFive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Domain.Database
{
    public interface IGenericDb<T>where T:BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void RemoveById(int id);
        void Update(T entity);
    }
}
