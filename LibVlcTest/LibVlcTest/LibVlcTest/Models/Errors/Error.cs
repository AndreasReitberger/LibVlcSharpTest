using System;
namespace RemoteControlRepetierServer.Models.Errors
{
    public class Error : AppEvent
    {
        #region Properties
        public Exception Exception { get; set; }
        public ErrorType Type { get; set; }
        #endregion

        #region Constructor
        public Error()
        {
            Level = ErrorLevel.Critical;
        }
        #endregion
    }
}
