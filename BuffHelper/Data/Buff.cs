namespace BuffHelper.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    public class Buff
    {
        public string Name { get; private set; }
        public BuffType BuffType { get; private set; }
        public readonly ObservableCollection<Modifier> Modifiers;

        public string Description
        {
            get
            {
                StringBuilder description = new StringBuilder();
                for (int i = 0; i < this.Modifiers.Count - 1; ++i)
                {
                    this.AppendModifier(description, this.Modifiers[i]);
                    description.Append(',');
                }
                if (this.Modifiers.Count > 0)
                {
                    this.AppendModifier(description, this.Modifiers[this.Modifiers.Count - 1]);
                }
                return description.ToString();
            }
        }

        public Buff (string name, BuffType buffType, ICollection<Modifier> modifiers)
        {
            this.Name = name;
            this.BuffType = buffType;
            this.Modifiers = new ObservableCollection<Modifier>(modifiers);
        }

        private void AppendModifier(StringBuilder builder, Modifier mod)
        {
            if (mod.Mod >= 0)
            {
                builder.Append('+');
            }
            builder.Append(mod.Mod);
            builder.Append(' ');
            builder.Append(mod.Target);
        }
    }
}
