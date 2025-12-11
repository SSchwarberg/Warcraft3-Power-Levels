using Warcraft3PowerLevels.Components;
using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;
using Warcraft3PowerLevels.Services;

namespace Warcraft3PowerLevels.Pages
{
    /// <summary>
    /// Interaction logic for UnitPowers100g.razor
    /// </summary>
    public partial class UnitPowers100g
    {
        /// <summary>
        /// Sort state for unit power rows.
        /// </summary>
        private SortState<UnitPowerRow> sortState = new();

        /// <summary>
        /// Selected main race for filtering units.
        /// </summary>
        private RaceEnum? SelectedMainRace
        {
            get => FilterState.UnitRace;
            set => FilterState.UnitRace = value;
        }

        /// <summary>
        /// Selected attack type for filtering units.
        /// </summary>
        private AttackTypeEnum SelectedAttack
        {
            get => FilterState.SelectedAttack;
            set => FilterState.SelectedAttack = value;
        }

        /// <summary>
        /// Selected armor type for filtering units.
        /// </summary>
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
            => SelectedMainRace = race;

        /// <summary>
        /// Selects the attack type for filtering units.
        /// </summary>
        /// <param name="atk"></param>
        private void SelectAttack(AttackTypeEnum atk)
            => SelectedAttack = SelectedAttack == atk ? AttackTypeEnum.None : atk;

        /// <summary>
        /// Selects the armor type for filtering units.
        /// </summary>
        /// <param name="arm"></param>
        private void SelectArmor(ArmorTypeEnum arm)
            => SelectedArmor = SelectedArmor == arm ? ArmorTypeEnum.None : arm;

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
        /// Checks if the given race is the currently selected main race for filtering.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        private bool IsMainRace(RaceEnum? race)
            => SelectedMainRace == race;

        /// <summary>
        /// OnInitialized lifecycle method to set up initial sort state.
        /// </summary>
        protected override void OnInitialized()
        {
            // Page-specific sorting state
            if (FilterState.UnitSortState_Power100g.KeySelector == null)
            {
                FilterState.UnitSortState_Power100g.KeySelector = UnitPowerTable.PowerSelector;
                FilterState.UnitSortState_Power100g.Direction = SortDirectionEnum.Descending;
            }

            sortState.KeySelector = FilterState.UnitSortState_Power100g.KeySelector;
            sortState.Direction = FilterState.UnitSortState_Power100g.Direction;
        }

        /// <summary>
        /// Gets the filtered units based on the selected main race and neutral inclusion.
        /// </summary>
        private IEnumerable<IUnit> FilteredUnits
        {
            get
            {
                var units = Repository.Units;
                units = units.Where(u => u is not ISummon).ToList();

                if (SelectedMainRace != null)
                    units = units.Where(u => u.Race == SelectedMainRace || u.Race == RaceEnum.Neutral).ToList();

                if (FilterState.NeutralState == ToggleStateEnum.Exclusive)
                    units = units.Where(u => u.Race == RaceEnum.Neutral).ToList();

                if (FilterState.NeutralState == ToggleStateEnum.Off)
                    units = units.Where(u => u.Race != RaceEnum.Neutral).ToList();

                return units;
            }
        }

        /// <summary>
        /// Gets the power rows for the filtered units, scaled to 100 gold.
        /// </summary>
        private IEnumerable<UnitPowerRow> PowerRows =>
            FilteredUnits.Select(u =>
            {
                double scale = 100.0 / u.Gold;

                double scaledDps = PowerCalculator.ComputeDpsVsTarget(u, SelectedArmor) * scale;
                double scaledHp = PowerCalculator.ComputeEffectiveHp(u, SelectedAttack) * scale;

                double scaledPower = PowerCalculator.ComputePower(
                    u,
                    SelectedAttack,
                    SelectedArmor,
                    scale  // properly scale DPS & HP inside the calculation
                );

                return new UnitPowerRow(u, scaledDps, (int)scaledHp, scaledPower);
            });

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

            // Persist specifically for this page
            FilterState.UnitSortState_Power100g.KeySelector = sortState.KeySelector;
            FilterState.UnitSortState_Power100g.Direction = sortState.Direction;
        }
    }
}
