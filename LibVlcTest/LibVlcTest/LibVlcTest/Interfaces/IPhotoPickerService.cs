using System.IO;
using System.Threading.Tasks;

namespace RemoteControlRepetierServer.Interfaces
{
    public interface IPhotoPickerService
    {
        // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/photo-picker
        Task<Stream> GetImageStreamAsync();
    }
}
