using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Units
{
    public class Destroyer : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Undead;
        public string Name { get; set; } = "Destroyer";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 300;
        public int Wood { get; set; } = 85;
        public int Food { get; set; } = 5;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Magic;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 20;
        public double AttackTime { get; set; } = 1.35;
        public int Range { get; set; } = 450;

        public int Health { get; set; } = 850;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 3;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
