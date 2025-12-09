using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Heroes
{
    public class FarSeer : HeroBase
    {
        public FarSeer()
        {
            Race = RaceEnum.Orc;
            Name = "Far Seer";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 15, agi: 18, intel: 19,
                strGain: 2.0, agiGain: 1.0, intGain: 3.0
            );

            SetBaseCombat(
                attack: 24,
                attackTime: 2.28,
                range: 600,
                armor: -2
            );
        }
    }
}
