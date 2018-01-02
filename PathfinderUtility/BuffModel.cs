namespace Pathfinder.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using Pathfinder.Utility.Data;

    public class BuffModel : INotifyPropertyChanged
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
                foreach (StatType stat in this.Modifiers.Keys)
                {
                    int finalModifier = stat.CalculateTotalModifier(this.Modifiers);
                    if (finalModifier > 0)
                    {
                        builder.Append('+');
                    }

                    if (finalModifier != 0)
                    {
                        builder.Append(finalModifier);
                        builder.Append(' ');
                        builder.Append(stat.Name);
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

        public BuffModel(string FilePath)
        {
            // TODO: Read in starting values from file.
            throw new NotImplementedException();
        }

        public BuffModel(IEnumerable<Buff> buffs)
        {
            foreach (Buff buff in buffs)
            {
                ActivatableBuff activeBuff = new ActivatableBuff(buff);
                activeBuff.PropertyChanged += ActiveBuff_PropertyChanged;
                this.buffs.Add(activeBuff);
            }
            this.Buffs = new ReadOnlyObservableCollection<ActivatableBuff>(this.buffs);
            this.Modifiers = new ReadOnlyDictionary<StatType, int>(this.modifiers);
            this.CalculateAllModifiers();
        }

        public BuffModel()
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
        public void CalculateBaseModifier(StatType stat)
        {
            if (this.Modifiers.ContainsKey(stat))
            {
                return;
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
                    else if (relevantModifier.Mod < 0 || relevantModifier.ModType.IsStackable)
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

                        if (mod.Mod < 0 || mod.ModType.IsStackable)
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
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllModifiers"));
        }

        public void AddBuff(Buff buff)
        {
            ActivatableBuff activeBuff = new ActivatableBuff(buff);
            activeBuff.PropertyChanged += this.ActiveBuff_PropertyChanged;
            this.buffs.Add(activeBuff);
        }

        public void RemoveBuff(ActivatableBuff buff)
        {
            buff.PropertyChanged -= this.ActiveBuff_PropertyChanged;
            this.buffs.Remove(buff);
            buff.IsActive = false;
            this.UpdateBuff(buff);
        }

        public void UpdateBuff(ActivatableBuff activeBuff)
        {
            bool fullRecalc = activeBuff.Buff.Modifiers.Where(mod => mod.Target.IsKeyStat()).Any();
            if (fullRecalc)
            {
                this.CalculateAllModifiers();
            }
            else
            {
                foreach (Modifier mod in activeBuff.Buff.Modifiers)
                {
                    this.modifiers.Remove(mod.Target);
                    this.CalculateBaseModifier(mod.Target);
                }
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllModifiers"));
        }

        private void ActiveBuff_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ActivatableBuff activeBuff = (ActivatableBuff)sender;
            UpdateBuff(activeBuff);
        }
    }
}
