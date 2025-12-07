using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class Hawk_1 : IUnit, ISummon
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Hawk (Level 1)";
        public int Tier { get; set; } = 1;

        public int Health { get; set; } = 350;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 1;

        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;

        public double Attack { get; set; } = 11;
        public double AttackTime { get; set; } = 1.7;
        public int Range { get; set; } = 450;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;
    }
}
