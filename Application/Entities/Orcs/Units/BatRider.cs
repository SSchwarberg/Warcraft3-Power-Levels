using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Units
{
    public class Batrider : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Orc;
        public string Name { get; set; } = "Batrider";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 160;
        public int Wood { get; set; } = 40;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Siege;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 14;
        public double AttackTime { get; set; } = 1.8;
        public int Range { get; set; } = 500;

        public int Health { get; set; } = 325;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
