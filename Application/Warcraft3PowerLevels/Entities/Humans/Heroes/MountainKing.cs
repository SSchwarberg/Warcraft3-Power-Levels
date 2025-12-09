using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Heroes
{
    public class MountainKing : HeroBase
    {
        public MountainKing()
        {
            Race = RaceEnum.Human;
            Name = "Mountain King";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 24, agi: 11, intel: 15,
                strGain: 3.0, agiGain: 1.5, intGain: 1.5
            );

            SetBaseCombat(
                attack: 31,
                attackTime: 2.22,
                range: 128,
                armor: -1
            );

        }
    }
}
