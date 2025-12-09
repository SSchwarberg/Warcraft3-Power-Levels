using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Beastmaster : HeroBase
    {
        public Beastmaster()
        {
            Race = RaceEnum.Neutral;
            Name = "Beastmaster";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 22, agi: 14, intel: 15,
                strGain: 2.9, agiGain: 1.3, intGain: 1.8
            );

            SetBaseCombat(
                attack: 29,
                attackTime: 2.20,
                range: 128,
                armor: -2
            );
        }
    }
}
