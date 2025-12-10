using Warcraft3PowerLevels.Components;
using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;
using Warcraft3PowerLevels.Services;

namespace Warcraft3PowerLevels.Pages
{
    /// <summary>
    /// Interaction logic for UnitPowersPerSupply.razor
    /// </summary>
    public partial class UnitPowersPerSupply
    {

        /// <summary>
        /// Sort state for unit power rows.
        /// </summary>
        private SortState<UnitPowerRow> sortState = new();

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

        private bool IncludeNeutralUnits
        {
            get => FilterState.UnitIncludeNeutral;
            set => FilterState.UnitIncludeNeutral = value;
        }

        /// <summary>
        /// Selects the main race for filtering units.
        /// </summary>
        /// <param name="race"></param>
        private void SelectMainRace(RaceEnum? race) => SelectedMainRace = race;

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
        private void ToggleNeutralUnits() => IncludeNeutralUnits = !IncludeNeutralUnits;
        
        /// <summary>
        /// Checks if the given race is the currently selected main race for filtering.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        private bool IsMainRace(RaceEnum? race) => SelectedMainRace == race;

        /// <summary>
        /// OnInitialized lifecycle method to set up initial sort state.
        /// </summary>
        protected override void OnInitialized()
        {
            if (FilterState.UnitSortState_PowerPerSupply.KeySelector == null)
            {
                FilterState.UnitSortState_PowerPerSupply.KeySelector = UnitPowerTable.PowerSelector;
                FilterState.UnitSortState_PowerPerSupply.Direction = SortDirectionEnum.Descending;
            }

            sortState.KeySelector = FilterState.UnitSortState_PowerPerSupply.KeySelector;
            sortState.Direction = FilterState.UnitSortState_PowerPerSupply.Direction;
        }

        /// <summary>
        /// Gets the filtered units based on the selected main race and neutral inclusion.
        /// </summary>
        private IEnumerable<IUnit> FilteredUnits
        {
            get
            {
                var units = Repository.Units.Where(u => u.Food > 0).ToList();

                if (SelectedMainRace != null)
                    units = units.Where(u =>
                        u.Race == SelectedMainRace ||
                        u.Race == RaceEnum.Neutral
                    ).ToList();

                if (!IncludeNeutralUnits)
                    units = units.Where(u => u.Race != RaceEnum.Neutral).ToList();

                units = units.Where(u => u is not ISummon).ToList();

                return units;
            }
        }

        /// <summary>
        /// Gets the unit power rows with values scaled per supply (food).
        /// </summary>
        private IEnumerable<UnitPowerRow> PowerRows =>
            FilteredUnits.Select(u =>
            {
                double scale = 1.0 / u.Food;

                double scaledDps = PowerCalculator.ComputeDpsVsTarget(u, SelectedArmor) * scale;
                double scaledHp = PowerCalculator.ComputeEffectiveHp(u, SelectedAttack) * scale;

                double scaledPower = PowerCalculator.ComputePower(
                    u,
                    SelectedAttack,
                    SelectedArmor,
                    scale
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
                sortState.Direction = sortState.Direction == SortDirectionEnum.Ascending
                    ? SortDirectionEnum.Descending
                    : SortDirectionEnum.Ascending;
            }

            // Persist sorting for THIS PAGE only
            FilterState.UnitSortState_PowerPerSupply.KeySelector = sortState.KeySelector;
            FilterState.UnitSortState_PowerPerSupply.Direction = sortState.Direction;
        }
    }
}
