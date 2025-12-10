using Microsoft.AspNetCore.Components;
using Warcraft3PowerLevels.Components;
using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Pages
{
    /// <summary>
    /// Interaction logic for HeroPower.razor
    /// </summary>
    public partial class HeroPower
    {
        // Dummy target stats for power calculation
        private const double DummyDps = 25.0;
        private const double DummyArmor = 10.0;

        /// <summary>
        /// Current sort state for the hero power table.
        /// </summary>
        private SortState<HeroPowerRow> sortState = new();

        private int heroLevel
        {
            get => FilterState.HeroLevel;
            set => FilterState.HeroLevel = value;
        }

        private RaceEnum? selectedRace
        {
            get => FilterState.HeroRace;
            set => FilterState.HeroRace = value;
        }

        /// <summary>
        /// Determines if the given race is currently selected.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        private bool IsSelected(RaceEnum? race) => selectedRace == race;

        /// <summary>
        /// Selects the given race as filter.
        /// </summary>
        /// <param name="race"></param>
        private void SelectRace(RaceEnum? race)
        {
            selectedRace = race;
        }

        /// <summary>
        /// Handles the level change event from the input.
        /// </summary>
        /// <param name="e"></param>
        private void OnLevelChanged(ChangeEventArgs e)
        {
            heroLevel = int.Parse(e.Value!.ToString()!);
        }

        /// <summary>
        /// Gets the list of heroes filtered by
        /// </summary>
        private IEnumerable<IHero> FilteredHeroes =>
            selectedRace == null
                ? Repository.Heroes
                : Repository.Heroes.Where(h => h.Race == selectedRace);

        /// <summary>
        /// Gets the list of hero power rows to display.
        /// </summary>
        private IEnumerable<HeroPowerRow> PowerRows =>
            FilteredHeroes.Select(BuildPowerRow);

        /// <summary>
        /// Builds a HeroPowerRow for the given hero at the selected level.
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private HeroPowerRow BuildPowerRow(IHero hero)
        {
            int level = heroLevel < 1 ? 1 : heroLevel;
            int originalLevel = hero.Level;

            try
            {
                hero.Level = level;

                int agi = hero.Agility;
                int health = hero.Health;
                double armor = hero.Armor;
                double attack = hero.Attack;
                double atkTime = hero.ModifiedAttackTime;

                double dps = atkTime > 0 ? attack / atkTime : 0;

                double armorMult = ArmorDamageMultiplier(armor);
                double effectiveHp = armorMult > 0 ? health / armorMult : health;

                double dpsVsDummy = dps * ArmorDamageMultiplier(DummyArmor);
                double dummyDpsVsHero = DummyDps * ArmorDamageMultiplier(armor);
                double timeToDie = dummyDpsVsHero > 0 ? health / dummyDpsVsHero : 0;
                double power = dpsVsDummy * timeToDie;

                return new HeroPowerRow(hero, level, dps, effectiveHp, power);
            }
            finally
            {
                hero.Level = originalLevel;
            }
        }

        /// <summary>
        /// Calculates the damage multiplier based on the given armor value.
        /// </summary>
        /// <param name="armor"></param>
        /// <returns></returns>
        private static double ArmorDamageMultiplier(double armor)
        {
            if (armor >= 0)
            {
                double reduction = (armor * 0.06) / (1.0 + 0.06 * armor);
                return 1.0 - reduction;
            }
            else
            {
                return 2.0 - Math.Pow(0.94, -armor);
            }
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        protected override void OnInitialized()
        {
            if (sortState.KeySelector == null)
            {
                sortState.KeySelector = HeroPowerTable.PowerSelector;
                sortState.Direction = SortDirectionEnum.Descending;
            }
        }

        /// <summary>
        /// Handles sorting when a column header is clicked.
        /// </summary>
        /// <param name="selector"></param>
        private void HandleSort(Func<HeroPowerRow, object> selector)
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
