using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class Firelord : HeroBase
    {
        public Firelord()
        {
            Race = RaceEnum.Neutral;
            Name = "Firelord";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;

            SetBaseAttributes(
                str: 18, agi: 15, intel: 20,
                strGain: 1.8, agiGain: 1.5, intGain: 2.6
            );

            SetBaseCombat(
                attack: 19,
                attackTime: 1.6,
                range: 600,
                armor: 1
            );

            AttackType = AttackTypeEnum.Magic;
            WeaponType = WeaponTypeEnum.Ranged;
            ArmorType = ArmorTypeEnum.Light;
        }
    }
}
