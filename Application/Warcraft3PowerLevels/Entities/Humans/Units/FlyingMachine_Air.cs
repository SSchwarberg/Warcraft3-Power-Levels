using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Units
{
    public class FlyingMachine_Air : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Human;
        public string Name { get; set; } = "Flying Machine (Air)";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 100;
        public int Wood { get; set; } = 30;
        public int Food { get; set; } = 1;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 18.5;
        public double AttackTime { get; set; } = 2.0;
        public int Range { get; set; } = 500;

        public int Health { get; set; } = 250;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
