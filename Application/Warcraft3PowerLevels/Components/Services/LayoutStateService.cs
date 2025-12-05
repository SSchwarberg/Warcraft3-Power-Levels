namespace Warcraft3PowerLevels.Components.Services
{
    /// <summary>
    /// Service to manage layout state such as context title and links.
    /// </summary>
    public class LayoutStateService
    {
        public string ContextTitle { get; private set; } = "Stat Type";

        public List<(string Text, string Url)> ContextLinks { get; private set; } = new();

        public event Action? OnChange;

        public void SetContext(string title, List<(string Text, string Url)> items)
        {
            ContextTitle = title;
            ContextLinks = items;
            OnChange?.Invoke();
        }
    }
}
