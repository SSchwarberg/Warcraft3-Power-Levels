using Microsoft.AspNetCore.Components;
using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Pages
{
    /// <summary>
    /// Interaction logic for HeroStats.razor logi
    /// </summary>
    public partial class HeroStats
    {
        /// <summary>
        /// Sort state for heroes.
        /// </summary>
        private SortState<IHero> sortState = null;

        private int HeroLevel
        {
            get => FilterState.HeroLevel;
            set => FilterState.HeroLevel = value;
        }

        private RaceEnum? SelectedRace
        {
            get => FilterState.HeroRace;
            set => FilterState.HeroRace = value;
        }

        /// <summary>
        /// OnInitialized lifecycle method to set up initial sort state.
        /// </summary>
        protected override void OnInitialized()
        {
            sortState = FilterState.HeroSortState;
        }

        private bool IsSelected(RaceEnum? race) => SelectedRace == race;

        /// <summary>
        /// Selects the race for filtering heroes.
        /// </summary>
        /// <param name="race"></param>
        private void SelectRace(RaceEnum? race)
        {
            FilterState.HeroRace = race;
        }

        /// <summary>
        /// Handles level change event.
        /// </summary>
        /// <param name="e"></param>
        private void OnLevelChanged(ChangeEventArgs e)
        {
            HeroLevel = int.Parse(e.Value!.ToString()!);
        }


        /// <summary>
        /// Gets the filtered heroes based on the selected race.
        /// </summary>
        private IEnumerable<IHero> FilteredHeroes =>
            SelectedRace == null
                ? Repository.Heroes
                : Repository.Heroes.Where(h => h.Race == SelectedRace);

        /// <summary>
        /// Handles sorting when a column header is clicked.
        /// </summary>
        /// <param name="selector"></param>
        private void HandleSort(Func<IHero, object> selector)
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

            // Persist sort settings
            FilterState.HeroSortState = sortState;
        }

    }
}
