namespace BuffHelper.Controls
{
    using Pathfinder.Utility.Data;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class ModifierDescription : UserControl
    {
        private ModifierType[] modifierTypes;
        private StatType[] statTypes;

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(ModifierDescription), new PropertyMetadata(0));
        public static readonly DependencyProperty ModifierTypeProperty = DependencyProperty.Register("ModifierType", typeof(int), typeof(ModifierDescription), new PropertyMetadata(0));
        public static readonly DependencyProperty StatTypeProperty = DependencyProperty.Register("StatType", typeof(int), typeof(ModifierDescription), new PropertyMetadata(0));

        public int Value
        {
            get
            {
                return (int)GetValue(ModifierDescription.ValueProperty);
            }
            set
            {
                SetValue(ModifierDescription.ValueProperty, value);
            }
        }

        public int ModifierType
        {
            get
            {
                return (int)GetValue(ModifierDescription.ModifierTypeProperty);
            }
            set
            {
                SetValue(ModifierDescription.ModifierTypeProperty, value);
            }
        }

        public int StatType
        {
            get
            {
                return (int)GetValue(ModifierDescription.StatTypeProperty);
            }
            set
            {
                SetValue(ModifierDescription.StatTypeProperty, value);
            }
        }
 
        public ModifierDescription()
        {
            this.modifierTypes = ModifierTypes.AllModifierTypesList;
            this.statTypes = StatTypes.AllStatsList;

            this.InitializeComponent();
        }
    }
}
