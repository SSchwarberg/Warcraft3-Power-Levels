using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class PitLord : HeroBase
    {
        public PitLord()
        {
            Race = RaceEnum.Neutral;
            Name = "Pit Lord";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 25,
                agi: 15,
                intel: 16,
                strGain: 3.0,
                agiGain: 1.5,
                intGain: 1.8
            );

            SetBaseCombat(
                attack: 29,
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
