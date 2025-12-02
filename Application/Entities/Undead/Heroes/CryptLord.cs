using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Heroes
{
    public class CryptLord : HeroBase
    {
        public CryptLord()
        {
            Race = RaceEnum.Undead;
            Name = "Crypt Lord";
            PrimaryAttribute = PrimaryAttributeEnum.Strength;

            SetBaseAttributes(
                str: 26, agi: 14, intel: 16,
                strGain: 3.0, agiGain: 1.2, intGain: 1.5
            );

            SetBaseCombat(
                attack: 29,
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
