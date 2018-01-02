namespace BuffHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using BuffHelper.Data;
    using Pathfinder.Utility;
    using Pathfinder.Utility.Data;

    class ViewModel : INotifyPropertyChanged, IDisposable
    {
        private BuffModel model;
        private int currentFilter;

        public FilterType[] Filters = { NoFilter.Instance, ActiveFilter.Instance, BuffFilter.Instance, BaneFilter.Instance };

        public string AllModifiers
        {
            get
            {
                return this.model.AllModifiers;
            }
        }

        public int CurrentFilterIndex
        {
            get { return this.currentFilter; }
            set
            {
                if (this.currentFilter != value)
                {
                    this.currentFilter = value;
                    this.NotifyPropertyChanged("CurrentFilter");
                    this.NotifyPropertyChanged("Buffs");
                }
            }
        }

        public List<ActivatableBuff> Buffs
        {
            get
            {
                return this.model.Buffs.Where(x => this.Filters[this.currentFilter].Filter(x)).ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            this.model = new BuffModel(PresetBuffList.DefaultConditionList);
            this.currentFilter = 0;
            this.model.PropertyChanged += this.OnNotifyPropertyChanged;
        }

        public ViewModel(BuffModel model)
        {
            this.model = model;
            this.currentFilter = 0;
            this.model.PropertyChanged += this.OnNotifyPropertyChanged;
        }

        public void RemoveBuff(ActivatableBuff buff)
        {
            this.model.RemoveBuff(buff);
            this.NotifyPropertyChanged("Buffs");
        }

        public void ClearAllBuffs()
        {
            this.model.ClearAllBuffs();
            this.NotifyPropertyChanged("Buffs");
        }

        private void OnNotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged(this, e);
        }

        private void NotifyPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void Dispose()
        {
            this.model.PropertyChanged -= this.OnNotifyPropertyChanged;
        }
    }
}
