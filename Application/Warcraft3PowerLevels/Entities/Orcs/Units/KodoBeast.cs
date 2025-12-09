using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Units
{
    public class KodoBeast : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Orc;
        public string Name { get; set; } = "Kodo Beast";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 255;
        public int Wood { get; set; } = 60;
        public int Food { get; set; } = 4;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 18;
        public double AttackTime { get; set; } = 1.44;
        public int Range { get; set; } = 500;

        public int Health { get; set; } = 1000;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Unarmored;
    }
}
