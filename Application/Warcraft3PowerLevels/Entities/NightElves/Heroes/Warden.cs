using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Heroes
{
    public class Warden : HeroBase
    {
        public Warden()
        {
            Race = RaceEnum.NightElf;
            Name = "Warden";
            PrimaryAttribute = PrimaryAttributeEnum.Agility;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 18, agi: 20, intel: 16,
                strGain: 2.4, agiGain: 1.6, intGain: 2.00
            );

            SetBaseCombat(
                attack: 32,
                attackTime: 2.05,
                range: 128,
                armor: -2
            );
        }
    }
}
