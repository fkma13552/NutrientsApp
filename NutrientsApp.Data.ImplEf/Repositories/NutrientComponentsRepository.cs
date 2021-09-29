using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IList<string>> GetAllComponentsNames()
        {
            return await _context.NutrientComponents.Select(c => c.Name).ToListAsync();
        }
    }
}