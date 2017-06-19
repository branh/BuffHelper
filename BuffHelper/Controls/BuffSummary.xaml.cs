namespace BuffHelper.Controls
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class BuffSummary : UserControl
    {
        public static readonly DependencyProperty BuffTextProperty = DependencyProperty.Register("BuffText", typeof(string), typeof(BuffSummary), new PropertyMetadata(string.Empty));

        public string BuffText
        {
            get
            {
                return (string)GetValue(BuffSummary.BuffTextProperty);
            }
            set
            {
                SetValue(BuffSummary.BuffTextProperty, value);
            }
        }
        
        public BuffSummary()
        {
            this.InitializeComponent();
        }
    }
}
