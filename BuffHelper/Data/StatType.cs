namespace BuffHelper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public interface StatType
    {
        string Name { get; }
        int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats);
    }
 
    public static class StatTypes
    {
        public static StatType Str = new SimpleStatType("Str", 0);
        public static StatType Dex = new SimpleStatType("Dex", 1);
        public static StatType Con = new SimpleStatType("Con", 2);
        public static StatType Int = new SimpleStatType("Int", 3);
        public static StatType Wis = new SimpleStatType("Wis", 4);
        public static StatType Cha = new SimpleStatType("Cha", 5);
        public static StatType Skill = new SimpleStatType("Skill", 6);

        public static StatType Init = new DerivedStatType("Init", StatTypes.Dex, 7);
        public static StatType Fortitude = new DerivedStatType("Fort", StatTypes.Con, 8);
        public static StatType Reflex = new DerivedStatType("Ref", StatTypes.Dex, 9);
        public static StatType Will = new DerivedStatType("Will", StatTypes.Wis, 10);

        public static StatType MeleeHit = new DerivedStatType("Melee Attack", StatTypes.Str, 11);
        public static StatType RangedHit = new DerivedStatType("Ranged Attack", StatTypes.Dex, 12);
        public static StatType MeleeDamage = new DerivedStatType("Melee Damage", StatTypes.Str, 13);
        public static StatType RangedDamage = new DerivedStatType("Ranged Damage", StatTypes.Dex, 14);
        public static StatType CMB = new DerivedStatType("CMB", StatTypes.Str, 15);
        public static StatType CMD = new CMDStatType(16);
        
        public static StatType Dodge = new DerivedStatType("Dodge", StatTypes.Dex, 17);
        public static StatType Armor = new SimpleStatType("Armor", 18);
        public static StatType BaseAC = new SimpleStatType("AC", 19);

        public static StatType AC = new ACStatType();
        public static StatType touchAC = new TouchACStatType();
        public static StatType flatfootedAC = new FlatfootedACStatType();

        public static StatType Acrobatics = new SkillStatType("Acrobatics", StatTypes.Dex, 20);
        public static StatType Appraise = new SkillStatType("Appraise", StatTypes.Int, 21);
        public static StatType Bluff = new SkillStatType("Bluff", StatTypes.Cha, 22);
        public static StatType Climb = new SkillStatType("Climb", StatTypes.Str, 23);
        public static StatType Craft = new SkillStatType("Craft", StatTypes.Int, 24);
        public static StatType Diplomacy = new SkillStatType("Diplomacy", StatTypes.Cha, 25);
        public static StatType DisableDevice = new SkillStatType("Disable Device", StatTypes.Dex, 26);
        public static StatType Disguise = new SkillStatType("Disguise", StatTypes.Cha, 27);
        public static StatType EscapeArtist = new SkillStatType("Escape Artist", StatTypes.Dex, 28);
        public static StatType Fly = new SkillStatType("Fly", StatTypes.Dex, 29);
        public static StatType HandleAnimal = new SkillStatType("Handle Animal", StatTypes.Dex, 30);
        public static StatType Heal = new SkillStatType("Heal", StatTypes.Wis, 31);
        public static StatType Intimidate = new SkillStatType("Intimidate", StatTypes.Cha, 32);
        public static StatType Knowledge = new SkillStatType("Knowledge", StatTypes.Int, 33);
        public static StatType Linguistics = new SkillStatType("Linguistics", StatTypes.Int, 34);
        public static StatType Perception = new SkillStatType("Perception", StatTypes.Wis, 35);
        public static StatType Perform = new SkillStatType("Perform", StatTypes.Cha, 36);
        public static StatType Profession = new SkillStatType("Profession", StatTypes.Wis, 37);
        public static StatType Ride = new SkillStatType("Ride", StatTypes.Dex, 38);
        public static StatType SenseMotive = new SkillStatType("Sense Motive", StatTypes.Wis, 39);
        public static StatType SlightHand = new SkillStatType("Slight Of Hand", StatTypes.Dex, 40);
        public static StatType Spellcraft = new SkillStatType("Spellcraft", StatTypes.Int, 41);
        public static StatType Stealth = new SkillStatType("Stealth", StatTypes.Dex, 42);
        public static StatType Survival = new SkillStatType("Survival", StatTypes.Wis, 43);
        public static StatType Swim = new SkillStatType("Swim", StatTypes.Str, 44);
        public static StatType UMD = new SkillStatType("Use Magic Device", StatTypes.Cha, 45);

        public static StatType[] AllStatsList =
        {
            StatTypes.Str, StatTypes.Dex, StatTypes.Con, StatTypes.Int, StatTypes.Wis, StatTypes.Cha,
            StatTypes.Skill, StatTypes.Init,
            StatTypes.Fortitude, StatTypes.Reflex, StatTypes.Will,
            StatTypes.MeleeHit, StatTypes.MeleeDamage, StatTypes.RangedHit, StatTypes.RangedDamage,
            StatTypes.CMB, StatTypes.CMD,
            StatTypes.Dodge, StatTypes.Armor, StatTypes.BaseAC,

            /* Intentionally do not include AC, touchAC, and flatfootedAC */

            StatTypes.Acrobatics, StatTypes.Appraise, StatTypes.Bluff, StatTypes.Climb, StatTypes.Craft,
            StatTypes.Diplomacy, StatTypes.DisableDevice, StatTypes.Disguise,
            StatTypes.EscapeArtist, StatTypes.Fly, StatTypes.HandleAnimal, StatTypes.Heal,
            StatTypes.Intimidate, StatTypes.Knowledge, StatTypes.Linguistics,
            StatTypes.Perception, StatTypes.Perception, StatTypes.Profession, StatTypes.Ride,
            StatTypes.SenseMotive, StatTypes.SlightHand, StatTypes.Stealth, StatTypes.Survival, StatTypes.Swim,
            StatTypes.UMD
        };

        public static IEnumerable<Modifier> ModifyAllAttackRolls(int modifier)
        {
            return StatTypes.ModifyAllAttackRolls(modifier, ModifierTypes.Untyped);
        }

        public static IEnumerable<Modifier> ModifyAllAttackRolls(int modifier, ModifierType modType)
        {
            Modifier[] results = { new Modifier(modifier, StatTypes.MeleeHit, modType),
                                   new Modifier(modifier, StatTypes.RangedHit, modType)};
            return results;
        }

        public static IEnumerable<Modifier> ModifyAllDamageRolls(int modifier)
        {
            return StatTypes.ModifyAllDamageRolls(modifier, ModifierTypes.Untyped);
        }

        public static IEnumerable<Modifier> ModifyAllDamageRolls(int modifier, ModifierType modType)
        {
            Modifier[] results = { new Modifier(modifier, StatTypes.MeleeDamage, modType),
                                   new Modifier(modifier, StatTypes.RangedDamage, modType)};
            return results;
        }

        public static IEnumerable<Modifier> ModifyAllSaves(int modifier)
        {
            return StatTypes.ModifyAllSaves(modifier, ModifierTypes.Untyped);
        }

        public static IEnumerable<Modifier> ModifyAllSaves(int modifier, ModifierType modType)
        {
            Modifier[] results = { new Modifier(modifier, StatTypes.Fortitude, modType),
                                   new Modifier(modifier, StatTypes.Reflex, modType),
                                   new Modifier(modifier, StatTypes.Will, modType)};
            return results;
        }

        public static bool IsKeyStat(this StatType stat)
        {
            return StatTypes.Str == stat ||
                StatTypes.Dex == stat ||
                StatTypes.Con == stat ||
                StatTypes.Int == stat ||
                StatTypes.Wis == stat ||
                StatTypes.Cha == stat ||
                StatTypes.BaseAC == stat ||
                StatTypes.Dodge == stat ||
                StatTypes.Armor == stat;
        }

        private class SimpleStatType : StatType, IIndexable
        {
            public string Name { get; private set; }

            public int index { get; }

            public SimpleStatType(string name, int index)
            {
                this.index = index;
                this.Name = name;
            }

            public virtual int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                if (!baseStats.ContainsKey(this))
                {
                    return 0;
                }
                return baseStats[this];
            }
        }

        private class DerivedStatType : SimpleStatType
        {
            // Public setter for WeaponFinesse, etc.
            public StatType BaseStat { get; set; }

            public DerivedStatType(string name, StatType baseStat, int index) : base(name, index)
            {
                this.BaseStat = baseStat;
            }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                // Todo: is rounding ever an issue?
                return base.CalculateTotalModifier(baseStats) + (BaseStat.CalculateTotalModifier(baseStats) / 2);
            }
        }

        private class SkillStatType : DerivedStatType
        {
            public SkillStatType(string name, StatType basedStat, int index) : base(name, basedStat, index) { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                return base.CalculateTotalModifier(baseStats) + StatTypes.Skill.CalculateTotalModifier(baseStats);
            }
        }

        private class TouchACStatType : DerivedStatType
        {
            public TouchACStatType() : base("touch", StatTypes.BaseAC, -1) { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                return base.CalculateTotalModifier(baseStats) + StatTypes.Dodge.CalculateTotalModifier(baseStats);
            }
        }

        private class FlatfootedACStatType : DerivedStatType
        {
            public FlatfootedACStatType() : base("flat-footed", StatTypes.BaseAC, -1) { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                int dodgePenalty = Math.Min(StatTypes.Dodge.CalculateTotalModifier(baseStats), 0);
                return base.CalculateTotalModifier(baseStats) + StatTypes.Armor.CalculateTotalModifier(baseStats);
            }
        }

        private class ACStatType : DerivedStatType
        {
            public ACStatType() : base("AC", StatTypes.BaseAC, -1) { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                return base.CalculateTotalModifier(baseStats) + 
                    StatTypes.Armor.CalculateTotalModifier(baseStats) +
                    StatTypes.Dodge.CalculateTotalModifier(baseStats);
            }
        }

        private class CMDStatType : SimpleStatType
        {
            public CMDStatType(int index) : base("CMD", index) { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                return base.CalculateTotalModifier(baseStats) + 
                    StatTypes.Str.CalculateTotalModifier(baseStats) + 
                    StatTypes.Dex.CalculateTotalModifier(baseStats);
            }
        }
    }
}
