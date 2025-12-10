using Warcraft3PowerLevels.Components;
using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;
using Warcraft3PowerLevels.Services;

namespace Warcraft3PowerLevels.Pages
{
    /// <summary>
    /// Interaction logic for UnitPowers.razor
    /// </summary>
    public partial class UnitPowers
    {
        private RaceEnum? selectedMainRace
        {
            get => FilterState.UnitRace;
            set => FilterState.UnitRace = value;
        }

        private AttackTypeEnum selectedAttack
        {
            get => FilterState.SelectedAttack;
            set => FilterState.SelectedAttack = value;
        }

        private ArmorTypeEnum selectedArmor
        {
            get => FilterState.SelectedArmor;
            set => FilterState.SelectedArmor = value;
        }

        private bool includeNeutralUnits
        {
            get => FilterState.UnitIncludeNeutral;
            set => FilterState.UnitIncludeNeutral = value;
        }

        private bool includeSummons
        {
            get => FilterState.UnitIncludeSummons;
            set => FilterState.UnitIncludeSummons = value;
        }

        /// <summary>
        /// Selects the main race for filtering units.
        /// </summary>
        /// <param name="race"></param>
        private void SelectMainRace(RaceEnum? race)
        {
            selectedMainRace = race;
            FilterState.UnitRace = race;
        }

        /// <summary>
        /// Selects the attack type for filtering units.
        /// </summary>
        /// <param name="atk"></param>
        private void SelectAttack(AttackTypeEnum atk)
        {
            selectedAttack = selectedAttack == atk ? AttackTypeEnum.None : atk;
            FilterState.SelectedAttack = selectedAttack;
        }

        /// <summary>
        /// Selects the armor type for filtering units.
        /// </summary>
        /// <param name="arm"></param>
        private void SelectArmor(ArmorTypeEnum arm)
        {
            selectedArmor = selectedArmor == arm ? ArmorTypeEnum.None : arm;
            FilterState.SelectedArmor = selectedArmor;
        }

        /// <summary>
        /// Toggles the inclusion of neutral units in the filter.
        /// </summary>
        private void ToggleNeutralUnits()
        {
            includeNeutralUnits = !includeNeutralUnits;
            FilterState.UnitIncludeNeutral = includeNeutralUnits;
        }

        private void ToggleSummons()
        {
            includeSummons = !includeSummons;
            FilterState.UnitIncludeSummons = includeSummons;
        }

        /// <summary>
        /// Checks if the given race is the currently selected main race for filtering.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        private bool IsMainRace(RaceEnum? race) => selectedMainRace == race;

        /// <summary>
        /// OnInitialized lifecycle method to restore filter and sort state.
        /// </summary>
        protected override void OnInitialized()
        {
            // Restore main race filter
            selectedMainRace = FilterState.UnitRace;

            // Restore "Neutral Units" and "Summons"
            includeNeutralUnits = FilterState.UnitIncludeNeutral;
            includeSummons = FilterState.UnitIncludeSummons;

            // Restore enemy attack/armor type filters
            selectedAttack = FilterState.SelectedAttack;
            selectedArmor = FilterState.SelectedArmor;

            // Restore sorting for THIS PAGE only
            // If the user never sorted before, default to Power
            if (FilterState.UnitSortState_Power.KeySelector == null)
            {
                FilterState.UnitSortState_Power.KeySelector = UnitPowerTable.PowerSelector;
                FilterState.UnitSortState_Power.Direction = SortDirectionEnum.Descending;
            }

            sortState.KeySelector = FilterState.UnitSortState_Power.KeySelector;
            sortState.Direction = FilterState.UnitSortState_Power.Direction;
        }

        /// <summary>
        /// Gets the filtered units based on the selected main race and other filters.
        /// </summary>
        private IEnumerable<IUnit> FilteredUnits
        {
            get
            {
                var units = Repository.Units.ToList();

                if (selectedMainRace != null)
                    units = units.Where(u =>
                        u.Race == selectedMainRace ||
                        u.Race == RaceEnum.Neutral
                    ).ToList();

                if (!includeNeutralUnits)
                    units = units.Where(u => u.Race != RaceEnum.Neutral).ToList();

                if (!includeSummons)
                    units = units.Where(u => u is not ISummon).ToList();

                return units;
            }
        }

        /// <summary>
        /// Gets the power rows for the filtered units, calculating DPS, effective HP, and power.
        /// </summary>
        private IEnumerable<UnitPowerRow> PowerRows =>
            FilteredUnits.Select(u =>
            {
                var dps = PowerCalculator.ComputeDpsVsTarget(u, selectedArmor);
                var effHp = (int)PowerCalculator.ComputeEffectiveHp(u, selectedAttack);
                var power = PowerCalculator.ComputePower(u, selectedAttack, selectedArmor);

                return new UnitPowerRow(u, dps, effHp, power);
            });

        /// <summary>
        /// Sort state for the unit power table.
        /// </summary>
        private SortState<UnitPowerRow> sortState = new();

        /// <summary>
        /// Handles sorting when a column header is clicked.
        /// </summary>
        /// <param name="selector"></param>
        private void HandleSort(Func<UnitPowerRow, object> selector)
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

            // Save to shared state for this page
            FilterState.UnitSortState_Power.KeySelector = sortState.KeySelector;
            FilterState.UnitSortState_Power.Direction = sortState.Direction;
        }


    }
}
