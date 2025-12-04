using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Brewmaster : HeroBase
    {
        public Brewmaster()
        {
            Race = RaceEnum.Neutral;
            Name = "Pandaren Brewmaster";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 24, agi: 18, intel: 16,
                strGain: 2.8, agiGain: 2.0, intGain: 1.7
            );

            SetBaseCombat(
                attack: 26,
                attackTime: 1.6,
                range: 100,
                armor: 3
            );

            AttackType = AttackTypeEnum.Normal;
            WeaponType = WeaponTypeEnum.Melee;
            ArmorType = ArmorTypeEnum.Heavy;
        }
    }
}
