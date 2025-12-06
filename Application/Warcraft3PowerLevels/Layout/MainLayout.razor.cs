using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Warcraft3PowerLevels.Services;

namespace Warcraft3PowerLevels.Layout
{
    public class MainLayoutBase : LayoutComponentBase, IDisposable
    {
        [Inject] public LayoutStateService LayoutState { get; set; } = default!;
        [Inject] public NavigationManager Nav { get; set; } = default!;

        private string? currentUrl;

        protected override void OnInitialized()
        {
            currentUrl = Nav.Uri;
            Nav.LocationChanged += OnLocationChanged;
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            currentUrl = e.Location;
            StateHasChanged();
        }

        public bool IsActiveGroup(string group)
        {
            if (currentUrl is null)
                return false;

            if (group == "Heroes")
                return LayoutState.HeroLinks.Any(l => currentUrl.Contains(l.Url, StringComparison.OrdinalIgnoreCase));

            if (group == "Units")
                return LayoutState.UnitLinks.Any(l => currentUrl.Contains(l.Url, StringComparison.OrdinalIgnoreCase));

            return false;
        }

        public void Dispose()
        {
            Nav.LocationChanged -= OnLocationChanged;
        }
    }
}