using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Units
{
    public class Acolyte : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Undead;
        public string Name { get; set; } = "Acolyte";
        public int Tier { get; set; } = 1;
        public int Gold { get; set; } = 75;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 1;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public double Attack { get; set; } = 9.5;
        public double AttackTime { get; set; } = 2.5;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 230;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
