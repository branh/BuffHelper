namespace BuffHelper.TypeConverters
{
    using System;
    using BuffHelper.Data;
    using Windows.UI;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    public class BuffTypeToBrushConverter : IValueConverter
    {
        private static Brush buffBrush = new SolidColorBrush(Color.FromArgb(128, 25, 250, 50));
        private static Brush baneBrush = new SolidColorBrush(Color.FromArgb(128, 250, 25, 50));
        private static Brush neutralBrush = new SolidColorBrush(Color.FromArgb(128, 255, 255, 0));

        protected virtual Brush BuffBrush
        {
            get
            {
                return BuffTypeToBrushConverter.buffBrush;
            }
        } 

        protected virtual Brush BaneBrush
        {
            get
            {
                return BuffTypeToBrushConverter.baneBrush;
            }
        }

        protected virtual Brush NeutralBrush
        {
            get
            {
                return BuffTypeToBrushConverter.neutralBrush;
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BuffType buffType = (BuffType)Enum.Parse(typeof(BuffType), value.ToString());
            switch(buffType)
            {
                case BuffType.Buff:
                    return this.BuffBrush;
                case BuffType.Bane:
                    return this.BaneBrush;
                case BuffType.Neutral:
                    return this.NeutralBrush;
                default:
                    throw new InvalidOperationException("Unknown buff type");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BorderBrushConverter : BuffTypeToBrushConverter
    {
        private static Brush buffBrush = new SolidColorBrush(Color.FromArgb(255, 25, 250, 50));
        private static Brush baneBrush = new SolidColorBrush(Color.FromArgb(255, 250, 25, 50));
        private static Brush neutralBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));

        protected override Brush BuffBrush
        {
            get
            {
                return BorderBrushConverter.buffBrush;
            }
        }

        protected override Brush BaneBrush
        {
            get
            {
                return BorderBrushConverter.baneBrush;
            }
        }

        protected override Brush NeutralBrush
        {
            get
            {
                return BorderBrushConverter.neutralBrush;
            }
        }
    }
}
