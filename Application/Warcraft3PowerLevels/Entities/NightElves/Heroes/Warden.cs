using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Heroes
{
    public class Warden : HeroBase
    {
        public Warden()
        {
            Race = RaceEnum.NightElf;
            Name = "Warden";
            PrimaryAttribute = PrimaryAttributeEnum.Agility;

            SetBaseAttributes(
                str: 20, agi: 20, intel: 18,
                strGain: 2.5, agiGain: 2.6, intGain: 1.9
            );

            SetBaseCombat(
                attack: 24,
                attackTime: 1.6,
                range: 100,
                armor: 2
            );

            AttackType = AttackTypeEnum.Normal;
            WeaponType = WeaponTypeEnum.Melee;
            ArmorType = ArmorTypeEnum.Heavy;
        }
    }
}
