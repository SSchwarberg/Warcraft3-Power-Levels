using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class DarkRanger : HeroBase
    {
        public DarkRanger()
        {
            Race = RaceEnum.Neutral;
            Name = "Dark Ranger";
            PrimaryAttribute = PrimaryAttributeEnum.Agility;

            SetBaseAttributes(
                str: 16, agi: 21, intel: 18,
                strGain: 1.8, agiGain: 2.6, intGain: 1.9
            );

            SetBaseCombat(
                attack: 18,
                attackTime: 1.7,
                range: 600,
                armor: 1
            );

            AttackType = AttackTypeEnum.Piercing;
            WeaponType = WeaponTypeEnum.Ranged;
            ArmorType = ArmorTypeEnum.Light;
        }
    }
}
