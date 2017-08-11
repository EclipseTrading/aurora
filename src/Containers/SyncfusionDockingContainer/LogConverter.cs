using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Aurora.SyncfusionDockingContainer
{
    public class LogConverter : MarkupExtension, IValueConverter
    {
        public LogConverter(string logTemplate)
        {
            LogTemplate = logTemplate;
        }

        public string LogTemplate { get; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var log = LogTemplate.Replace("$value", value?.ToString())
                .Replace("$parameter", parameter?.ToString() ?? "<NULL>")
                .Replace("$type", value?.GetType().FullName ?? "TNULL");
            Console.WriteLine(log);
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}