namespace Pathfinder.Utility.Data
{
    public interface IModifierType
    {
        string Name { get; }
        bool IsStackable { get; }
    }

    public class ModifierType : IModifierType, IIndexable
    {
        public string Name { get; private set; }
        public bool IsStackable { get; private set; }
        public int index { get; }

        public ModifierType(string name, int index, bool stackable = false)
        {
            this.Name = name;
            this.IsStackable = stackable;
            this.index = index;
        }
    }

    public static class ModifierTypes
    {
        public static ModifierType Untyped = new ModifierType("Untyped", 0, stackable : true);
        public static ModifierType Size = new ModifierType("Size", 1);
        public static ModifierType Trait = new ModifierType("Trait", 2);
        public static ModifierType Alchemical = new ModifierType("Alchemical", 3);
        public static ModifierType Competence = new ModifierType("Competence", 4);
        public static ModifierType Inherent = new ModifierType("Inherent", 5);
        public static ModifierType Enhancement = new ModifierType("Enhancement", 6);
        public static ModifierType Luck = new ModifierType("Luck", 7);
        public static ModifierType Morale = new ModifierType("Morale", 8);
        public static ModifierType Resistance = new ModifierType("Resistance", 9);
        public static ModifierType Profane = new ModifierType("Profane", 10);
        public static ModifierType Sacred = new ModifierType("Sacred", 11);
        public static ModifierType Deflection = new ModifierType("Deflection", 12);
        public static ModifierType Dodge = new ModifierType("Dodge", 13, stackable : true);
        public static ModifierType NaturalArmor = new ModifierType("Natural Armor", 14);
        public static ModifierType Shield = new ModifierType("Shield", 15);

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
