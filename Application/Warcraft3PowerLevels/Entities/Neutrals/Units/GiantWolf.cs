using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Mercenaries
{
    public class GiantWolf : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Giant Wolf";
        public int Tier { get; set; } = 0;
        public int Gold { get; set; } = 215;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 3;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Piercing;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public double Attack { get; set; } = 19.5;
        public double AttackTime { get; set; } = 1.35;
        public int Range { get; set; } = 90;

        public int Health { get; set; } = 550;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 2;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;
    }
}
