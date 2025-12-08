using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class DarkMinion_2 : IUnit, ISummon
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Dark Minion (Level 2)";
        public int Tier { get; set; } = 0;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;

        public int Health { get; set; } = 290;
        public int Mana { get; set; } = 0;

        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;

        public double Attack { get; set; } = 16;
        public double AttackTime { get; set; } = 2.0;
        public int Range { get; set; } = 90;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
    }
}
