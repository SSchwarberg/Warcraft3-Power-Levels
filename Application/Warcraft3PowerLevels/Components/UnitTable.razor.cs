using Microsoft.AspNetCore.Components;
using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Components
{
    /// <summary>
    /// Component for displaying a table of units with sorting functionality.
    /// </summary>
    public partial class UnitTable
    {
        private object? selectedEntity = null;
        [Parameter] public IEnumerable<IUnit> Units { get; set; } = [];
        [Parameter] public EventCallback<Func<IUnit, object>> OnSort { get; set; }
        [Parameter] public SortState<IUnit> SortState { get; set; } = new();

        // Shared selector instances
        public static readonly Func<IUnit, object> NameSelector = u => u.Name;
        public static readonly Func<IUnit, object> RaceSelector = u => u.Race;
        public static readonly Func<IUnit, object> TierSelector = u => u.Tier;
        public static readonly Func<IUnit, object> GoldSelector = u => u.Gold;
        public static readonly Func<IUnit, object> FoodSelector = u => u.Food;
        public static readonly Func<IUnit, object> AttackSelector = u => u.Attack;
        public static readonly Func<IUnit, object> AttackTime = u => u.AttackTime;
        public static readonly Func<IUnit, object> HealthSelector = u => u.Health;
        public static readonly Func<IUnit, object> ArmorSelector = u => u.Armor;

        /// <summary>
        /// Sorts the units based on the provided selector.
        /// </summary>
        /// <param name="selector"></param>
        private void Sort(Func<IUnit, object> selector)
        {
            OnSort.InvokeAsync(selector);
        }

        /// <summary>
        /// Gets the CSS class for the header based on the current sort state.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        private string GetHeaderClass(Func<IUnit, object> selector)
        {
            return SortState.KeySelector == selector ? "sorted" : "";
        }

        /// <summary>
        /// Renders the sort icon based on the current sort state.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        private RenderFragment SortIcon(Func<IUnit, object> selector) => builder =>
        {
            if (SortState.KeySelector != selector)
                return;

            var iconClass = SortState.Direction == SortDirectionEnum.Ascending
                ? "sort-asc"
                : "sort-desc";

            builder.OpenElement(0, "svg");
            builder.AddAttribute(1, "class", $"sort-icon {iconClass}");
            builder.AddAttribute(2, "viewBox", "0 0 24 24");
            builder.AddMarkupContent(3, "<path fill='currentColor' d='M12 4l-6 6h12z'/>");
            builder.CloseElement();
        };

        /// <summary>
        /// Displays the details of the selected hero.
        /// </summary>
        /// <param name="hero"></param>
        private void ShowDetails(IUnit hero)
        {
            selectedEntity = hero;
        }

        /// <summary>
        /// Closes the details dialog.
        /// </summary>
        private void CloseDialog()
        {
            selectedEntity = null;
        }
    }
}
