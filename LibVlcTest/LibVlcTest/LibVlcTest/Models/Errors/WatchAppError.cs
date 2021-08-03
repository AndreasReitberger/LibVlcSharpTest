namespace RemoteControlRepetierServer.Models.Errors
{
    public class WatchAppError : Error
    {
        #region Properties
        public WatchAppDevice Device { get; set; } = WatchAppDevice.Unkown;
        public bool SessionValid { get; set; } = false;
        #endregion
    }
}
