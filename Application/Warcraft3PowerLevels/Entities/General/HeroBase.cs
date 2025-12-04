using Warcraft3PowerLevels.Entities.Enumerations;

namespace Warcraft3PowerLevels.Entities.General
{
    public abstract class HeroBase : IHero
    {
        // --------------------------
        // Stored base values (raw)
        // --------------------------
        protected int baseStrength;
        protected int baseAgility;
        protected int baseIntelligence;

        protected double gainStr;
        protected double gainAgi;
        protected double gainInt;

        protected int baseAttack;
        protected double baseAttackTime;
        protected int baseRange;
        protected int baseArmor;

        public RaceEnum Race { get; set; }
        public string Name { get; set; } = "";

        public int Tier { get; set; } = 3;
        public int Gold { get; set; }
        public int Wood { get; set; }
        public int Food { get; set; } = 5;

        public int Health
        {
            get => (int)(25 * Strength);
            set { }
        }

        public int Mana
        {
            get => (int)(15 * Intelligence);
            set { }
        }

        public int Armor
        {
            get => (int)(baseArmor + (Agility * 0.2));
            set { }
        }

        public int Attack
        {
            get
            {
                double primaryBonus = PrimaryAttribute switch
                {
                    PrimaryAttributeEnum.Strength => Strength - baseStrength,
                    PrimaryAttributeEnum.Agility => Agility - baseAgility,
                    PrimaryAttributeEnum.Intelligence => Intelligence - baseIntelligence,
                    _ => 0
                };

                return (int)(baseAttack + primaryBonus);
            }
            set { }
        }

        public double AttackTime
        {
            get => baseAttackTime;
            set { }
        }

        public int Range
        {
            get => baseRange;
            set { }
        }

        public ArmorTypeEnum ArmorType { get; set; }
        public AttackTypeEnum AttackType { get; set; }
        public WeaponTypeEnum WeaponType { get; set; }

        // --------------------------
        // IHero — Levels & Attributes
        // --------------------------
        public int Level { get; set; } = 1;

        public PrimaryAttributeEnum PrimaryAttribute { get; set; }

        public int Strength => (int)(baseStrength + gainStr * (Level - 1));

        public int Agility => (int)(baseAgility + gainAgi * (Level - 1));

        public int Intelligence => (int)(baseIntelligence + gainInt * (Level - 1));


        public double StrengthGain
        {
            get => gainStr;
            set => gainStr = value;
        }

        public double AgilityGain
        {
            get => gainAgi;
            set => gainAgi = value;
        }

        public double IntelligenceGain
        {
            get => gainInt;
            set => gainInt = value;
        }

        // --------------------------
        // Helper for setting base stats in hero constructors
        // --------------------------
        protected void SetBaseAttributes(int str, int agi, int intel,
                                         double strGain, double agiGain, double intGain)
        {
            baseStrength = str;
            baseAgility = agi;
            baseIntelligence = intel;

            gainStr = strGain;
            gainAgi = agiGain;
            gainInt = intGain;
        }

        protected void SetBaseCombat(int attack, double attackTime, int range, int armor)
        {
            baseAttack = attack;
            baseAttackTime = attackTime;
            baseRange = range;
            baseArmor = armor;
        }
    }
}
