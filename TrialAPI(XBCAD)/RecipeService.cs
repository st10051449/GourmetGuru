/*namespace TrialAPI_XBCAD_
{
    public class RecipeService
    {
    }
}


public class RecipeService
{
    private readonly FirebaseClient _firebaseClient;

    public RecipeService()
    {
        _firebaseClient = new FirebaseClient("https://your-database-url.firebaseio.com/");
    }

    public async Task<List<Recipe>> GetRecipes(string cuisine)
    {
        var recipes = await _firebaseClient
            .Child(cuisine) // e.g., "italian_cuisine"
            .OnceAsync<Recipe>();

        return recipes.Select(r => r.Object).ToList();
    }

    public async Task<Recipe> GetRecipeDetails(string cuisine, string recipeId)
    {
        var recipe = await _firebaseClient
            .Child(cuisine)
            .Child(recipeId)
            .OnceSingleAsync<Recipe>();

        return recipe;
    }
}*/
