using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class FirePanda : IUnit, ISummon
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Fire Panda";
        public int Tier { get; set; } = 0;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;

        public int Health { get; set; } = 1100;
        public int Mana { get; set; } = 0;

        public int Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;

        public double Attack { get; set; } = 75;
        public double AttackTime { get; set; } = 1.35;
        public int Range { get; set; } = 128;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
    }
}
