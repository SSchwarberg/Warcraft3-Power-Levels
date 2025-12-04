using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Units
{
    public class FlyingMachine : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Human;
        public string Name { get; set; } = "Flying Machine";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 90;
        public int Wood { get; set; } = 30;
        public int Food { get; set; } = 1;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 8;
        public double AttackTime { get; set; } = 2.5;
        public int Range { get; set; } = 500;

        public int Health { get; set; } = 200;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
