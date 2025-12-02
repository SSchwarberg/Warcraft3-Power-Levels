using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Heroes
{
    public class Archmage : HeroBase
    {
        public Archmage()
        {
            Race = RaceEnum.Human;
            Name = "Archmage";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;

            SetBaseAttributes(
                str: 19, agi: 15, intel: 24,
                strGain: 1.8, agiGain: 1.5, intGain: 3.0
            );

            SetBaseCombat(
                attack: 20,
                attackTime: 1.7,
                range: 600,
                armor: 1
            );

            AttackType = AttackTypeEnum.Magic;
            WeaponType = WeaponTypeEnum.Ranged;
            ArmorType = ArmorTypeEnum.Light;
        }
    }
}
