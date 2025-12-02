using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Humans.Units
{
    public class MortarTeam : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Human;
        public string Name { get; set; } = "Mortar Team";
        public int Tier { get; set; } = 2;
        public int Gold { get; set; } = 180;
        public int Wood { get; set; } = 70;
        public int Food { get; set; } = 3;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Siege;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.Ranged;
        public int Attack { get; set; } = 58;
        public double AttackTime { get; set; } = 3.5;
        public int Range { get; set; } = 1150;

        public int Health { get; set; } = 360;
        public int Mana { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Unarmored;
    }
}
