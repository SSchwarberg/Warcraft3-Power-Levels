using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class Bear_3 : IUnit, ISummon
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Summoned Bear (Level 3)";
        public int Tier { get; set; } = 0;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;

        public int Health { get; set; } = 1200;
        public int Mana { get; set; } = 0;

        public int Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;

        public double Attack { get; set; } = 39;
        public double AttackTime { get; set; } = 1.5;
        public int Range { get; set; } = 128;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
    }
}
