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
            WeaponType = WeaponTypeEnum.Melee;

            SetBaseAttributes(
                str: 26, agi: 14, intel: 14,
                strGain: 3.2, agiGain: 1.2, intGain: 1.6
            );

            SetBaseCombat(
                attack: 31,
                attackTime: 1.9,
                range: 128,
                armor: -2
            );
        }
    }
}
