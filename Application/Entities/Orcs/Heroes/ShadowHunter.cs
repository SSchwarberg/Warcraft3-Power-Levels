using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Heroes
{
    public class ShadowHunter : HeroBase
    {
        public ShadowHunter()
        {
            Race = RaceEnum.Orc;
            Name = "Shadow Hunter";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;

            SetBaseAttributes(
                str: 17, agi: 18, intel: 19,
                strGain: 1.8, agiGain: 2.0, intGain: 2.6
            );

            SetBaseCombat(
                attack: 23,
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
