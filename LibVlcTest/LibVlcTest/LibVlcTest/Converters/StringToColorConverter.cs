using RemoteControlRepetierServer.Models.Errors;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RemoteControlRepetierServer.Converters
{
    [Preserve(AllMembers = true)]
    public class StringToColorConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the string to badge icon.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Return the badge icon.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = Color.Accent;
            if (value is not string str || string.IsNullOrEmpty(str))
            {
                return color;
            }

            try
            {
                color = Color.FromHex(str[0] != '#' ? $"#{str}" : str);
            }
            catch (Exception exc)
            {
                EventManager.LogError(exc);
                return color;
            }
            return color;
        }

        /// <summary>
        /// This method is used to convert the color to badge icon.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns null.</returns>        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
