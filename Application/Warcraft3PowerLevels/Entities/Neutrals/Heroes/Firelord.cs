using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Firelord : HeroBase
    {
        public Firelord()
        {
            Race = RaceEnum.Neutral;
            Name = "Firelord";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 15, agi: 20, intel: 18,
                strGain: 2.0, agiGain: 1.6, intGain: 2.5
            );

            SetBaseCombat(
                attack: 25,
                attackTime: 1.8,
                range: 600,
                armor: -2
            );
        }
    }
}
