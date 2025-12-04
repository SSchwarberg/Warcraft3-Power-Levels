using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Heroes
{
    public class PriestessOfTheMoon : HeroBase
    {
        public PriestessOfTheMoon()
        {
            Race = RaceEnum.NightElf;
            Name = "Priestess of the Moon";
            PrimaryAttribute = PrimaryAttributeEnum.Agility;

            SetBaseAttributes(
                str: 17, agi: 22, intel: 18,
                strGain: 1.7, agiGain: 2.8, intGain: 2.0
            );

            SetBaseCombat(
                attack: 21,
                attackTime: 1.7,
                range: 600,
                armor: 1
            );

            AttackType = AttackTypeEnum.Piercing;
            WeaponType = WeaponTypeEnum.Ranged;
            ArmorType = ArmorTypeEnum.Light;
        }
    }
}
