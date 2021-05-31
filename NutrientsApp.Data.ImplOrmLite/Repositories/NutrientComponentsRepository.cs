using System.Collections.Generic;
using System.Data;
using System.Linq;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities;
using ServiceStack.OrmLite;

namespace NutrientsApp.Data.ImplOrmLite.Repositories
{
    public class NutrientComponentsRepository : Repository<NutrientComponentEntity>, INutrientComponentsRepository<NutrientComponentEntity>
    {
        private readonly OrmLiteConnectionFactory _factory;
        
        public NutrientComponentsRepository(OrmLiteConnectionFactory factory) : base(factory)
        {
            _factory = factory;
        }


        public IList<string> GetAllComponentsNames()
        {
            using (IDbConnection db = _factory.Open())
            {
                return db.Select<string>("SELECT Name FROM NutrientComponents");
            }
        }
    }
}