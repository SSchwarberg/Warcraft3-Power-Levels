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

        protected double baseAttack;
        protected double baseAttackTime;
        protected int baseRange;
        protected double baseArmor;

        public RaceEnum Race { get; set; }
        public string Name { get; set; } = "";

        public int Tier { get; set; }
        public int Gold { get; set; }
        public int Wood { get; set; }
        public int Food { get; set; } = 5;

        public int Health
        {
            get => (int)(100 + 25 * Strength);
            set { }
        }

        public int Mana
        {
            get => (int)(15 * Intelligence);
            set { }
        }

        public double Armor
        {
            get => (baseArmor + (Agility * 0.3));
            set { }
        }

        public double Attack
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

                return (baseAttack + primaryBonus);
            }
            set { }
        }

        public double AttackTime
        {
            get => baseAttackTime;
            set { }
        }


        /// <summary>
        /// Calculates the modified attack time based on the hero's agility.
        /// </summary>
        public double ModifiedAttackTime => Math.Round(AttackTime / (1 + Agility * 0.02),2);


        /// <summary>
        /// The attack range of the hero.
        /// </summary>
        public int Range
        {
            get => baseRange;
            set { }
        }

        public ArmorTypeEnum ArmorType { get; set; } = ArmorTypeEnum.Hero;
        public AttackTypeEnum AttackType { get; set; } = AttackTypeEnum.Hero;
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

        protected void SetBaseCombat(double attack, double attackTime, int range, int armor)
        {
            baseAttack = attack;
            baseAttackTime = attackTime;
            baseRange = range;
            baseArmor = armor;
        }
    }
}
