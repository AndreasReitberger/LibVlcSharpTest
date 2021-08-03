﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Converters
{
    public sealed class DoubleHoursToTimeSpanConverter : IValueConverter
    {
        /* Translate the name of the accent */
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                TimeSpan ts = TimeSpan.FromHours(System.Convert.ToDouble(value));
                return ts;
            }
            catch (Exception)
            {
                return TimeSpan.Zero;
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan ts = (TimeSpan)value;
            if (ts == null)
                return 0;
            return ts.TotalHours;
            //throw new NotImplementedException();
        }
    }
}
