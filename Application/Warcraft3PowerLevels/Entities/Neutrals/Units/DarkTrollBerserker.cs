using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Mercenaries
{
    public class DarkTrollBerserker : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Dark Troll Berserker";
        public int Tier { get; set; } = 0;
        public int Gold { get; set; } = 245;
        public int Wood { get; set; } = 30;
        public int Food { get; set; } = 3;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public double Attack { get; set; } = 32.5;
        public double AttackTime { get; set; } = 1.6;
        public int Range { get; set; } = 500;

        public int Health { get; set; } = 450;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Medium;
    }
}
