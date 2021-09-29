using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutrientsApp.Domain;
using NutrientsApp.Services.Abstract;

namespace NutrientsApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipesService _recipesService;

        public RecipeController(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recipes = await _recipesService.GetAll();
            if (!recipes.Any())
            {
                return NoContent();
            }
            return Ok(recipes);
        }
        
    }
}