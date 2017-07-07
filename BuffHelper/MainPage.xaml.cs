namespace BuffHelper
{
    using BuffHelper.Data;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Model Model = new Model(PresetBuffList.DefaultConditionList);

        public MainPage()
        {
            this.Model.CalculateAllModifiers();
            this.InitializeComponent();
        }
    }
}
