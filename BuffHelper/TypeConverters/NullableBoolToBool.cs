namespace BuffHelper.TypeConverters
{
    using System;
    using Windows.UI.Xaml.Data;

    public class NullableBoolToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value != null && (bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (bool?)value;
        }
    }
}
