using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.NightElves.Units
{
    public class DruidOfTheClaw_Humanoid : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.NightElf;
        public string Name { get; set; } = "Druid of the Claw";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 255;
        public int Wood { get; set; } = 80;
        public int Food { get; set; } = 4;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public int Attack { get; set; } = 21;
        public double AttackTime { get; set; } = 1.6;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 550;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
