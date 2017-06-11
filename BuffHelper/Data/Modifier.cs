namespace BuffHelper.Data
{
    public class Modifier
    {
        public int Mod { get; private set; }
        public ModifierType ModType { get; private set; }
        public StatType Target { get; private set; }

        public Modifier(int mod, ModifierType modType, StatType target)
        {
            this.Mod = mod;
            this.ModType = modType;
            this.Target = target;
        }
    }
}
