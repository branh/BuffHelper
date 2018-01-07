namespace BuffHelper.TypeConverters
{
    using System;
    using Pathfinder.Utility.Data;
    using Windows.UI.Xaml.Data;

    public class BuffTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BuffType buffType = (BuffType)((value is int) ? (int)value : System.Convert.ToInt32((double)value));
            switch(buffType)
            {
                case BuffType.Bane:
                    return "bane";
                case BuffType.Buff:
                    return "buff";
                case BuffType.Neutral:
                    return "condition";
                default:
                    throw new InvalidOperationException("Passed invalid BuffType to converter");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
