using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Heroes
{
    public class KeeperOfTheGrove : HeroBase
    {
        public KeeperOfTheGrove()
        {
            Race = RaceEnum.NightElf;
            Name = "Keeper of the Grove";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 16, agi: 15, intel: 18,
                strGain: 2.0, agiGain: 1.5, intGain: 2.7
            );

            SetBaseCombat(
                attack: 23,
                attackTime: 2.0,
                range: 600,
                armor: -2
            );
        }
    }
}
