using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Units
{
    public class Gargoyle_Air : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Undead;
        public string Name { get; set; } = "Gargoyle (Air)";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 175;
        public int Wood { get; set; } = 30;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public double Attack { get; set; } = 65;
        public double AttackTime { get; set; } = 1.4;
        public int Range { get; set; } = 128;

        public int Health { get; set; } = 410;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 3;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Unarmored;
    }
}
