using Microsoft.AspNetCore.Components;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Components.Dialogs
{
    /// <summary>
    /// Dialog component to display details of a game entity (unit, hero, summon, etc.).
    /// </summary>
    public partial class EntityDetailsDialog
    {
        /// <summary>
        /// The entity whose details are to be displayed.
        /// </summary>
        [Parameter] public object? Entity { get; set; }
        /// <summary>
        /// Callback invoked when the dialog is closed.
        /// </summary>
        [Parameter] public EventCallback OnClose { get; set; }

        /// <summary>
        /// Gets the name of the entity based on its type.
        /// </summary>
        private string EntityName =>
            Entity switch
            {
                IUnit u => u.Name,
                _ => "Unknown"
            };

        /// <summary>
        /// Gets the type of the entity as a string.
        /// </summary>
        private string EntityType =>
           Entity switch
           {
               IHero => "Hero",
               ISummon => "Summon",
               _ => "Unit"
           };

        /// <summary>
        /// Closes the dialog by invoking the OnClose callback.
        /// </summary>
        private void Close() => OnClose.InvokeAsync();
    }
}
