using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Heroes
{
    public class FarSeer : HeroBase
    {
        public FarSeer()
        {
            Race = RaceEnum.Orc;
            Name = "Far Seer";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;

            SetBaseAttributes(
                str: 18, agi: 16, intel: 21,
                strGain: 1.8, agiGain: 1.6, intGain: 2.7
            );

            SetBaseCombat(
                attack: 21,
                attackTime: 1.7,
                range: 600,
                armor: 2
            );

            AttackType = AttackTypeEnum.Magic;
            WeaponType = WeaponTypeEnum.Ranged;
            ArmorType = ArmorTypeEnum.Light;
        }
    }
}
