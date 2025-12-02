using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Mercenaries
{
    public class HarpyRogue : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Harpy Rogue";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 145;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 2;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public int Attack { get; set; } = 20;
        public double AttackTime { get; set; } = 1.7;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 450;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 1;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
