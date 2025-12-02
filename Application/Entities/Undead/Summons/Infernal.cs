using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class Infernal : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Infernal";
        public int Tier { get; set; } = 5;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;

        public int Health { get; set; } = 1500;
        public int Mana { get; set; } = 0;

        public int Armor { get; set; } = 8;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;

        public int Attack { get; set; } = 56;
        public double AttackTime { get; set; } = 1.7;
        public int Range { get; set; } = 100;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Chaos;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
    }
}
