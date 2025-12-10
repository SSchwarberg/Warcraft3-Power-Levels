using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Services;

/// <summary>
/// Calculator for unit power levels based on DPS and Effective HP.
/// </summary>
public static class PowerCalculator
{
    /// <summary>
    /// Dummy target stats for power calculations.
    /// </summary>
    private const double DummyDps = 25;   // 50 DPS / 2 attacks, etc – your original choice
    private const double DummyArmor = 10;


    /// <summary>
    /// Damage multiplier table based on attack type vs armor type
    /// </summary>
    private static readonly Dictionary<AttackTypeEnum, Dictionary<ArmorTypeEnum, double>> DamageTable =
        new()
        {
            [AttackTypeEnum.Normal] = new()
            {
                [ArmorTypeEnum.Unarmored] = 1.00,
                [ArmorTypeEnum.Light] = 1.00,
                [ArmorTypeEnum.Medium] = 1.50,
                [ArmorTypeEnum.Heavy] = 1.00,
                [ArmorTypeEnum.Fortified] = 0.70,
                [ArmorTypeEnum.Hero] = 1.00
            },
            [AttackTypeEnum.Piercing] = new()
            {
                [ArmorTypeEnum.Unarmored] = 1.50,
                [ArmorTypeEnum.Light] = 2.00,
                [ArmorTypeEnum.Medium] = 0.75,
                [ArmorTypeEnum.Heavy] = 0.90,
                [ArmorTypeEnum.Fortified] = 0.35,
                [ArmorTypeEnum.Hero] = 0.50
            },
            [AttackTypeEnum.Magic] = new()
            {
                [ArmorTypeEnum.Unarmored] = 1.00,
                [ArmorTypeEnum.Light] = 1.25,
                [ArmorTypeEnum.Medium] = 0.75,
                [ArmorTypeEnum.Heavy] = 2.00,
                [ArmorTypeEnum.Fortified] = 0.35,
                [ArmorTypeEnum.Hero] = 0.50
            },
            [AttackTypeEnum.Siege] = new()
            {
                [ArmorTypeEnum.Unarmored] = 1.50,
                [ArmorTypeEnum.Light] = 1.00,
                [ArmorTypeEnum.Medium] = 0.50,
                [ArmorTypeEnum.Heavy] = 1.00,
                [ArmorTypeEnum.Fortified] = 1.50,
                [ArmorTypeEnum.Hero] = 0.50
            },
            [AttackTypeEnum.Hero] = new()
            {
                [ArmorTypeEnum.Unarmored] = 1.00,
                [ArmorTypeEnum.Light] = 1.00,
                [ArmorTypeEnum.Medium] = 1.00,
                [ArmorTypeEnum.Heavy] = 1.00,
                [ArmorTypeEnum.Fortified] = 0.50,
                [ArmorTypeEnum.Hero] = 1.00
            },
            [AttackTypeEnum.Chaos] = new()
            {
                [ArmorTypeEnum.Unarmored] = 1.00,
                [ArmorTypeEnum.Light] = 1.00,
                [ArmorTypeEnum.Medium] = 1.00,
                [ArmorTypeEnum.Heavy] = 1.00,
                [ArmorTypeEnum.Fortified] = 1.00,
                [ArmorTypeEnum.Hero] = 1.00
            }
        };


    /// <summary>
    /// Computes the damage multiplier based on armor value.
    /// </summary>
    /// <param name="armor"></param>
    /// <returns></returns>
    private static double ArmorDamageMultiplier(double armor)
    {
        if (armor >= 0)
        {
            double reduction = (armor * 0.06) / (1.0 + 0.06 * armor);
            return 1.0 - reduction;          // < 1 means reduced damage
        }

        // negative armor → more damage taken
        return 2.0 - Math.Pow(0.94, -armor);
    }

    /// <summary>
    /// Computes the raw DPS of a unit (without armor considerations).
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    public static double ComputeDps(IUnit unit) =>
        ((double)unit.Attack) / unit.AttackTime;


    /// <summary>
    /// Computes the DPS of a unit against a target with specific armor type.
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="targetArmor"></param>
    /// <returns></returns>
    public static double ComputeDpsVsTarget(IUnit unit, ArmorTypeEnum targetArmor)
    {
        double baseDps = ComputeDps(unit);

        if (targetArmor == ArmorTypeEnum.None)
            return baseDps;

        if (DamageTable.TryGetValue(unit.AttackType, out var row) &&
            row.TryGetValue(targetArmor, out double mult))
        {
            return baseDps * mult;
        }

        return baseDps;
    }


    /// <summary>
    /// Computes the Effective HP of a unit against an enemy attack type.
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="enemyAttack"></param>
    /// <returns></returns>
    public static double ComputeEffectiveHp(IUnit unit, AttackTypeEnum enemyAttack)
    {
        double baseMult = ArmorDamageMultiplier(unit.Armor);
        double tftMult = 1.0;

        if (enemyAttack != AttackTypeEnum.None &&
            DamageTable.TryGetValue(enemyAttack, out var vsArmor) &&
            vsArmor.TryGetValue(unit.ArmorType, out double m))
        {
            tftMult = m;    // >1 means more damage taken → lower EHP
        }

        double combinedMult = baseMult * tftMult;
        return unit.Health / combinedMult;
    }


    /// <summary>
    /// Computes the Power of a unit against an enemy with specific attack and armor types.
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="enemyAttack"></param>
    /// <param name="enemyArmor"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static double ComputePower(IUnit unit, AttackTypeEnum enemyAttack, ArmorTypeEnum enemyArmor, double scale = 1.0)
    {
        // -----------------------------------------
        // Scale RAW inputs (DPS + HP)
        // -----------------------------------------
        double scaledDps = ComputeDps(unit) * scale;
        double scaledHealth = unit.Health * scale;

        // -----------------------------------------
        // Outgoing damage (unit → dummy)
        // -----------------------------------------
        double attackTypeMult = 1.0;

        if (enemyArmor != ArmorTypeEnum.None &&
            DamageTable.TryGetValue(unit.AttackType, out var vsArmor) &&
            vsArmor.TryGetValue(enemyArmor, out double mAtk))
        {
            attackTypeMult = mAtk;
        }

        double dpsVsDummy =
            scaledDps * attackTypeMult * ArmorDamageMultiplier(DummyArmor);

        // -----------------------------------------
        // Incoming damage (dummy → unit)
        // -----------------------------------------
        double incomingTypeMult = 1.0;

        if (enemyAttack != AttackTypeEnum.None &&
            DamageTable.TryGetValue(enemyAttack, out var vsUnitArmor) &&
            vsUnitArmor.TryGetValue(unit.ArmorType, out double mDef))
        {
            incomingTypeMult = mDef;
        }

        double dummyDpsVsUnit =
            DummyDps * ArmorDamageMultiplier(unit.Armor) * incomingTypeMult;

        // -----------------------------------------
        // Time to die (uses *scaled health*)
        // -----------------------------------------
        double timeToDie = scaledHealth / dummyDpsVsUnit;

        return dpsVsDummy * timeToDie;
    }


    /// <summary>
    /// Computes the Power from already scaled DPS and Effective HP values.
    /// </summary>
    /// <param name="scaledDps"></param>
    /// <param name="scaledEffectiveHp"></param>
    /// <param name="unitArmor"></param>
    /// <returns></returns>
    public static double ComputePowerFromScaled(double scaledDps, double scaledEffectiveHp, double unitArmor)
    {
        double unitDpsVsDummy = scaledDps * ArmorDamageMultiplier(DummyArmor);
        double dummyDpsVsUnit = DummyDps * ArmorDamageMultiplier(unitArmor);

        double timeToDie = scaledEffectiveHp / dummyDpsVsUnit;

        return unitDpsVsDummy * timeToDie;
    }
}
