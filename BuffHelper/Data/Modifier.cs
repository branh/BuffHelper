namespace BuffHelper.Data
{
    using System;

    public class Modifier
    {
        public int Mod { get; private set; }
        public ModifierType ModType { get; private set; }
        public StatType Target { get; private set; }

        public Modifier(int mod, StatType target, ModifierType modType)
        {
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
            this.ModType = ModifierType.Untyped;
        }
    }
}
