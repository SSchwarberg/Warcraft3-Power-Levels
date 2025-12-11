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
        private RaceEnum? SelectedMainRace
        {
            get => FilterState.UnitRace;
            set => FilterState.UnitRace = value;
        }

        private AttackTypeEnum SelectedAttack
        {
            get => FilterState.SelectedAttack;
            set => FilterState.SelectedAttack = value;
        }

        private ArmorTypeEnum SelectedArmor
        {
            get => FilterState.SelectedArmor;
            set => FilterState.SelectedArmor = value;
        }

        /// <summary>
        /// Selects the main race for filtering units.
        /// </summary>
        /// <param name="race"></param>
        private void SelectMainRace(RaceEnum? race)
        {
            SelectedMainRace = race;
            FilterState.UnitRace = race;
        }

        /// <summary>
        /// Selects the attack type for filtering units.
        /// </summary>
        /// <param name="atk"></param>
        private void SelectAttack(AttackTypeEnum atk)
        {
            SelectedAttack = SelectedAttack == atk ? AttackTypeEnum.None : atk;
            FilterState.SelectedAttack = SelectedAttack;
        }

        /// <summary>
        /// Selects the armor type for filtering units.
        /// </summary>
        /// <param name="arm"></param>
        private void SelectArmor(ArmorTypeEnum arm)
        {
            SelectedArmor = SelectedArmor == arm ? ArmorTypeEnum.None : arm;
            FilterState.SelectedArmor = SelectedArmor;
        }

        /// <summary>
        /// Checks if the given race is the currently selected main race for filtering.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        private bool IsMainRace(RaceEnum? race) => SelectedMainRace == race;

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
        /// OnInitialized lifecycle method to restore filter and sort state.
        /// </summary>
        protected override void OnInitialized()
        {
            // Restore main race filter
            SelectedMainRace = FilterState.UnitRace;

            // Restore enemy attack/armor type filters
            SelectedAttack = FilterState.SelectedAttack;
            SelectedArmor = FilterState.SelectedArmor;

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
                var units = Repository.Units;

                if (SelectedMainRace != null)
                    units = units.Where(u => u.Race == SelectedMainRace || u.Race == RaceEnum.Neutral).ToList();

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
        /// Gets the power rows for the filtered units, calculating DPS, effective HP, and power.
        /// </summary>
        private IEnumerable<UnitPowerRow> PowerRows =>
            FilteredUnits.Select(u =>
            {
                var dps = PowerCalculator.ComputeDpsVsTarget(u, SelectedArmor);
                var effHp = (int)PowerCalculator.ComputeEffectiveHp(u, SelectedAttack);
                var power = PowerCalculator.ComputePower(u, SelectedAttack, SelectedArmor);

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
