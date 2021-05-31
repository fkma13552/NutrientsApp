using NutrientsApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NutrientsApp.Data.Abstract.Repositories;
using ServiceStack.OrmLite;

namespace NutrientsApp.Data.ImplOrmLite.Repositories
{
    public class ProductsRepository : Repository<ProductEntity>, IProductsRepository<ProductEntity>
    {
        private readonly OrmLiteConnectionFactory _factory;

        public ProductsRepository(OrmLiteConnectionFactory factory) : base(factory)
        {
            _factory = factory;
        }

    }
}
