using Microsoft.AspNetCore.Components;
using System.Globalization;
using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Components
{
    /// <summary>
    /// Component for displaying a table of hero power levels.
    /// </summary>
    public partial class HeroPowerTable
    {
        /// <summary>
        /// The currently selected entity for detailed view.
        /// </summary>
        private object? selectedEntity = null;

        [Parameter] public IEnumerable<HeroPowerRow> Rows { get; set; } = [];
        [Parameter] public EventCallback<Func<HeroPowerRow, object>> OnSort { get; set; }
        [Parameter] public SortState<HeroPowerRow> SortState { get; set; } = new();

        /* ----------------------
           SELECTORS
           ----------------------*/
        public static readonly Func<HeroPowerRow, object> NameSelector = r => r.Hero.Name;
        public static readonly Func<HeroPowerRow, object> RaceSelector = r => r.Hero.Race;
        public static readonly Func<HeroPowerRow, object> LevelSelector = r => r.Level;
        public static readonly Func<HeroPowerRow, object> DpsSelector = r => r.Dps;
        public static readonly Func<HeroPowerRow, object> EffectiveHpSelector = r => r.EffectiveHp;
        public static readonly Func<HeroPowerRow, object> PowerSelector = r => r.Power;


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
        /// Ensures the value is finite and positive; otherwise returns 0.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private double Safe(double value)
            => double.IsFinite(value) && value > 0 ? value : 0;

        /// <summary>
        /// Shows the details of the selected hero.
        /// </summary>
        /// <param name="hero"></param>
        private void ShowDetails(IHero hero)
        {
            selectedEntity = hero;
        }

        /// <summary>
        /// Closes the detail dialog.
        /// </summary>
        private void CloseDialog()
        {
            selectedEntity = null;
        }


        /// <summary>
        /// Invokes the sort callback with the given selector.
        /// </summary>
        /// <param name="selector"></param>
        private void Sort(Func<HeroPowerRow, object> selector)
            => OnSort.InvokeAsync(selector);

        /// <summary>
        /// Gets the CSS class for the header based on the current sort state.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        private string GetHeaderClass(Func<HeroPowerRow, object> selector)
            => SortState.KeySelector == selector ? "sorted" : "";

        /// <summary>
        /// Renders the sort icon for the given selector if it is the current sort key.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        private RenderFragment SortIcon(Func<HeroPowerRow, object> selector) => builder =>
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
        /// Renders a bar representing the value within the given min and max range.
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
                ? (value - min) / span
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
        /// Calculates a color based on the given ratio (0 to 1) using HSL color space.
        /// </summary>
        /// <param name="ratio"></param>
        /// <returns></returns>
        private string RankColor(double ratio)
        {
            ratio = Math.Clamp(ratio, 0, 1);
            double hue = 120.0 * ratio;
            return $"hsl({hue:F0}, 70%, 45%)";
        }
    }
}
