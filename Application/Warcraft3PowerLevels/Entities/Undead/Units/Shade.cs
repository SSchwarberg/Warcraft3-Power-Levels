using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Units
{
    public class Shade : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Undead;
        public string Name { get; set; } = "Shade";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 75;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 1;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.None;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.None;
        public double Attack { get; set; } = 0;
        public double AttackTime { get; set; } = 0.0;
        public int Range { get; set; } = 0;

        public int Health { get; set; } = 125;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
