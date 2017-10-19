namespace BuffHelper.Data
{
    using System;

    public interface IModifierType
    {
        string Name { get; }
        bool IsStackable { get; }
    }

    public class ModifierType : IModifierType
    {
        public string Name { get; private set; }
        public bool IsStackable { get; private set; }

        public ModifierType()
        {
            throw new InvalidOperationException("Constructor only provided for x:DataType");
        }

        public ModifierType(string name, bool stackable = false)
        {
            this.Name = name;
            this.IsStackable = stackable;
        }
    }

    public static class ModifierTypes
    {
        public static ModifierType Untyped = new ModifierType("Untyped", stackable : true);
        public static ModifierType Size = new ModifierType("Size");
        public static ModifierType Trait = new ModifierType("Trait");
        public static ModifierType Alchemical = new ModifierType("Alchemical");
        public static ModifierType Competence = new ModifierType("Competence");
        public static ModifierType Inherent = new ModifierType("Inherent");
        public static ModifierType Enhancement = new ModifierType("Enhancement");
        public static ModifierType Luck = new ModifierType("Luck");
        public static ModifierType Morale = new ModifierType("Morale");
        public static ModifierType Resistance = new ModifierType("Resistance");
        public static ModifierType Profane = new ModifierType("Profane");
        public static ModifierType Sacred = new ModifierType("Sacred");
        public static ModifierType Deflection = new ModifierType("Deflection");
        public static ModifierType Dodge = new ModifierType("Dodge", stackable : true);
        public static ModifierType NaturalArmor = new ModifierType("Natural Armor");
        public static ModifierType Shield = new ModifierType("Shield");

        public static ModifierType[] AllModifierTypesList = 
        {
            ModifierTypes.Untyped, ModifierTypes.Size, ModifierTypes.Trait,
            ModifierTypes.Alchemical, ModifierTypes.Competence, ModifierTypes.Inherent, ModifierTypes.Enhancement,
            ModifierTypes.Luck, ModifierTypes.Morale, ModifierTypes.Resistance,
            ModifierTypes.Profane, ModifierTypes.Sacred,
            ModifierTypes.Deflection, ModifierTypes.Dodge, ModifierTypes.NaturalArmor, ModifierTypes.Shield 
        };
    }
}
