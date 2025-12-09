using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Brewmaster : HeroBase
    {
        public Brewmaster()
        {
            Race = RaceEnum.Neutral;
            Name = "Pandaren Brewmaster";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 23, agi: 14, intel: 16,
                strGain: 3.0, agiGain: 1.5, intGain: 1.5
            );

            SetBaseCombat(
                attack: 30,
                attackTime: 2.22,
                range: 128,
                armor: -1
            );
        }
    }
}
