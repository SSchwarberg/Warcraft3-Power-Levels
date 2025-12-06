namespace Warcraft3PowerLevels.Services
{
    /// <summary>
    /// Service to manage the layout state, including the current main section and context links.
    /// </summary>
    public class LayoutStateService
    {
        public List<(string Text, string Url)> HeroLinks { get; private set; } = new();
        public List<(string Text, string Url)> UnitLinks { get; private set; } = new();

        public LayoutStateService()
        {
            HeroLinks = new List<(string Text, string Url)>
            {
                ("Base Stats", "/HeroStats"),
                ("Power Levels", "/HeroStats/Power"),
            };

            UnitLinks = new List<(string Text, string Url)>
            {
                ("Base Stats", "/UnitStats"),
                ("Power Levels", "/UnitStats/Power"),
                ("Power per 100g", "/UnitStats/Power100"),
                ("Power per Supply", "/UnitStats/PowerSupply")
            };
        }
    }

}
