namespace BuffHelper.TypeConverters
{
    using System;
    using Windows.UI.Xaml.Data;

    class DoubleEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (double)(int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Enum.ToObject(targetType, System.Convert.ToInt32((double)value));
        }
    }
}
