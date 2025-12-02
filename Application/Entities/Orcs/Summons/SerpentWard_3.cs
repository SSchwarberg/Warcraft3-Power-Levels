using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Summons
{
    public class SerpentWard_3 : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Orc;
        public string Name { get; set; } = "Serpent Ward (Level 3)";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 30;
        public double AttackTime { get; set; } = 1.5;
        public int Range { get; set; } = 600;

        public int Health { get; set; } = 225;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
