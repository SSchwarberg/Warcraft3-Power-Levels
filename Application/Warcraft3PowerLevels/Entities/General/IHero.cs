using Warcraft3PowerLevels.Entities.Enumerations;

namespace Warcraft3PowerLevels.Entities.General
{
    /// <summary>
    /// Interface representing a hero unit in the game.
    /// </summary>
    public interface IHero : IUnit
    {
        int Level { get; set; }

        PrimaryAttributeEnum PrimaryAttribute { get; set; }

        int Strength { get; }
        int Agility { get; }
        int Intelligence { get; }

        double StrengthGain { get; }
        double AgilityGain { get; }
        double IntelligenceGain { get; }
        double ModifiedAttackTime { get; }
    }

}
