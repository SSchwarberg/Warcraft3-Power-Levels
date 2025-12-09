using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Units
{
    public class Grunt : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Orc;
        public string Name { get; set; } = "Grunt";
        public int Tier { get; set; } = 1;
        public int Gold { get; set; } = 200;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 3;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public double Attack { get; set; } = 19.5;
        public double AttackTime { get; set; } = 1.6;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 700;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;
    }
}
