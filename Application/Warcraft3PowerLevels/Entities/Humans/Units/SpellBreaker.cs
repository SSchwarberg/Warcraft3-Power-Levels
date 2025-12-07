using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Units
{
    public class SpellBreaker : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Human;
        public string Name { get; set; } = "Spell Breaker";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 215;
        public int Wood { get; set; } = 30;
        public int Food { get; set; } = 3;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 14;
        public double AttackTime { get; set; } = 1.9;
        public int Range { get; set; } = 250;

        public int Health { get; set; } = 600;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 3;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
