namespace RemoteControlRepetierServer.Interfaces
{
    public interface IImageResizer
    {
        byte[] ResizeImage(byte[] imageData, float width, float height = -1);
    }
}
