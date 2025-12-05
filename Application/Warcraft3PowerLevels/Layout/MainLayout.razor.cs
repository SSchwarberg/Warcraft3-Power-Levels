using Microsoft.AspNetCore.Components;
using Warcraft3PowerLevels.Components.Services;

namespace Warcraft3PowerLevels.Layout
{
    /// <summary>
    /// Main layout component that listens to layout state changes.
    /// </summary>
    public partial class MainLayout : IDisposable
    {
        [Inject] 
        public LayoutStateService State { get; set; } = default!;

        protected override void OnInitialized()
        {
            State.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            State.OnChange -= StateHasChanged;
        }
    }
}
