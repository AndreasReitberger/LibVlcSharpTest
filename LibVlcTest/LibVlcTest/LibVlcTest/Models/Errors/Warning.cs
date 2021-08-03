namespace RemoteControlRepetierServer.Models.Errors
{
    public class Warning : AppEvent
    {
        #region Properties

        #endregion

        #region Constructor
        public Warning()
        {
            Level = ErrorLevel.Warning;
        }
        #endregion
    }
}
