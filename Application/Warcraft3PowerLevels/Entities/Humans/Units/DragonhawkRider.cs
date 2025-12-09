using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Units
{
    public class DragonhawkRider : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Human;
        public string Name { get; set; } = "Dragonhawk Rider";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 200;
        public int Wood { get; set; } = 30;
        public int Food { get; set; } = 3;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 21;
        public double AttackTime { get; set; } = 1.75;
        public int Range { get; set; } = 300;

        public int Health { get; set; } = 625;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
