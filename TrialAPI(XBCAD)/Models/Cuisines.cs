namespace TrialAPI_XBCAD_.Models
{
    public class Cuisines
    {
        public string Name { get; set; }
        public Dictionary<string, Recipe> Recipes { get; set; }
    }
}
