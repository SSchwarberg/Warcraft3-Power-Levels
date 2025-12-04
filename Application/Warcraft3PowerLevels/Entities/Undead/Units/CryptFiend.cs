using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Undead.Units
{
    public class CryptFiend : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Undead;
        public string Name { get; set; } = "Crypt Fiend";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 215;
        public int Wood { get; set; } = 40;
        public int Food { get; set; } = 3;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 29;
        public double AttackTime { get; set; } = 2.0;
        public int Range { get; set; } = 600;

        public int Health { get; set; } = 550;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
