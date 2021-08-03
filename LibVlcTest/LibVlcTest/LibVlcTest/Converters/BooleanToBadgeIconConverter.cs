using Syncfusion.XForms.BadgeView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RemoteControlRepetierServer.Converters
{
    [Preserve(AllMembers = true)]
    public class BooleanToBadgeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is int online && online == 1 ? BadgeIcon.Available : BadgeIcon.Prohibit1;
        }
   
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
