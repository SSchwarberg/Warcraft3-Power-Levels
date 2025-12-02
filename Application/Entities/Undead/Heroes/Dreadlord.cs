using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Heroes
{
    public class Dreadlord : HeroBase
    {
        public Dreadlord()
        {
            Race = RaceEnum.Undead;
            Name = "Dreadlord";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 22, agi: 16, intel: 16,
                strGain: 2.6, agiGain: 1.6, intGain: 1.8
            );

            SetBaseCombat(
                attack: 25,
                attackTime: 1.7,
                range: 100,
                armor: 3
            );

            AttackType = AttackTypeEnum.Normal;
            WeaponType = WeaponTypeEnum.Melee;
            ArmorType = ArmorTypeEnum.Heavy;
        }
    }
}
