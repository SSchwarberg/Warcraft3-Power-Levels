using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class FirePanda : IUnit, ISummon
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Fire Panda";
        public int Tier { get; set; } = 3;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;

        public int Health { get; set; } = 1050;
        public int Mana { get; set; } = 0;

        public int Armor { get; set; } = 4;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;

        public double Attack { get; set; } = 45;
        public double AttackTime { get; set; } = 1.5;
        public int Range { get; set; } = 100;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Chaos;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
    }
}
