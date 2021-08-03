using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Converters
{
    public sealed class LongToGigaByteConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long bytes = System.Convert.ToInt64(value);
            double factor = 1073741824;
            double gigaBytes = (double)Math.Round((double)(bytes / factor), 2);

            return gigaBytes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
            //return value is bool visible && !visible;
        }
    }
}
