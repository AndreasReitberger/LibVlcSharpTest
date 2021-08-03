using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Converters
{
    public sealed class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not byte[] imageAsBytes)
            {
                return null;
            }
            ImageSource image = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            // Try to load the bitmap in background?
            /*
            _ = Task.Run(() =>
            {
                ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
                Device.BeginInvokeOnMainThread(() =>
                {
                    image = imageSource;
                });
            });
            */
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
