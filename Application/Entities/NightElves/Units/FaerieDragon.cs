using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class FaerieDragon : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Faerie Dragon";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 155;
        public int Wood { get; set; } = 30;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Magic;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 19;
        public double AttackTime { get; set; } = 1.5;
        public int Range { get; set; } = 500;

        public int Health { get; set; } = 450;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 3;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
