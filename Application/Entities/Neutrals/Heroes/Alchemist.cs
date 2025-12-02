using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Alchemist : HeroBase
    {
        public Alchemist()
        {
            Race = RaceEnum.Neutral;
            Name = "Goblin Alchemist";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 25, agi: 19, intel: 17,
                strGain: 2.7, agiGain: 2.0, intGain: 1.8
            );

            SetBaseCombat(
                attack: 27,
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
