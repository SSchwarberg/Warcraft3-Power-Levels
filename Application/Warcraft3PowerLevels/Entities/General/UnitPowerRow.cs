namespace Warcraft3PowerLevels.Entities.General
{
    /// <summary>
    /// Represents a data row containing power level information for a unit.
    /// </summary>
    /// <param name="Unit"></param>
    /// <param name="Dps"></param>
    /// <param name="EffectiveHp"></param>
    /// <param name="Power"></param>
    public sealed record UnitPowerRow(
        IUnit Unit,
        double Dps,
        int EffectiveHp,
        double Power);

}
