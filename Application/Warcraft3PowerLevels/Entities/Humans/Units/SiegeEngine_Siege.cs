using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Units
{
    public class SiegeEngine_Siege : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Human;
        public string Name { get; set; } = "Siege Engine (Siege)";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 195;
        public int Wood { get; set; } = 60;
        public int Food { get; set; } = 3;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Siege;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 50;
        public double AttackTime { get; set; } = 2.1;
        public int Range { get; set; } = 192;

        public int Health { get; set; } = 700;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Fortified;
    }
}
