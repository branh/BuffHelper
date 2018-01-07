namespace Pathfinder.Utility.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Text;

    public class Buff : INotifyPropertyChanged
    {
        private BuffType buffType;

        public string Name { get; set; }
        public readonly ObservableCollection<Modifier> Modifiers;

        public BuffType BuffType
        {
            get
            {
                return this.buffType;
            }
            set
            {
                if (this.buffType != value)
                {
                    this.buffType = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuffType"));
                }
            }
        }

        public string Description
        {
            get
            {
                StringBuilder description = new StringBuilder();
                for (int i = 0; i < this.Modifiers.Count - 1; ++i)
                {
                    this.AppendModifier(description, this.Modifiers[i]);
                    description.Append(", ");
                }
                if (this.Modifiers.Count > 0)
                {
                    this.AppendModifier(description, this.Modifiers[this.Modifiers.Count - 1]);
                }
                return description.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
            builder.Append(mod.Target.Name);
        }

        public static Buff CreateUninitializedBuff()
        {
            List<Modifier> modifiers = new List<Modifier>();
            modifiers.Add(Modifier.CreateUninitializedModifier());
            return new Buff("Unsaved", BuffType.Neutral, modifiers);
        }
    }
}
