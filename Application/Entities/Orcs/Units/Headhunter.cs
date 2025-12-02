using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Units
{
    public class Headhunter : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Orc;
        public string Name { get; set; } = "Headhunter";
        public int Tier { get; set; } = 1;
        public int Gold { get; set; } = 135;
        public int Wood { get; set; } = 20;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 25;
        public double AttackTime { get; set; } = 2.31;
        public int Range { get; set; } = 600;

        public int Health { get; set; } = 350;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
