using System;

namespace NutrientsApp.Entities.Abstract
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}