using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Summons
{
    public class DoomGuard_Air : IUnit, ISummon
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Doom Guard (Air)";
        public int Tier { get; set; } = 0;

        public int Gold { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 0;

        public int Health { get; set; } = 1600;
        public int Mana { get; set; } = 500;

        public int Armor { get; set; } = 3;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;

        public double Attack { get; set; } = 44.5;
        public double AttackTime { get; set; } = 1.8;
        public int Range { get; set; } = 600;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Chaos;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
    }
}
