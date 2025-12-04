using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class Hawk_2 : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Hawk (Level 2)";
        public int Tier { get; set; } = 2;

        public int Health { get; set; } = 475;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 2;

        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;

        public int Attack { get; set; } = 15;
        public double AttackTime { get; set; } = 1.7;
        public int Range { get; set; } = 450;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;
    }
}
