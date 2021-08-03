namespace RemoteControlRepetierServer.Models.Errors
{
    public class Info : AppEvent
    {
        #region Properties

        #endregion

        #region Constructor
        public Info()
        {
            Level = ErrorLevel.Info;
        }
        #endregion
    }
}
