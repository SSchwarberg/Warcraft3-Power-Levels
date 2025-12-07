using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class MountainGiant : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Mountain Giant";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 425;
        public int Wood { get; set; } = 100;
        public int Food { get; set; } = 7;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public double Attack { get; set; } = 34;
        public double AttackTime { get; set; } = 2.5;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 1600;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 4;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
