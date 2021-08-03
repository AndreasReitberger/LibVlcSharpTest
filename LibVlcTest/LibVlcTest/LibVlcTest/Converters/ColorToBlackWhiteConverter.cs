using System;
using System.Globalization;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Converters
{
    public sealed class ColorToBlackWhiteConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color opposite = Color.Black;
            var type = value.GetType();
            if (value is Color color)
            {
                var mean = (color.R + color.G + color.B) / 3;
                opposite = mean < 0.5 ?
                    Color.White : Color.Black;
            }
            return opposite;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
