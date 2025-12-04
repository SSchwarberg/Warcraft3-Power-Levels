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

            SetBaseAttributes(
                str: 17, agi: 15, intel: 20,
                strGain: 1.7, agiGain: 1.5, intGain: 2.7
            );

            SetBaseCombat(
                attack: 20,
                attackTime: 1.7,
                range: 600,
                armor: 1
            );

            AttackType = AttackTypeEnum.Magic;
            WeaponType = WeaponTypeEnum.Ranged;
            ArmorType = ArmorTypeEnum.Light;
        }
    }
}
