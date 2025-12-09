using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class MountainGiant_Siege : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Mountain Giant (Siege)";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 350;
        public int Wood { get; set; } = 100;
        public int Food { get; set; } = 7;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Siege;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 41;
        public double AttackTime { get; set; } = 2.5;
        public int Range { get; set; } = 250;

        public int Health { get; set; } = 1600;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 6;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
