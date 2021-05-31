using System.Collections.Generic;
using System.Linq;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.ImplEf.Repositories
{
    public class NutrientComponentsRepository : Repository<NutrientComponentEntity>, INutrientComponentsRepository<NutrientComponentEntity>
    {
        private MyContext _context;
        
        public NutrientComponentsRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public IList<string> GetAllComponentsNames()
        {
            return _context.NutrientComponents.Select(c => c.Name).ToList();
        }
    }
}