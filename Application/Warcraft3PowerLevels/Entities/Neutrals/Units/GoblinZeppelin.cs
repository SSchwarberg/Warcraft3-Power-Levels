using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;

namespace Warcraft3PowerLevels.Entities.Neutral.Mercenaries
{
    public class GoblinZeppelin : IUnit
    {
        public RaceEnum Race { get; set; } = RaceEnum.Neutral;
        public string Name { get; set; } = "Goblin Zeppelin";
        public int Tier { get; set; } = 0;
        public int Gold { get; set; } = 240;
        public int Wood { get; set; } = 60;
        public int Food { get; set; } = 1;

        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.None;
        public WeaponTypeEnum WeaponType { get; set; } = WeaponTypeEnum.None;
        public double Attack { get; set; } = 0.0;
        public double AttackTime { get; set; } = 0.0;
        public int Range { get; set; } = 0;

        public int Health { get; set; } = 575;
        public int Mana { get; set; } = 0;
        public double Armor { get; set; } = 0;
        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Light;
    }
}
