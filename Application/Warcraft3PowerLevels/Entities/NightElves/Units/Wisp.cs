using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class Wisp : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Wisp";
        public int Tier { get; set; } = 1;
        public int Gold { get; set; } = 70;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 1;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.None;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.None;
        public double Attack { get; set; } = 0;
        public double AttackTime { get; set; } = 0;
        public int Range { get; set; } = 0;

        public int Health { get; set; } = 120;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Unarmored;
    }
}
