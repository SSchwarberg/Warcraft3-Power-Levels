using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Heroes
{
    public class DemonHunter : HeroBase
    {
        public DemonHunter()
        {
            Race = RaceEnum.NightElf;
            Name = "Demon Hunter";
            PrimaryAttribute = PrimaryAttributeEnum.Agility;

            SetBaseAttributes(
                str: 22, agi: 22, intel: 16,
                strGain: 2.4, agiGain: 2.8, intGain: 1.5
            );

            SetBaseCombat(
                attack: 22,
                attackTime: 1.5,
                range: 100,
                armor: 2
            );

            AttackType = AttackTypeEnum.Normal;
            WeaponType = WeaponTypeEnum.Melee;
            ArmorType = ArmorTypeEnum.Heavy;
        }
    }
}
