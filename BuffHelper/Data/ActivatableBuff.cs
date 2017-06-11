namespace BuffHelper.Data
{
    using System.ComponentModel;

    public class ActivatableBuff : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isActive;
        public bool IsActive {
            get
            {
                return this.isActive;
            }
            set
            {
                if (this.isActive != value)
                {
                    this.isActive = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsActive"));
                }

            }
        }

        public Buff Buff { get; private set; }

        public ActivatableBuff(Buff activatableBuff, bool active = false)
        {
            this.IsActive = active;
            this.Buff = activatableBuff;
        }
    }
}
