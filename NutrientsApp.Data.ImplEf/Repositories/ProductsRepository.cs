using NutrientsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using NutrientsApp.Data.Abstract.Repositories;

namespace NutrientsApp.Data.ImplEf.Repositories
{
    public class ProductsRepository : Repository<ProductEntity>, IProductsRepository<ProductEntity>
    {
        private MyContext _context;

        public ProductsRepository(MyContext context) : base(context)
        {
            _context = context;
        }

    }
}
