using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Heroes
{
    public class TaurenChieftain : HeroBase
    {
        public TaurenChieftain()
        {
            Race = RaceEnum.Orc;
            Name = "Tauren Chieftain";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 25, agi: 10, intel: 15,
                strGain: 3.2, agiGain: 1.5, intGain: 1.3
            );

            SetBaseCombat(
                attack: 32,
                attackTime: 2.05,
                range: 128,
                armor: -1
            );
        }
    }
}
