namespace BuffHelper
{
    using BuffHelper.Controls;
    using BuffHelper.Data;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

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

        private void RemoveBuff(object sender, RoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)sender;
            ActivatableBuff sourceBuff = (ActivatableBuff)source.DataContext;
            this.ViewModel.RemoveBuff(sourceBuff);
        }

        private void EditBuff(object sender, RoutedEventArgs e)
        {
            FrameworkElement target = (FrameworkElement)sender;
            this.Frame.Navigate(typeof(ModifyBuffPage), target.DataContext);
        }

        private void ShowFlyoutHolding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement target = (FrameworkElement)sender;
            FlyoutHelper.ShowFlyout(target, e.GetPosition(target));
        }

        private void ShowFlyoutTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FrameworkElement target = (FrameworkElement)sender;
            FlyoutHelper.ShowFlyout(target, e.GetPosition(target));
        }
    }
}
