using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Pages
{
    /// <summary>
    /// Interaction logic for UnitStats.razor
    /// </summary>
    public partial class UnitStats
    {
        /// <summary>
        /// Sort state for units.
        /// </summary>
        private SortState<IUnit> sortState = new();

        /// <summary>
        /// The selected main race for filtering units.
        /// </summary>
        private RaceEnum? selectedMainRace
        {
            get => FilterState.UnitRace;
            set => FilterState.UnitRace = value;
        }

        /// <summary>
        /// Indicates whether neutral units are included in the filter.
        /// </summary>
        private bool includeNeutralUnits => FilterState.UnitIncludeNeutral;

        /// <summary>
        /// Indicates whether summons are included in the filter.
        /// </summary>
        private bool includeSummons => FilterState.UnitIncludeSummons;

        /// <summary>
        /// OnInitialized lifecycle method to set up initial filter state.
        /// </summary>
        protected override void OnInitialized()
        {
            // Load race filter
            selectedMainRace = FilterState.UnitRace;
        }

        /// <summary>
        /// Checks if the given race is the currently selected main race for filtering units.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        private bool IsMainRace(RaceEnum? race) => selectedMainRace == race;

        /// <summary>
        /// Selects the main race for filtering units.
        /// </summary>
        /// <param name="race"></param>
        private void SelectMainRace(RaceEnum? race)
            => selectedMainRace = race;

        /// <summary>
        /// Toggles the inclusion of neutral units in the filter.
        /// </summary>
        private void ToggleNeutralUnits() =>
            FilterState.UnitIncludeNeutral = !FilterState.UnitIncludeNeutral;

        /// <summary>
        /// Toggles the inclusion of summons in the filter.
        /// </summary>
        private void ToggleSummons() =>
            FilterState.UnitIncludeSummons = !FilterState.UnitIncludeSummons;

        /// <summary>
        /// Gets the filtered units based on the selected filters.
        /// </summary>
        private IEnumerable<IUnit> FilteredUnits
        {
            get
            {
                var units = Repository.Units;

                // Apply main race filter (excluding Neutral)
                if (selectedMainRace != null)
                    units = units.Where(u => u.Race == selectedMainRace || u.Race == RaceEnum.Neutral).ToList();

                // Neutral Units toggle (Bandits, creeps, mercs → RaceEnum.Neutral)
                if (!includeNeutralUnits)
                    units = units.Where(u => u.Race != RaceEnum.Neutral).ToList();

                // Summons toggle (Elementals, Wolves → UnitType.Summon)
                if (!includeSummons)
                    units = units.Where(u => u is not ISummon).ToList();

                return units;
            }
        }

        /// <summary>
        /// Handles sorting when a column header is clicked.
        /// </summary>
        /// <param name="selector"></param>
        private void HandleSort(Func<IUnit, object> selector)
        {
            if (sortState.KeySelector != selector)
            {
                sortState.KeySelector = selector;
                sortState.Direction = SortDirectionEnum.Descending;
            }
            else
            {
                sortState.Direction =
                    sortState.Direction == SortDirectionEnum.Ascending
                    ? SortDirectionEnum.Descending
                    : SortDirectionEnum.Ascending;
            }
        }
    }
}
