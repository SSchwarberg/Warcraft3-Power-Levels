using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Tinker : HeroBase
    {
        public Tinker()
        {
            Race = RaceEnum.Neutral;
            Name = "Goblin Tinker";
            PrimaryAttribute = PrimaryAttributeEnum.Agility;

            SetBaseAttributes(
                str: 20, agi: 22, intel: 17,
                strGain: 2.3, agiGain: 2.7, intGain: 2.0
            );

            SetBaseCombat(
                attack: 22,
                attackTime: 1.5,
                range: 100,
                armor: 3
            );

            AttackType = AttackTypeEnum.Normal;
            WeaponType = WeaponTypeEnum.Melee;
            ArmorType = ArmorTypeEnum.Heavy;
        }
    }
}
