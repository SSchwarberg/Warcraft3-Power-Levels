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
        private void CycleNeutral()
        {
            FilterState.NeutralState = FilterState.NeutralState switch
            {
                ToggleStateEnum.Off => ToggleStateEnum.On,
                ToggleStateEnum.On => ToggleStateEnum.Exclusive,
                ToggleStateEnum.Exclusive => ToggleStateEnum.Off,
                _ => ToggleStateEnum.Off
            };
        }

        /// <summary>
        /// Toggles the inclusion of summons in the filter.
        /// </summary>
        private void CycleSummons()
        {
            FilterState.SummonState = FilterState.SummonState switch
            {
                ToggleStateEnum.Off => ToggleStateEnum.On,
                ToggleStateEnum.On => ToggleStateEnum.Exclusive,
                ToggleStateEnum.Exclusive => ToggleStateEnum.Off,
                _ => ToggleStateEnum.Off
            };
        }

        /// <summary>
        /// Gets the filtered units based on the selected filters.
        /// </summary>
        private IEnumerable<IUnit> FilteredUnits
        {
            get
            {
                var units = Repository.Units;

                if (selectedMainRace != null)
                    units = units.Where(u => u.Race == selectedMainRace || u.Race == RaceEnum.Neutral).ToList();

                if (FilterState.NeutralState == ToggleStateEnum.Exclusive)
                    units = units.Where(u => u.Race == RaceEnum.Neutral).ToList();

                if (FilterState.NeutralState == ToggleStateEnum.Off)
                    units = units.Where(u => u.Race != RaceEnum.Neutral).ToList();

                if (FilterState.SummonState == ToggleStateEnum.Off)
                    units = units.Where(u => u is not ISummon).ToList();

                if (FilterState.SummonState == ToggleStateEnum.Exclusive)
                    units = units.Where(u => u is ISummon).ToList();

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
