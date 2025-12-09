using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Alchemist : HeroBase
    {
        public Alchemist()
        {
            Race = RaceEnum.Neutral;
            Name = "Goblin Alchemist";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 25, agi: 10, intel: 18,
                strGain: 3.3, agiGain: 1.0, intGain: 2.0
            );

            SetBaseCombat(
                attack: 41.5,
                attackTime: 2.50,
                range: 128,
                armor: -2
            );
        }
    }
}
