using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Heroes
{
    public class BloodMage : HeroBase
    {
        public BloodMage()
        {
            Race = RaceEnum.Human;
            Name = "Blood Mage";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 18, agi: 14, intel: 19,
                strGain: 2.0, agiGain: 1.0, intGain: 3.0
            );

            SetBaseCombat(
                attack: 24,
                attackTime: 1.64,
                range: 600,
                armor: -2
            );
        }
    }
}
