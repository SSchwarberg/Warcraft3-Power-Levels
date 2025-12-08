using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class Hawk_3 : IUnit, ISummon
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Hawk (Level 3)";
        public int Tier { get; set; } = 0;

        public int Health { get; set; } = 650;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 5;

        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;

        public double Attack { get; set; } = 52.5;
        public double AttackTime { get; set; } = 1.5;
        public int Range { get; set; } = 300;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Magic;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;
    }
}
