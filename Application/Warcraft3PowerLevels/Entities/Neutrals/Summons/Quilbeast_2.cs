using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class Quilbeast_2 : IUnit, ISummon
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Quilbeast (Level 2)";
        public int Tier { get; set; } = 0;

        public int Health { get; set; } = 515;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;

        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
        public double Attack { get; set; } = 28;
        public double AttackTime { get; set; } = 1.5;
        public int Range { get; set; } = 550;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;
    }
}
