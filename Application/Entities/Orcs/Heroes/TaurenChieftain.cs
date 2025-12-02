using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Heroes
{
    public class TaurenChieftain : HeroBase
    {
        public TaurenChieftain()
        {
            Race = RaceEnum.Orc;
            Name = "Tauren Chieftain";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 25, agi: 14, intel: 15,
                strGain: 3.2, agiGain: 1.3, intGain: 1.6
            );

            SetBaseCombat(
                attack: 28,
                attackTime: 1.7,
                range: 100,
                armor: 4
            );

            AttackType = AttackTypeEnum.Normal;
            WeaponType = WeaponTypeEnum.Melee;
            ArmorType = ArmorTypeEnum.Heavy;
        }
    }
}
