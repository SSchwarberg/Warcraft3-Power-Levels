using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Heroes
{
    public class MountainKing : HeroBase
    {
        public MountainKing()
        {
            Race = RaceEnum.Human;
            Name = "Mountain King";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 25, agi: 14, intel: 15,
                strGain: 3.0, agiGain: 1.3, intGain: 1.5
            );

            SetBaseCombat(
                attack: 27,
                attackTime: 1.7,
                range: 100,
                armor: 4
            );

            AttackType = AttackTypeEnum.Normal;
            WeaponType = WeaponTypeEnum.Melee;
            ArmorType = ArmorTypeEnum.Heavy;
        }
    }
}
