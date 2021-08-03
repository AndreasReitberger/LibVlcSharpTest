namespace RemoteControlRepetierServer.Models.Messaging
{
    public enum WebCamView
    {
        Fullscreen,
        Dashboard,
        ControlPanel,
    }
    public class WebCamIdentifier
    {
        #region Properties
        public WebCamView View { get; set; } 
        #endregion
    }
}
