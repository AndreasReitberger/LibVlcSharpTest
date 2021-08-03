using System.IO;
using System.Threading.Tasks;

namespace RemoteControlRepetierServer.Interfaces
{
    public interface ISave
    {
        Task<string> SaveFromStreamAsync(string filename, MemoryStream stream, string contentType = "application/pdf", string additionalPath = "");
        Task ViewFileAsync(string filepath, string filename, string localisedTitle = "", string mimeType = "application/pdf", string extension = "pdf");
    }
}
