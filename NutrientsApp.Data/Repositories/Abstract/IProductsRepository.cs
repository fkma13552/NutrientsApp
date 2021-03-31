using System;
using NutrientsApp.Entities.Abstract;
using System.Collections.Generic;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.Repositories.Abstract
{
    public interface IProductsRepository<T>: IRepository<T> where T: IProductEntity
    {

    }
}
