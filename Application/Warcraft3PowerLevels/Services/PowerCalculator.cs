using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Services;

/// <summary>
/// Provides methods to calculate the power level of units.
/// </summary>
public static class PowerCalculator
{
    private const double DummyDps = 25;       // Dummy deals 50 DPS
    private const double DummyArmor = 10;     // Dummy has 10 armor

    private static double ArmorDamageMultiplier(double armor)
    {
        if (armor >= 0)
        {
            double reduction = (armor * 0.06) / (1.0 + 0.06 * armor);
            return 1.0 - reduction;
        }
        else
        {
            return 2.0 - Math.Pow(0.94, -armor);
        }
    }

    public static double ComputeDps(IUnit unit) =>
        unit.Attack / unit.AttackTime;

    public static int ComputeEffectiveHp(IUnit unit)
    {
        double mult = ArmorDamageMultiplier(unit.Armor);
        return (int)(unit.Health / mult);
    }

    public static double ComputePower(IUnit unit)
    {
        double unitDps = ComputeDps(unit);

        // DPS vs Dummy = apply Dummy armor
        double unitDpsVsDummy = unitDps * ArmorDamageMultiplier(DummyArmor);

        // Dummy DPS vs Unit = apply Unit armor
        double dummyDpsVsUnit = DummyDps * ArmorDamageMultiplier(unit.Armor);

        double timeToDie = unit.Health / dummyDpsVsUnit;

        return unitDpsVsDummy * timeToDie;
    }
}
