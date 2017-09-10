namespace BuffHelper.TypeConverters
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class StringToCheckedIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string valString = value.ToString();
            int result;
            if (!int.TryParse(valString, out result))
            {
                return int.MinValue;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }
    }

    public class CheckedIntToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (int.MinValue.Equals(value))
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
