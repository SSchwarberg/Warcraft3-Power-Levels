using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Beastmaster : HeroBase
    {
        public Beastmaster()
        {
            Race = RaceEnum.Neutral;
            Name = "Beastmaster";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 23, agi: 18, intel: 16,
                strGain: 2.8, agiGain: 2.0, intGain: 1.5
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
