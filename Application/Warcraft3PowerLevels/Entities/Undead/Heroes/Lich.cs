using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Heroes
{
    public class Lich : HeroBase
    {
        public Lich()
        {
            Race = RaceEnum.Undead;
            Name = "Lich";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 15, agi: 14, intel: 20,
                strGain: 2.0, agiGain: 1.0, intGain: 3.4
                );

            SetBaseCombat(
                attack: 25,
                attackTime: 1.9,
                range: 600,
                armor: -2
            );
        }
    }
}
