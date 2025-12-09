using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Heroes
{
    public class DemonHunter : HeroBase
    {
        public DemonHunter()
        {
            Race = RaceEnum.NightElf;
            Name = "Demon Hunter";
            PrimaryAttribute = PrimaryAttributeEnum.Agility;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 19, agi: 21, intel: 16,
                strGain: 2.4, agiGain: 1.5, intGain: 2.1
            );

            SetBaseCombat(
                attack: 34,
                attackTime: 1.7,
                range: 128,
                armor: -2
            );
        }
    }
}
