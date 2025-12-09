using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class HippogryphRider : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Hippogryph Rider";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 290;
        public int Wood { get; set; } = 30;
        public int Food { get; set; } = 4;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 17;
        public double AttackTime { get; set; } = 1.1;
        public int Range { get; set; } = 400;

        public int Health { get; set; } = 800;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
