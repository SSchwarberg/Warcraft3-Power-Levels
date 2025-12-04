using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Heroes
{
    public class Paladin : HeroBase
    {
        public Paladin()
        {
            Race = RaceEnum.Human;
            Name = "Paladin";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 23, agi: 15, intel: 17,
                strGain: 2.7, agiGain: 1.5, intGain: 2.0
            );

            SetBaseCombat(
                attack: 21,
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
