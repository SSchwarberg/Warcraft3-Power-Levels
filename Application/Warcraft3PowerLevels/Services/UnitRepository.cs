using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Services
{
    /// <summary>
    /// Repository to load and hold all units and heroes implementing the IUnit and IHero interfaces.
    /// </summary>
    public class UnitRepository
    {
        public IReadOnlyList<IUnit> Units { get; }
        public IReadOnlyList<IHero> Heroes { get; }

        public UnitRepository()
        {
            Units = LoadAllUnits();
            Heroes = Units.OfType<IHero>().ToList();
            Units = Units.Except(Heroes).ToList();
        }

        /// <summary>
        /// Loads all units implementing the IUnit interface from the current AppDomain.
        /// </summary>
        /// <returns></returns>
        private static IReadOnlyList<IUnit> LoadAllUnits()
        {
            var unitType = typeof(IUnit);

            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a =>
                {
                    try { return a.GetTypes(); }
                    catch { return Array.Empty<Type>(); }
                })
                .Where(t =>
                    unitType.IsAssignableFrom(t)
                    && t.IsClass
                    && !t.IsAbstract
                    && t.GetConstructor(Type.EmptyTypes) != null
                )
                .Select(t =>
                {
                    try { return (IUnit)Activator.CreateInstance(t)!; }
                    catch { return null; }
                })
                .Where(x => x != null)
                .ToList()!;
        }
    }
}
