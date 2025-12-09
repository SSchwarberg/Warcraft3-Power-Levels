using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Heroes
{
    public class PriestessOfTheMoon : HeroBase
    {
        public PriestessOfTheMoon()
        {
            Race = RaceEnum.NightElf;
            Name = "Priestess of the Moon";
            PrimaryAttribute = PrimaryAttributeEnum.Agility;
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 18, agi: 19, intel: 15,
                strGain: 1.9, agiGain: 1.5, intGain: 2.6
            );

            SetBaseCombat(
                attack: 26,
                attackTime: 2.33,
                range: 600,
                armor: -2
            );
        }
    }
}
