using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;

namespace NutrientsApp.Data.ImplOrmLite.Repositories
{
    public class ProductNutrientsRepository : Repository<ProductNutrientEntity>, IProductNutrientsRepository<ProductNutrientEntity>
    {
        private readonly OrmLiteConnectionFactory _factory;
        public ProductNutrientsRepository(OrmLiteConnectionFactory factory) : base(factory)
        {
            _factory = factory;
        }


        public IDictionary<string, int> GetProductNutrients(Guid id)
        {
            IDictionary<string, int> dictionaryToReturn = new Dictionary<string, int>();
            IList <(string, int)> prodNutrs = new List<(string, int)>();
            using (IDbConnection db = _factory.Open())
            {
                var q = db.From<ProductNutrientEntity>()
                    .Join<ProductNutrientEntity, NutrientComponentEntity>((pn, n) => pn.NutrientId == n.Id)
                    .Where(p => p.ProductId == id)
                    .Select<ProductNutrientEntity, NutrientComponentEntity>((pn, n) => new {n.Name, pn.AmountPerHundred});
                //prodNutrs = db.Query<(string, int)>("SELECT NutrientComponents.Name, ProductNutrients.AmountPerHundred FROM NutrientComponents WHERE ProductNutrients.ProductId = @id INNER JOIN ProductNutrients ON ProductNutrients.NutrientId=NutrientComponents.Id", new{id = id}).ToList();
                prodNutrs = db.Select<(string, int)>(q);
            }

            if (prodNutrs.Count > 0)
            {
                foreach (var prodNutr in prodNutrs)
                {
                    string name = prodNutr.Item1;
                    int amount = prodNutr.Item2;
                    dictionaryToReturn.Add(name, amount);
                }
            }

            return dictionaryToReturn;
        }
    }
}