using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class GlaiveThrower : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Glaive Thrower";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 210;
        public int Wood { get; set; } = 65;
        public int Food { get; set; } = 3;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Siege;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 44;
        public double AttackTime { get; set; } = 3.5;
        public int Range { get; set; } = 1150;

        public int Health { get; set; } = 300;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;
    }
}
