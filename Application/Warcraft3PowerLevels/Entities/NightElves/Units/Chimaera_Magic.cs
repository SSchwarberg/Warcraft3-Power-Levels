using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class Chimaera_Magic : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Chimaera (Magic)";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 330;
        public int Wood { get; set; } = 70;
        public int Food { get; set; } = 5;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Magic;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 75;
        public double AttackTime { get; set; } = 2.5;
        public int Range { get; set; } = 450;

        public int Health { get; set; } = 1000;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
