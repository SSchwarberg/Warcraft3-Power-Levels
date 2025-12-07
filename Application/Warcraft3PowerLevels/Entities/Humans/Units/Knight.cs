using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Units
{
    public class Knight : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Human;
        public string Name { get; set; } = "Knight";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 245;
        public int Wood { get; set; } = 60;
        public int Food { get; set; } = 4;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public double Attack { get; set; } = 34;
        public double AttackTime { get; set; } = 1.4;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 885;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 5;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;
    }
}
