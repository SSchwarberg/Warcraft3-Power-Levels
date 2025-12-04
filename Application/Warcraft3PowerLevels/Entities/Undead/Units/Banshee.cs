using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Units
{
    public class Banshee : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Undead;
        public string Name { get; set; } = "Banshee";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 155;
        public int Wood { get; set; } = 30;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Magic;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 11;
        public double AttackTime { get; set; } = 1.5;
        public int Range { get; set; } = 600;

        public int Health { get; set; } = 285;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Unarmored;
    }
}
