namespace BuffHelper.TypeConverters
{
    using System;
    using Windows.UI.Xaml.Data;

    public class IntToBonusPenaltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int modifier = (int)value;
            if (modifier < 0)
            {
                return "penalty to";
            }
            return "bonus to";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
