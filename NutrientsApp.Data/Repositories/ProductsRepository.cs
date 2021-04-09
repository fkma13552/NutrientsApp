using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NutrientsApp.Data.Repositories
{
    public class ProductsRepository : Repository<ProductEntity>, IProductsRepository<ProductEntity>
    {
        private NutrientsContext _context;

        public ProductsRepository(NutrientsContext context) : base(context)
        {
            _context = context;
        }

    }
}
