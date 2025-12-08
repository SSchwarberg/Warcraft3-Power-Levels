using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class DruidOfTheTalon_Crow : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Druid of the Talon (Crow Form)";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 135;
        public int Wood { get; set; } = 20;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public double Attack { get; set; } = 30;
        public double AttackTime { get; set; } = 1.75;
        public int Range { get; set; } = 600;

        public int Health { get; set; } = 340;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Unarmored;
    }
}
