using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Units
{
    public class Peon : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Orc;
        public string Name { get; set; } = "Peon";
        public int Tier { get; set; } = 1;
        public int Gold { get; set; } = 75;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 1;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public int Attack { get; set; } = 8;
        public double AttackTime { get; set; } = 3.0;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 250;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
