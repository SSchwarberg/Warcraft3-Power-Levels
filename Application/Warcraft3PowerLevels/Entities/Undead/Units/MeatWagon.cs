using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Units
{
    public class MeatWagon : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Undead;
        public string Name { get; set; } = "Meat Wagon";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 230;
        public int Wood { get; set; } = 50;
        public int Food { get; set; } = 4;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Siege;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Artillery;
        public double Attack { get; set; } = 79.5;
        public double AttackTime { get; set; } = 4.0;
        public int Range { get; set; } = 1150;

        public int Health { get; set; } = 380;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;
    }
}
