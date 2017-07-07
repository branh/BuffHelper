namespace BuffHelper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    public class Model : INotifyPropertyChanged
    {
        private Dictionary<StatType, int> modifiers = new Dictionary<StatType, int>();
        private ObservableCollection<ActivatableBuff> buffs = new ObservableCollection<ActivatableBuff>();

        public ReadOnlyObservableCollection<ActivatableBuff> Buffs;
        public ReadOnlyDictionary<StatType, int> Modifiers;
        public event PropertyChangedEventHandler PropertyChanged;

        public string AllModifiers
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (KeyValuePair<StatType, int> kvPair in this.Modifiers)
                {
                    if (kvPair.Value > 0)
                    {
                        builder.Append('+');
                    }

                    if (kvPair.Value != 0)
                    {
                        builder.Append(kvPair.Value);
                        builder.Append(' ');
                        builder.Append(kvPair.Key);
                        builder.Append(", ");
                    }
                }

                // Remove final comma.
                if (builder.Length > 3)
                {
                    builder.Remove(builder.Length - 2, 2);
                }
                return builder.ToString();
            }
        }

        public Model(string FilePath)
        {
            // TODO: Read in starting values from file.
            throw new NotImplementedException();
        }

        public Model(IEnumerable<Buff> buffs)
        {
            foreach (Buff buff in buffs)
            {
                ActivatableBuff activeBuff = new ActivatableBuff(buff);
                activeBuff.PropertyChanged += ActiveBuff_PropertyChanged;
                this.buffs.Add(activeBuff);
            }
            this.Buffs = new ReadOnlyObservableCollection<ActivatableBuff>(this.buffs);
            this.Modifiers = new ReadOnlyDictionary<StatType, int>(this.modifiers);
        }

        public Model()
        {
            this.Buffs = new ReadOnlyObservableCollection<ActivatableBuff>(this.buffs);
            this.Modifiers = new ReadOnlyDictionary<StatType, int>(this.modifiers);
        }

        /// <summary>
        /// Calculates the modifier from buffs for a particular stat.
        /// </summary>
        /// <param name="stat">The particular stat to calculate.</param>
        /// <returns>Total modifier.
        /// TODO: Probably want to return the calculation as well.
        /// </returns>
        public int CalculateModifier(StatType stat)
        {
            if (this.Modifiers.ContainsKey(stat))
            {
                return this.Modifiers[stat];
            }

            int result = 0;
            Dictionary<ModifierType, int> componentModifiers = new Dictionary<ModifierType, int>();
            foreach (ActivatableBuff buff in this.Buffs)
            {
                if (buff.IsActive)
                {
                    Modifier relevantModifier = buff.Buff.Modifiers.SingleOrDefault(b => b.Target == stat);
                    if (relevantModifier == null)
                    {
                        continue;
                    }
                    else if (relevantModifier.Mod < 0 ||
                            relevantModifier.ModType == ModifierType.Untyped || relevantModifier.ModType == ModifierType.Dodge)
                    {
                        result += relevantModifier.Mod;
                    }
                    else if (!componentModifiers.ContainsKey(relevantModifier.ModType) ||
                             relevantModifier.Mod > componentModifiers[relevantModifier.ModType])
                    {
                        componentModifiers[relevantModifier.ModType] = relevantModifier.Mod;
                    }
                }
            }

            foreach (KeyValuePair<ModifierType, int> modType in componentModifiers)
            {
                result += modType.Value;
            }

            this.modifiers[stat] = result;
            return result;
        }


        public void CalculateAllModifiers()
        {
            this.modifiers.Clear();
            Dictionary<StatType, Dictionary<ModifierType, int> > tallies = 
                new Dictionary<StatType, Dictionary<ModifierType, int>>();

            foreach (ActivatableBuff buff in this.Buffs)
            {
                if (buff.IsActive)
                {
                    foreach (Modifier mod in buff.Buff.Modifiers)
                    {
                        if (!tallies.ContainsKey(mod.Target))
                        {
                            tallies[mod.Target] = new Dictionary<ModifierType, int>();
                            this.modifiers[mod.Target] = 0;
                        }

                        if (mod.Mod < 0 ||
                            mod.ModType == ModifierType.Untyped || mod.ModType == ModifierType.Dodge)
                        {
                            this.modifiers[mod.Target] += mod.Mod;
                        }
                        else if (!tallies[mod.Target].ContainsKey(mod.ModType) ||
                                 tallies[mod.Target][mod.ModType] < mod.Mod)
                        {
                            tallies[mod.Target][mod.ModType] = mod.Mod;
                        }
                    }
                }
            }

            foreach (StatType stat in tallies.Keys)
            {
                foreach (KeyValuePair<ModifierType, int> mod in tallies[stat])
                {
                    this.modifiers[stat] += mod.Value;
                }
            }
        }

        public void ClearAllBuffs()
        {
            this.modifiers.Clear();
            foreach (ActivatableBuff buff in this.Buffs)
            {
                buff.PropertyChanged -= this.ActiveBuff_PropertyChanged;
                buff.IsActive = false;
                buff.PropertyChanged += this.ActiveBuff_PropertyChanged;
            }
        }

        public void AddBuff(Buff buff)
        {
            ActivatableBuff activeBuff = new ActivatableBuff(buff);
            activeBuff.PropertyChanged += this.ActiveBuff_PropertyChanged;
            this.buffs.Add(activeBuff);
        }

        private void ActiveBuff_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ActivatableBuff activeBuff = (ActivatableBuff)sender;
            foreach (Modifier mod in activeBuff.Buff.Modifiers)
            {
                this.modifiers.Remove(mod.Target);
                this.CalculateModifier(mod.Target);
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllModifiers"));
        }
    }
}
