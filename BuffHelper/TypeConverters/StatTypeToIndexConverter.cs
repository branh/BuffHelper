namespace BuffHelper.TypeConverters
{
    using System;
    using System.Diagnostics;
    using Pathfinder.Utility.Data;
    using Windows.UI.Xaml.Data;

    public class StatTypeToIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            IIndexable indexable = (IIndexable)value;
            Debug.Assert(StatTypes.AllStatsList[indexable.index] == value);
            return indexable.index;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return StatTypes.AllStatsList[(int)value];
        }
    }
}
