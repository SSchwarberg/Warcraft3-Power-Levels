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
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 18, agi: 21, intel: 15,
                strGain: 1.9, agiGain: 1.5, intGain: 2.6
            );

            SetBaseCombat(
                attack: 28,
                attackTime: 2.42,
                range: 600,
                armor: -2
            );
        }
    }
}
