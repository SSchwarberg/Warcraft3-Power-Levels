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
                ("Power", "/UnitStats/power"),
                ("Power per 100g", "/UnitStats/power100g"),
                ("Power per Supply", "/UnitStats/PowerPerSupply"),
                ("Base Stats", "/UnitStats"),
            };

            HeroLinks = new List<(string Text, string Url)>
            {
                ("Power", "/HeroStats/Power"),
                ("Base Stats", "/HeroStats"),
            };
        }
    }

}
