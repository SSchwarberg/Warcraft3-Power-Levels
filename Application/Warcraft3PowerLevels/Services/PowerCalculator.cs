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

    // ---------- 6. Power with optional enemyAttack / enemyArmor ----------
    public static double ComputePower(
    IUnit unit,
    AttackTypeEnum enemyAttack,
    ArmorTypeEnum enemyArmor,
    double scale = 1.0)
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


    public static double ComputePowerFromScaled(
    double scaledDps,
    double scaledEffectiveHp,
    double unitArmor)
    {
        // DPS vs dummy (dummy has 10 armor)
        double unitDpsVsDummy = scaledDps * ArmorDamageMultiplier(DummyArmor);

        // Dummy DPS vs unit (unit has its own armor)
        double dummyDpsVsUnit = DummyDps * ArmorDamageMultiplier(unitArmor);

        double timeToDie = scaledEffectiveHp / dummyDpsVsUnit;

        return unitDpsVsDummy * timeToDie;
    }
}
