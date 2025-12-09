using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Heroes
{
    public class DeathKnight : HeroBase
    {
        public DeathKnight()
        {
            Race = RaceEnum.Undead;
            Name = "Death Knight";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 23, agi: 12, intel: 17,
                strGain: 2.7, agiGain: 1.5, intGain: 1.8
            );
            
            SetBaseCombat(
                attack: 30,
                attackTime: 2.33,
                range: 128,
                armor: -1
            );
        }
    }
}
