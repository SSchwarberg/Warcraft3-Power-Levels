using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Heroes
{
    public class ShadowHunter : HeroBase
    {
        public ShadowHunter()
        {
            Race = RaceEnum.Orc;
            Name = "Shadow Hunter";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 15, agi: 20, intel: 17,
                strGain: 2.0, agiGain: 1.5, intGain: 2.5
            );

            SetBaseCombat(
                attack: 25,
                attackTime: 2.28,
                range: 600,
                armor: -2
            );
        }
    }
}
