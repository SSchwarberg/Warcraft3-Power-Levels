using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Heroes
{
    public class Lich : HeroBase
    {
        public Lich()
        {
            Race = RaceEnum.Undead;
            Name = "Lich";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;

            SetBaseAttributes(
                str: 16, agi: 15, intel: 22,
                strGain: 1.5, agiGain: 1.9, intGain: 2.8
            );

            SetBaseCombat(
                attack: 24,
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
