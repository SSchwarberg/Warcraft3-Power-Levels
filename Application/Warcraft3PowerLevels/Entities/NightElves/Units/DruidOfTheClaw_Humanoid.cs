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
        public double Attack { get; set; } = 20.5;
        public double AttackTime { get; set; } = 1.5;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 430;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;
    }
}
