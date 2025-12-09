namespace Warcraft3PowerLevels.Entities.General
{
    /// <summary>
    /// Represents a data row for a hero's power statistics at a specific level.
    /// </summary>
    /// <param name="Hero"></param>
    /// <param name="Level"></param>
    /// <param name="Dps"></param>
    /// <param name="EffectiveHp"></param>
    /// <param name="Power"></param>
    public sealed record HeroPowerRow(
        IHero Hero,
        int Level,
        double Dps,
        double EffectiveHp,
        double Power);
}
