using Microsoft.AspNetCore.Components;
using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Components
{
    /// <summary>
    /// Component for displaying a table of heroes with sortable columns.
    /// </summary>
    public partial class HeroTable
    {
        [Parameter] public IEnumerable<IHero> Heroes { get; set; } = [];
        [Parameter] public int Level { get; set; }
        [Parameter] public EventCallback<Func<IHero, object>> OnSort { get; set; }
        [Parameter] public SortState<IHero> SortState { get; set; } = new();
        private object? selectedEntity = null;


        // Shared selector instances (necessary so equality works)
        public static readonly Func<IHero, object> NameSelector = h => h.Name;
        public static readonly Func<IHero, object> RaceSelector = h => h.Race;
        public static readonly Func<IHero, object> PrimarySelector = h => h.PrimaryAttribute;
        public static readonly Func<IHero, object> StrengthSelector = h => h.Strength;
        public static readonly Func<IHero, object> AgilitySelector = h => h.Agility;
        public static readonly Func<IHero, object> IntelligenceSelector = h => h.Intelligence;
        public static readonly Func<IHero, object> HealthSelector = h => h.Health;
        public static readonly Func<IHero, object> ArmorSelector = h => h.Armor;
        public static readonly Func<IHero, object> RangeSelector = h => h.Range;
        public static readonly Func<IHero, object> AttackSelector = h => h.Attack;
        public static readonly Func<IHero, object> BaseAttackTimeSelector = h => h.AttackTime;
        public static readonly Func<IHero, object> AttackTimeSelector = h => h.ModifiedAttackTime;


        /// <summary>
        /// Sort the table by the given selector.
        /// </summary>
        /// <param name="selector"></param>
        private void Sort(Func<IHero, object> selector)
        {
            OnSort.InvokeAsync(selector);
        }

        /// <summary>
        /// Get the CSS class for the header based on the current sort state.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        private string GetHeaderClass(Func<IHero, object> selector)
        {
            return SortState.KeySelector == selector ? "sorted" : "";
        }

        /// <summary>
        /// Get the sort icon for the given selector.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        private RenderFragment SortIcon(Func<IHero, object> selector) => builder =>
        {
            if (SortState.KeySelector != selector)
                return;

            string iconClass = SortState.Direction == SortDirectionEnum.Ascending
                ? "sort-asc"
                : "sort-desc";

            builder.OpenElement(0, "svg");
            builder.AddAttribute(1, "class", $"sort-icon {iconClass}");
            builder.AddAttribute(2, "viewBox", "0 0 24 24");
            builder.AddMarkupContent(3, "<path fill='currentColor' d='M12 4l-6 6h12z'/>");
            builder.CloseElement();
        };

        /// <summary>
        /// Get the attributes of a hero at a specific level.
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private (int str, int agi, int intl, int health, double armor, double attack, double baseAtkTime, double atkTime, int range)
            GetAttributes(IHero hero, int level)
        {
            if (level < 1) level = 1;
            int gained = level - 1;

            hero.Level = level;

            int str = hero.Strength;
            int agi = hero.Agility;
            int intl = hero.Intelligence;

            int health = hero.Health;

            double armor = hero.Armor;
            double atkTime = hero.ModifiedAttackTime;
            double baseAtkTime = hero.AttackTime;

            double attack = hero.Attack;
            int range = hero.WeaponType == WeaponTypeEnum.Melee ? -1 : hero.Range;

            hero.Level = 1;

            return (str, agi, intl, health, armor, attack, baseAtkTime, atkTime, range);
        }

        /// <summary>
        /// Show the details dialog for the selected hero.
        /// </summary>
        /// <param name="hero"></param>
        private void ShowDetails(IHero hero)
        {
            selectedEntity = hero;
        }

        /// <summary>
        /// Close the details dialog.
        /// </summary>
        private void CloseDialog()
        {
            selectedEntity = null;
        }
    }
}
