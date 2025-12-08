using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Mercenaries
{
    public class SatyrShadowDancer : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Satyr Shadow Dancer";
        public int Tier { get; set; } = 0;
        public int Gold { get; set; } = 190;
        public int Wood { get; set; } = 20;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 25;
        public double AttackTime { get; set; } = 1.8;
        public int Range { get; set; } = 600;

        public int Health { get; set; } = 340;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
