namespace BuffHelper.TypeConverters
{
    using System;
    using System.Diagnostics;
    using BuffHelper.Data;
    using Windows.UI.Xaml.Data;

    public class ModifierTypeToIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            IIndexable indexable = (IIndexable)value;
            Debug.Assert(ModifierTypes.AllModifierTypesList[indexable.index] == value);
            return indexable.index;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ModifierTypes.AllModifierTypesList[(int)value];
        }
    }
}
