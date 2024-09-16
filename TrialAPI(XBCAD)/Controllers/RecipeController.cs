using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using TrialAPI_XBCAD_.Services;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public RecipesController()
        {
            _firebaseService = new FirebaseService();
        }

        // 1. Get all cuisines
        [HttpGet("cuisines")]
        public async Task<IActionResult> GetCuisines()
        {
            var firebaseClient = _firebaseService.GetFirebaseClient();
            var cuisines = await firebaseClient
                .Child("cuisines")
                .OnceAsync<Dictionary<string, object>>();

            var cuisineList = new List<string>();
            foreach (var cuisine in cuisines)
            {
                cuisineList.Add(cuisine.Key);
            }

            return Ok(cuisineList);
        }

        // 2. Get all recipes under a specific cuisine
        [HttpGet("cuisines/{cuisineName}/recipes")]
        public async Task<IActionResult> GetRecipesByCuisine(string cuisineName)
        {
            var firebaseClient = _firebaseService.GetFirebaseClient();
            var recipes = await firebaseClient
                .Child($"cuisines/{cuisineName}/recipes")
                .OnceAsync<Dictionary<string, object>>();

            var recipeList = new List<string>();
            foreach (var recipe in recipes)
            {
                recipeList.Add(recipe.Key);
            }

            return Ok(recipeList);
        }

        // 3. Get details of a specific recipe (ingredients and steps)
        [HttpGet("cuisines/{cuisineName}/recipes/{recipeName}")]
        public async Task<IActionResult> GetRecipeDetails(string cuisineName, string recipeName)
        {
            var firebaseClient = _firebaseService.GetFirebaseClient();
            var recipe = await firebaseClient
                .Child($"cuisines/{cuisineName}/recipes/{recipeName}")
                .OnceSingleAsync<RecipeDetails>();

            return Ok(recipe);
        }
    }


    public class RecipeDetails
    {
        public List<string> Ingredients { get; set; }
        public List<string> Steps { get; set; }
    }
}
