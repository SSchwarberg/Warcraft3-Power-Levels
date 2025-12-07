using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Services;

public static class PowerCalculator
{
    private const double DummyDps = 25;   // 50 DPS / 2 attacks, etc – your original choice
    private const double DummyArmor = 10;

    // ---------- 1. TFT damage table ----------
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

    // ---------- 2. Armor formula (unchanged) ----------
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

    public static double ComputeDps(IUnit unit) =>
        ((double)unit.Attack) / unit.AttackTime;

    // ---------- 3. DPS vs target armor type (for the DPS column) ----------
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

    // ---------- 4. Effective HP vs a given enemy ATTACK type ----------
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

    // ---------- 5. Original baseline power (no TFT, vs dummy) ----------
    private static double ComputeBaselinePower(IUnit unit)
    {
        double unitDps = ComputeDps(unit);

        // unit hitting dummy (10 armor)
        double unitDpsVsDummy = unitDps * ArmorDamageMultiplier(DummyArmor);

        // dummy hitting unit (25 DPS)
        double dummyDpsVsUnit = DummyDps * ArmorDamageMultiplier(unit.Armor);

        double timeToDie = unit.Health / dummyDpsVsUnit;

        return unitDpsVsDummy * timeToDie;
    }

    // ---------- 6. Power with optional enemyAttack / enemyArmor ----------
    public static double ComputePower(
        IUnit unit,
        AttackTypeEnum enemyAttack,
        ArmorTypeEnum enemyArmor)
    {
        // No selections → EXACT old behaviour
        if (enemyAttack == AttackTypeEnum.None &&
            enemyArmor == ArmorTypeEnum.None)
        {
            return ComputeBaselinePower(unit);
        }

        double baseDps = ComputeDps(unit);

        // Outgoing damage: our attack type vs enemy armor type
        double attackTypeMult = 1.0;
        if (enemyArmor != ArmorTypeEnum.None &&
            DamageTable.TryGetValue(unit.AttackType, out var vsArmor) &&
            vsArmor.TryGetValue(enemyArmor, out double mAtk))
        {
            attackTypeMult = mAtk;
        }

        double unitDpsVsDummy =
            baseDps * attackTypeMult * ArmorDamageMultiplier(DummyArmor);

        // Incoming damage: enemy attack type vs our armor type
        double incomingTypeMult = 1.0;
        if (enemyAttack != AttackTypeEnum.None &&
            DamageTable.TryGetValue(enemyAttack, out var vsUnitArmor) &&
            vsUnitArmor.TryGetValue(unit.ArmorType, out double mDef))
        {
            incomingTypeMult = mDef;
        }

        double dummyDpsVsUnit =
            DummyDps * ArmorDamageMultiplier(unit.Armor) * incomingTypeMult;

        double timeToDie = unit.Health / dummyDpsVsUnit;

        return unitDpsVsDummy * timeToDie;
    }
}
