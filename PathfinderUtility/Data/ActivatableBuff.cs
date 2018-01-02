namespace Pathfinder.Utility.Data
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

        /// <summary>
        /// Used to provide a level of indirection.
        /// </summary>
        /// <param name="newBuff">The new version of the buff</param>
        public void ReplaceBuff(Buff newBuff, BuffModel model)
        {
            this.Buff = newBuff;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsActive"));
        }
    }
}
