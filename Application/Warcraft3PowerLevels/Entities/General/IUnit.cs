using Warcraft3PowerLevels.Entities.Enumerations;

namespace Warcraft3PowerLevels.Entities.General
{
    /// <summary>
    /// Interface representing a general unit in the game.
    /// </summary>
    public interface IUnit
    {
        public RaceEnum Race { get; set; }
        public string Name { get; set; }

        public int Tier { get; set; }
        public int Gold { get; set; }
        public int Wood { get; set; }
        public int Food { get; set; }
        
        public AttackTypeEnum AttackType { get; set; }
        public WeaponTypeEnum WeaponType { get; set; }
        public double Attack { get; set; }
        public double AttackTime { get; set; }
        public int Range { get; set; }

        public int Health { get; set; }
        public int Mana { get; set; }
        public double Armor { get; set; }
        public ArmorTypeEnum ArmorType { get; set; }
    }
}
