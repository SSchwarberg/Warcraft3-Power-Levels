using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Units
{
    public class Abomination : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Undead;
        public string Name { get; set; } = "Abomination";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 240;
        public int Wood { get; set; } = 70;
        public int Food { get; set; } = 4;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public int Attack { get; set; } = 36;
        public double AttackTime { get; set; } = 1.9;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 1175;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;
    }
}
