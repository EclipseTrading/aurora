using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Aurora.SyncfusionDockingContainer
{
    public class Passthrough : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}