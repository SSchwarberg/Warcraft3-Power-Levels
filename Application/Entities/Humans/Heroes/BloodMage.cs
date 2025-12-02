using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Heroes
{
    public class BloodMage : HeroBase
    {
        public BloodMage()
        {
            Race = RaceEnum.Human;
            Name = "Blood Mage";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;

            SetBaseAttributes(
                str: 18, agi: 18, intel: 21,
                strGain: 1.8, agiGain: 2.2, intGain: 2.7
            );

            SetBaseCombat(
                attack: 23,
                attackTime: 1.6,
                range: 600,
                armor: 0
            );

            AttackType = AttackTypeEnum.Magic;
            WeaponType = WeaponTypeEnum.Ranged;
            ArmorType = ArmorTypeEnum.Light;
        }
    }
}
