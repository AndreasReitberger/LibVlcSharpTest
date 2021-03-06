using System;
using System.Globalization;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Converters
{
    public sealed class BooleanReverseVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool visible && visible ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
            //return value is bool visible && visible ? true : false;
        }
    }
}
