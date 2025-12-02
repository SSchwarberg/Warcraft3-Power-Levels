using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Mercenaries
{
    public class OgreMauler : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Ogre Mauler";
        public int Tier { get; set; } = 3;
        public int Gold { get; set; } = 215;
        public int Wood { get; set; } = 0;
        public int Food { get; set; } = 4;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Normal;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Melee;
        public int Attack { get; set; } = 33;
        public double AttackTime { get; set; } = 1.6;
        public int Range { get; set; } = 100;

        public int Health { get; set; } = 900;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 3;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Heavy;
    }
}
