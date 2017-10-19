namespace BuffHelper.Controls
{
    using System;
    using BuffHelper.Data;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class ModifierDescription : UserControl
    {
        private ModifierType[] modifierTypes;
        private StatType[] statTypes;

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(ModifierDescription), new PropertyMetadata(0));
        public static readonly DependencyProperty ModifierTypeProperty = DependencyProperty.Register("ModifierType", typeof(IModifierType), typeof(ModifierDescription), new PropertyMetadata(ModifierTypes.Untyped));
        public static readonly DependencyProperty StatTypeProperty = DependencyProperty.Register("StatType", typeof(StatType), typeof(ModifierDescription), new PropertyMetadata(StatTypes.Skill));

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

        public ModifierType ModifierType
        {
            get
            {
                return (ModifierType)GetValue(ModifierDescription.ModifierTypeProperty);
            }
            set
            {
                SetValue(ModifierDescription.ModifierTypeProperty, value);
            }
        }

        public StatType StatType
        {
            get
            {
                return (StatType)GetValue(ModifierDescription.StatTypeProperty);
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
