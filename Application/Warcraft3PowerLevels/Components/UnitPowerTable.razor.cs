using Microsoft.AspNetCore.Components;
using System.Globalization;
using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Components
{
    public partial class UnitPowerTable
    {
        private object? selectedEntity = null;

        [Parameter] public IEnumerable<UnitPowerRow> Rows { get; set; } = [];
        [Parameter] public EventCallback<Func<UnitPowerRow, object>> OnSort { get; set; }
        [Parameter] public SortState<UnitPowerRow> SortState { get; set; } = new();


        /* ----------------------
           COLUMN SELECTORS
           ----------------------*/
        public static readonly Func<UnitPowerRow, object> NameSelector = r => r.Unit.Name;
        public static readonly Func<UnitPowerRow, object> RaceSelector = r => r.Unit.Race;
        public static readonly Func<UnitPowerRow, object> TierSelector = r => r.Unit.Tier;
        public static readonly Func<UnitPowerRow, object> GoldSelector = r => r.Unit.Gold;
        public static readonly Func<UnitPowerRow, object> FoodSelector = r => r.Unit.Food;
        public static readonly Func<UnitPowerRow, object> DpsSelector = r => r.Dps;
        public static readonly Func<UnitPowerRow, object> EffectiveHpSelector = r => r.EffectiveHp;
        public static readonly Func<UnitPowerRow, object> PowerSelector = r => r.Power;


        /* ----------------------
           MIN / MAX PER METRIC
           ----------------------*/
        private double MinDps => Rows.Any() ? Rows.Min(r => Safe(r.Dps)) : 0;
        private double MaxDps => Rows.Any() ? Rows.Max(r => Safe(r.Dps)) : 1;
        private double MinHp => Rows.Any() ? Rows.Min(r => Safe(r.EffectiveHp)) : 0;
        private double MaxHp => Rows.Any() ? Rows.Max(r => Safe(r.EffectiveHp)) : 1;
        private double MinPower => Rows.Any() ? Rows.Min(r => Safe(r.Power)) : 0;
        private double MaxPower => Rows.Any() ? Rows.Max(r => Safe(r.Power)) : 1;

        /// <summary>
        /// Ensures the value is a positive finite number; otherwise returns 0.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private double Safe(double value)
            => double.IsFinite(value) && value > 0 ? value : 0;

        /// <summary>
        /// Shows the details dialog for the selected hero.
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

        /// <summary>
        /// Invokes the sort callback with the given selector.
        /// </summary>
        /// <param name="selector"></param>
        private void Sort(Func<UnitPowerRow, object> selector)
            => OnSort.InvokeAsync(selector);

        /// <summary>
        /// Gets the CSS class for the header based on the current sort state.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        private string GetHeaderClass(Func<UnitPowerRow, object> selector)
            => SortState.KeySelector == selector ? "sorted" : "";

        /// <summary>
        /// Renders the sort icon for the given selector if it matches the current sort key.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        private RenderFragment SortIcon(Func<UnitPowerRow, object> selector) => builder =>
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
        /// Renders a colored bar representing the value within the given min/max range.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="showDecimals"></param>
        /// <returns></returns>
        private RenderFragment Bar(double value, double min, double max, bool showDecimals) => builder =>
        {
            value = Safe(value);

            double span = max - min;
            double ratio = span > 0
                ? (value - min) / span // 0 = worst, 1 = best
                : 0.5;

            if (ratio < 0) ratio = 0;
            if (ratio > 1) ratio = 1;

            double widthPercent = ratio * 100.0;
            string widthCss = widthPercent.ToString("0.0", CultureInfo.InvariantCulture);

            string color = RankColor(ratio);

            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "bar-wrapper");

            builder.OpenElement(2, "div");
            builder.AddAttribute(3, "class", "bar-fill");
            builder.AddAttribute(4, "style", $"width:{widthCss}%; background-color:{color};");
            builder.CloseElement();

            builder.OpenElement(5, "span");
            builder.AddAttribute(6, "class", "bar-value");
            string valueText = showDecimals
                ? value.ToString("0.00")
                : ((int)Math.Round(value)).ToString();
            builder.AddContent(7, valueText);
            builder.CloseElement();

            builder.CloseElement();
        };

        /// <summary>
        /// Gets a color based on the ratio (0 = red, 1 = green).
        /// </summary>
        /// <param name="ratio"></param>
        /// <returns></returns>
        private string RankColor(double ratio)
        {
            ratio = Math.Clamp(ratio, 0, 1);
            double hue = 120.0 * ratio; // 0 = red, 120 = green
            return $"hsl({hue:F0}, 70%, 45%)";
        }
    }
}
