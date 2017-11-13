namespace BuffHelper.Controls
{
    using Windows.Foundation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;

    public static class FlyoutHelper
    {
        public static void ShowFlyout(FrameworkElement target, Point location)
        {
            MenuFlyout flyout = (MenuFlyout)FlyoutBase.GetAttachedFlyout(target);
            flyout.ShowAt(target, location);
        }
    }
}
