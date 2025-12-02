using Warcraft3PowerLevels.Entities.Enumerations;

namespace Warcraft3PowerLevels.Entities.General
{
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
    }

}
