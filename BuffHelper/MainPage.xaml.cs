namespace BuffHelper
{
    using BuffHelper.Data;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ViewModel ViewModel;

        public MainPage()
        {
            App app = App.Current as App;
            this.ViewModel = new ViewModel(app.Model);
            this.InitializeComponent();
        }

        private void ClearAllBuffs(object sender, RoutedEventArgs e)
        {
            this.ViewModel.ClearAllBuffs();
        }

        private void AddBuff(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ModifyBuffPage));
        }
    }
}
