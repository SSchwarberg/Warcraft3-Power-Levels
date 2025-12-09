using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Heroes
{
    public class Archmage : HeroBase
    {
        public Archmage()
        {
            Race = RaceEnum.Human;
            Name = "Archmage";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 14, agi: 17, intel: 19,
                strGain: 2.0, agiGain: 1.0, intGain: 3.2
            );

            SetBaseCombat(
                attack: 24,
                attackTime: 2.13,
                range: 600,
                armor: -2
            );
        }
    }
}
