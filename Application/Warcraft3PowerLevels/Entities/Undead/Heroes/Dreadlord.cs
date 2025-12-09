using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Heroes
{
    public class Dreadlord : HeroBase
    {
        public Dreadlord()
        {
            Race = RaceEnum.Undead;
            Name = "Dreadlord";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 20, agi: 16, intel: 18,
                strGain: 2.5, agiGain: 1.0, intGain: 2.5
            );

            SetBaseCombat(
                attack: 27,
                attackTime: 1.8,
                range: 128,
                armor: -2
            );
        }
    }
}
