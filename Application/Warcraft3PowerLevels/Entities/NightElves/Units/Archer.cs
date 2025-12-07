using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    /// <summary>
    /// Class representing the Archer unit for
    /// </summary>
    public class Archer : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Archer";
        public int Tier { get; set; } = 1;
        public int Gold { get; set; } = 130;
        public int Wood { get; set; } = 10;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 17;
        public double AttackTime { get; set; } = 1.5;
        public int Range { get; set; } = 500;

        public int Health { get; set; } = 275;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
