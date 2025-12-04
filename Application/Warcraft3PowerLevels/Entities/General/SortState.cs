using Warcraft3PowerLevels.Entities.Enumerations;

namespace Warcraft3PowerLevels.Entities.General
{
    /// <summary>
    /// Class representing the sort state for a collection of items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortState<T>
    {
        public Func<T, object>? KeySelector { get; set; }
        public SortDirectionEnum Direction { get; set; } = SortDirectionEnum.Ascending;

        public IEnumerable<T> Apply(IEnumerable<T> data)
        {
            if (KeySelector == null)
                return data;

            return Direction == SortDirectionEnum.Ascending
                ? data.OrderBy(KeySelector)
                : data.OrderByDescending(KeySelector);
        }
    }
}
