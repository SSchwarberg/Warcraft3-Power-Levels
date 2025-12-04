using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class HippogryphRider : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Hippogryph Rider";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 270; // 130 + 140
        public int Wood { get; set; } = 30;  // 10 + 20
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 17;
        public double AttackTime { get; set; } = 1.1;
        public int Range { get; set; } = 400;

        public int Health { get; set; } = 780;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
