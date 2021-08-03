using System.Threading.Tasks;

namespace RemoteControlRepetierServer.Interfaces
{
    public interface IAppTrackingTransparency
    {
        Task<bool> RequestAppTrackingAsync();
    }
}
