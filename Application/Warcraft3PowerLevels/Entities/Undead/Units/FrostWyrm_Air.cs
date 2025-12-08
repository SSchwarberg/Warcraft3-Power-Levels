using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Units
{
    public class FrostWyrm_Air : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Undead;
        public string Name { get; set; } = "Frost Wyrm (Air)";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 385;
        public int Wood { get; set; } = 120;
        public int Food { get; set; } = 7;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Magic;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 89;
        public double AttackTime { get; set; } = 3.0;
        public int Range { get; set; } = 375;

        public int Health { get; set; } = 1350;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
