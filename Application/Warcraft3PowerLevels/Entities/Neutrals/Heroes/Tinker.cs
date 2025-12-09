using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Tinker : HeroBase
    {
        public Tinker()
        {
            Race = RaceEnum.Neutral;
            Name = "Tinker";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;
            WeaponType = WeaponTypeEnum.Melee;


            SetBaseAttributes(
                str: 20, agi: 15, intel: 20,
                strGain: 2.4, agiGain: 1.0, intGain: 2.6
            );

            SetBaseCombat(
                attack: 25,
                attackTime: 2.0,
                range: 128,
                armor: -1
            );
        }
    }
}
