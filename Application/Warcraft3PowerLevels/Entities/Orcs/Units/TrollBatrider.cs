using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Orcs.Units
{
    public class TrollBatrider : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Orc;
        public string Name { get; set; } = "Troll Batrider";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 160;
        public int Wood { get; set; } = 40;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Siege;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 17;
        public double AttackTime { get; set; } = 1.8;
        public int Range { get; set; } = 300;

        public int Health { get; set; } = 325;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
