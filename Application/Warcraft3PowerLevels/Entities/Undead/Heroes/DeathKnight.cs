using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Heroes
{
    public class DeathKnight : HeroBase
    {
        public DeathKnight()
        {
            Race = RaceEnum.Undead;
            Name = "Death Knight";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 24, agi: 16, intel: 17,
                strGain: 2.7, agiGain: 1.6, intGain: 1.8
            );

            SetBaseCombat(
                attack: 26,
                attackTime: 1.7,
                range: 100,
                armor: 3
            );

            AttackType = AttackTypeEnum.Normal;
            WeaponType = WeaponTypeEnum.Melee;
            ArmorType = ArmorTypeEnum.Heavy;
        }
    }
}
