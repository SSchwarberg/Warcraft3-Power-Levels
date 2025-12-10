using System.Runtime.InteropServices;

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
            UnitLinks = new List<(string Text, string Url)>
            {
                ("Power", "Unit/power"),
                ("Power per 100g", "Unit/power100g"),
                ("Power per Supply", "Unit/PowerPerSupply"),
                ("Base Stats", "Unit/Stats"),
            };

            HeroLinks = new List<(string Text, string Url)>
            {
                ("Power", "Hero/Power"),
                ("Base Stats", "Hero/Stats"),
            };
        }
    }

}
