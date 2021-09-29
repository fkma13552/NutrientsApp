using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.ImplEf.Repositories
{
    public class ProductNutrientsRepository : Repository<ProductNutrientEntity>, IProductNutrientsRepository<ProductNutrientEntity>
    {
        private MyContext _context;
        public ProductNutrientsRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IDictionary<string, int>> GetProductNutrients(Guid id)
        {
            IDictionary<string, int> dictionaryToReturn = new Dictionary<string, int>();

            var prodNutrs = await 
                (from pn in _context.ProductNutrients
                        where pn.ProductId == id
                                join nutrcomp in _context.NutrientComponents 
                                on pn.NutrientId equals nutrcomp.Id 
                                select new {nutrcomp.Name, pn.AmountPerHundred}).ToListAsync();
            if (prodNutrs.Count > 0)
            {
                foreach (var prodNutr in prodNutrs)
                {
                    string name = prodNutr.Name;
                    int amount = prodNutr.AmountPerHundred;
                    dictionaryToReturn.Add(name, amount);
                } 
            }
            
            return dictionaryToReturn;
        }
    }
}