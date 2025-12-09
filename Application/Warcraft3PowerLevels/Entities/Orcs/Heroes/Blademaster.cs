using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Heroes
{
    public class Blademaster : HeroBase
    {
        public Blademaster()
        {
            Race = RaceEnum.Orc;
            Name = "Blademaster";
            PrimaryAttribute = PrimaryAttributeEnum.Agility;
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 18, agi: 22, intel: 16,
                strGain: 2.0, agiGain: 1.75, intGain: 2.25
            );

            SetBaseCombat(
                attack: 35,
                attackTime: 1.77,
                range: 128,
                armor: -2
            );
        }
    }
}
