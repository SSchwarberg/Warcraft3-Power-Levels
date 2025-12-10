namespace Warcraft3PowerLevels.Pages
{
    /// <summary>
    /// Interaction logic for Home.razor
    /// </summary>
    public partial class Home
    {
        /// <summary>
        /// OnInitialized lifecycle method to redirect to the power page.
        /// </summary>
        protected override void OnInitialized()
        {
            Nav.NavigateTo("Unit/power", false);
        }
    }
}
