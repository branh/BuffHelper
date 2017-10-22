namespace BuffHelper.TypeConverters
{
    using System;
    using Windows.UI.Xaml.Data;

    public class IntEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Enum.ToObject(targetType, (int)value);
        }
    }
}
