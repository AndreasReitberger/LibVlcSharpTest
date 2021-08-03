using RemoteControlRepetierServer.Models.Documentation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RemoteControlRepetierServer.Converters
{
    [Preserve(AllMembers = true)]
    public class StringToChangelogIconConverter : IValueConverter
    {

        public const string Bug = "\U000f00e4";
        public const string CogRefreshOutline = "\U000f145f";
        public const string Autorenew = "\U000f006a";
        public const string PlaylistPlus = "\U000f0412";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ChangelogType type = ChangelogType.New;
            Enum.TryParse(value.ToString(), out type);

            string glyp = PlaylistPlus;

            switch (type)
            {
                case ChangelogType.New:
                    glyp = PlaylistPlus;
                    break;
                case ChangelogType.BugFix:
                    glyp = Bug;
                    break;
                case ChangelogType.Changed:
                    glyp = Autorenew;
                    break;
                case ChangelogType.Updated:
                    glyp = CogRefreshOutline;
                    break;

                default:
                    glyp = PlaylistPlus;
                    break;
            }

            return glyp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
