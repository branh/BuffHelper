namespace BuffHelper.Data
{
    using System;
    using System.Diagnostics;

    public class Modifier
    {
        public int Mod { get; set; }
        public ModifierType ModType { get; set; }
        public StatType Target { get; set; }

        public Modifier(int mod, StatType target, ModifierType modType)
        {
            Debug.Assert(target != StatTypes.AC, "Did you mean BaseAC?");

            this.Mod = mod;
            this.ModType = modType;
            this.Target = target;
        }

        public Modifier(int mod, StatType target)
        {
            if (mod > 0)
            {
                throw new ArgumentException("Specify modifier type");
            }

            this.Mod = mod;
            this.Target = target;
            this.ModType = ModifierTypes.Untyped;
        }

        public static Modifier CreateUninitializedModifier()
        {
            return new Modifier(0, StatTypes.Skill);
        }
    }
}
