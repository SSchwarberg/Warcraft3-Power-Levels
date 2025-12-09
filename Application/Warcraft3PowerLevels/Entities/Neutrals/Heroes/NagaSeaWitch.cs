using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class NagaSeaWitch : HeroBase
    {
        public NagaSeaWitch()
        {
            Race = RaceEnum.Neutral;
            Name = "Naga Sea Witch";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;
            WeaponType = WeaponTypeEnum.Ranged;

            SetBaseAttributes(
                str: 15, agi: 16, intel: 22,
                strGain: 2.0, agiGain: 1.0, intGain: 3.0
            );

            SetBaseCombat(
                attack: 29,
                attackTime: 1.9,
                range: 600,
                armor: -2
            );
        }
    }
}
