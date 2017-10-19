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
        public static StatType Str = new SimpleStatType("Str");
        public static StatType Dex = new SimpleStatType("Dex");
        public static StatType Con = new SimpleStatType("Con");
        public static StatType Int = new SimpleStatType("Int");
        public static StatType Wis = new SimpleStatType("Wis");
        public static StatType Cha = new SimpleStatType("Cha");
        public static StatType Skill = new SimpleStatType("Skill");

        public static StatType Init = new DerivedStatType("Init", StatTypes.Dex);
        public static StatType Reflex = new DerivedStatType("Ref", StatTypes.Dex);
        public static StatType Fortitude = new DerivedStatType("Fort", StatTypes.Con);
        public static StatType Will = new DerivedStatType("Will", StatTypes.Wis);

        public static StatType MeleeHit = new DerivedStatType("Melee Attack", StatTypes.Str);
        public static StatType RangedHit = new DerivedStatType("Ranged Attack", StatTypes.Dex);
        public static StatType MeleeDamage = new DerivedStatType("Melee Damage", StatTypes.Str);
        public static StatType RangedDamage = new DerivedStatType("Ranged Damage", StatTypes.Dex);
        public static StatType CMB = new DerivedStatType("CMB", StatTypes.Str);
        public static StatType CMD = new CMDStatType();
        
        public static StatType Dodge = new DerivedStatType("Dodge", StatTypes.Dex);
        public static StatType Armor = new SimpleStatType("Armor");
        public static StatType BaseAC = new SimpleStatType("AC");

        public static StatType AC = new ACStatType();
        public static StatType touchAC = new TouchACStatType();
        public static StatType flatfootedAC = new FlatfootedACStatType();

        public static StatType Acrobatics = new SkillStatType("Acrobatics", StatTypes.Dex);
        public static StatType Appraise = new SkillStatType("Appraise", StatTypes.Int);
        public static StatType Bluff = new SkillStatType("Bluff", StatTypes.Cha);
        public static StatType Climb = new SkillStatType("Climb", StatTypes.Str);
        public static StatType Craft = new SkillStatType("Craft", StatTypes.Int);
        public static StatType Diplomacy = new SkillStatType("Diplomacy", StatTypes.Cha);
        public static StatType DisableDevice = new SkillStatType("Disable Device", StatTypes.Dex);
        public static StatType Disguise = new SkillStatType("Disguise", StatTypes.Cha);
        public static StatType EscapeArtist = new SkillStatType("Escape Artist", StatTypes.Dex);
        public static StatType Fly = new SkillStatType("Fly", StatTypes.Dex);
        public static StatType HandleAnimal = new SkillStatType("Handle Animal", StatTypes.Dex);
        public static StatType Heal = new SkillStatType("Heal", StatTypes.Wis);
        public static StatType Intimidate = new SkillStatType("Intimidate", StatTypes.Cha);
        public static StatType Knowledge = new SkillStatType("Knowledge", StatTypes.Int);
        public static StatType Linguistics = new SkillStatType("Linguistics", StatTypes.Int);
        public static StatType Perception = new SkillStatType("Perception", StatTypes.Wis);
        public static StatType Perform = new SkillStatType("Perform", StatTypes.Cha);
        public static StatType Profession = new SkillStatType("Profession", StatTypes.Wis);
        public static StatType Ride = new SkillStatType("Ride", StatTypes.Dex);
        public static StatType SenseMotive = new SkillStatType("Sense Motive", StatTypes.Wis);
        public static StatType SlightHand = new SkillStatType("Slight Of Hand", StatTypes.Dex);
        public static StatType Spellcraft = new SkillStatType("Spellcraft", StatTypes.Int);
        public static StatType Stealth = new SkillStatType("Stealth", StatTypes.Dex);
        public static StatType Survival = new SkillStatType("Survival", StatTypes.Wis);
        public static StatType Swim = new SkillStatType("Swim", StatTypes.Str);
        public static StatType UMD = new SkillStatType("Use Magic Device", StatTypes.Cha);

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

        private class SimpleStatType : StatType
        {
            public string Name { get; private set; }

            public SimpleStatType(string name)
            {
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

            public DerivedStatType(string name, StatType baseStat) : base(name) { this.BaseStat = baseStat; }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                // Todo: is rounding ever an issue?
                return base.CalculateTotalModifier(baseStats) + (BaseStat.CalculateTotalModifier(baseStats) / 2);
            }
        }

        private class SkillStatType : DerivedStatType
        {
            public SkillStatType(string name, StatType basedStat) : base(name, basedStat) { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                return base.CalculateTotalModifier(baseStats) + StatTypes.Skill.CalculateTotalModifier(baseStats);
            }
        }

        private class TouchACStatType : DerivedStatType
        {
            public TouchACStatType() : base("touch", StatTypes.BaseAC) { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                return base.CalculateTotalModifier(baseStats) + StatTypes.Dodge.CalculateTotalModifier(baseStats);
            }
        }

        private class FlatfootedACStatType : DerivedStatType
        {
            public FlatfootedACStatType() : base("flat-footed", StatTypes.BaseAC) { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                int dodgePenalty = Math.Min(StatTypes.Dodge.CalculateTotalModifier(baseStats), 0);
                return base.CalculateTotalModifier(baseStats) + StatTypes.Armor.CalculateTotalModifier(baseStats);
            }
        }

        private class ACStatType : DerivedStatType
        {
            public ACStatType() : base("AC", StatTypes.BaseAC) { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                return base.CalculateTotalModifier(baseStats) + 
                    StatTypes.Armor.CalculateTotalModifier(baseStats) +
                    StatTypes.Dodge.CalculateTotalModifier(baseStats);
            }
        }

        private class CMDStatType : SimpleStatType
        {
            public CMDStatType() : base("CMD") { }

            public override int CalculateTotalModifier(ReadOnlyDictionary<StatType, int> baseStats)
            {
                return base.CalculateTotalModifier(baseStats) + 
                    StatTypes.Str.CalculateTotalModifier(baseStats) + 
                    StatTypes.Dex.CalculateTotalModifier(baseStats);
            }
        }
    }
}
