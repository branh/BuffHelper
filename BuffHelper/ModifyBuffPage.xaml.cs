namespace BuffHelper
{
    using BuffHelper.Data;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModifyBuffPage : Page
    {
        private ActivatableBuff activeBuff;
        private Buff buff;

        public ModifyBuffPage()
        {
            this.buff = Buff.CreateUninitializedBuff();
            this.InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (this.activeBuff == null)
            {
                App app = App.Current as App;
                app.Model.AddBuff(this.buff);
            }
            else
            {
                this.activeBuff.ReplaceBuff(this.buff);
            }

            this.Frame.Navigate(typeof(MainPage));
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.activeBuff = e?.Parameter as ActivatableBuff;
            if (this.activeBuff != null)
            {
                this.buff = this.activeBuff.Buff;
            }
            else
            {
                this.buff = Buff.CreateUninitializedBuff();
            }

            base.OnNavigatedTo(e);
        }

        private void AddModifier(object sender, RoutedEventArgs e)
        {
            this.buff.Modifiers.Add(Modifier.CreateUninitializedModifier());
        }
    }
}
