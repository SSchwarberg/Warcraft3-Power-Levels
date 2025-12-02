using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Heroes
{
    public class NagaSeaWitch : HeroBase
    {
        public NagaSeaWitch()
        {
            Race = RaceEnum.Neutral;
            Name = "Naga Sea Witch";
            PrimaryAttribute = PrimaryAttributeEnum.Intelligence;

            SetBaseAttributes(
                str: 17, agi: 18, intel: 21,
                strGain: 1.7, agiGain: 2.2, intGain: 2.7
            );

            SetBaseCombat(
                attack: 20,
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
