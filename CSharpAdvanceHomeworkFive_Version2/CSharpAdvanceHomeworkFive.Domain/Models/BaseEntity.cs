using CSharpAdvanceHomeworkFive.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Domain.Models
{
    public abstract class BaseEntity: IBaseEntity
    {
        public int Id { get; set; }


        public abstract string GetInfo();
    }
}
