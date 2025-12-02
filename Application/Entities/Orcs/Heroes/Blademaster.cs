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

            SetBaseAttributes(
                str: 22, agi: 24, intel: 15,
                strGain: 2.5, agiGain: 3.0, intGain: 1.5
            );

            SetBaseCombat(
                attack: 26,
                attackTime: 1.6,
                range: 100,
                armor: 3
            );

            AttackType = AttackTypeEnum.Normal;
            WeaponType = WeaponTypeEnum.Melee;
            ArmorType = ArmorTypeEnum.Heavy;
        }
    }
}
