using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Heroes
{
    public class Paladin : HeroBase
    {
        public Paladin()
        {
            Race = RaceEnum.Human;
            Name = "Paladin";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 22, agi: 13, intel: 17,
                strGain: 2.7, agiGain: 1.5, intGain: 1.8
            );

            SetBaseCombat(
                attack: 29,
                attackTime: 2.0,
                range: 128,
                armor: 0
            );
        }
    }
}
