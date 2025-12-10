using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Warcraft3PowerLevels.Services;

namespace Warcraft3PowerLevels.Layout
{
    /// <summary>
    /// Base class for the main layout component.
    /// </summary>
    public class MainLayoutBase : LayoutComponentBase, IDisposable
    {
        [Inject] public LayoutStateService LayoutState { get; set; } = default!;
        [Inject] public NavigationManager Nav { get; set; } = default!;

        private string? currentUrl;

        /// <summary>
        /// Initializes the component and subscribes to location changes.
        /// </summary>
        protected override void OnInitialized()
        {
            currentUrl = Nav.Uri;
            Nav.LocationChanged += OnLocationChanged;
        }

        /// <summary>
        /// Handles location changes and updates the current URL.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            currentUrl = e.Location;
            StateHasChanged();
        }

        /// <summary>
        /// Determines if the specified group is active based on the current URL.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public bool IsActiveGroup(string group)
        {
            if (currentUrl is null)
                return false;

            string path = Nav.ToBaseRelativePath(currentUrl).ToLower();

            bool Match(string url)
                => path == url.ToLower().TrimStart('/') ||
                   path.EndsWith("/" + url.ToLower().TrimStart('/'));

            if (group == "Heroes")
                return LayoutState.HeroLinks.Any(l => Match(l.Url));

            if (group == "Units")
                return LayoutState.UnitLinks.Any(l => Match(l.Url));

            return false;
        }

        /// <summary>
        /// Cleans up resources by unsubscribing from location changes.
        /// </summary>
        public void Dispose()
        {
            Nav.LocationChanged -= OnLocationChanged;
        }
    }
}