using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutrientsApp.Services.Abstract;

namespace NutrientsApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeNutrientsController : ControllerBase
    {
        private readonly IRecipesService _recipesService;

        public RecipeNutrientsController(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFromMultiple([FromQuery] Guid[] ids)
        {
            if (!ids.Any() || ids.Any(p => p == Guid.Empty))
            {
                return BadRequest(); 
            }

            IDictionary<string, int> allNutrients = new Dictionary<string, int>();
            foreach (var id in ids)
            {
                IDictionary<string, int> nutrients = await _recipesService.GetRecipeNutrients(id);
                foreach (var kv in nutrients)
                {
                    if (allNutrients.ContainsKey(kv.Key))
                    {
                        allNutrients[kv.Key] += kv.Value;
                    }
                    else
                    {
                        allNutrients[kv.Key] = kv.Value;
                    }
                }
            }

            return Ok(allNutrients);
        }
        
        
    }
}