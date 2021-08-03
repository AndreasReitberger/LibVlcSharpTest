namespace RemoteControlRepetierServer.Models.Errors
{
    public class WatchAppEvent : AppEvent
    {
        #region Properties
        public WatchAppDevice Device { get; set; } = WatchAppDevice.Unkown;
        public bool SessionValid { get; set; } = false;
        #endregion
    }
}
