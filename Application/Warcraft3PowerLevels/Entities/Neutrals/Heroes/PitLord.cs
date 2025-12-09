using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class PitLord : HeroBase
    {
        public PitLord()
        {
            Race = RaceEnum.Neutral;
            Name = "Pit Lord";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 26, agi: 16, intel: 14,
                strGain: 3.2, agiGain: 1.3, intGain: 1.5
            );

            SetBaseCombat(
                attack: 33,
                attackTime: 2.05,
                range: 128,
                armor: -2
            );
        }
    }
}
