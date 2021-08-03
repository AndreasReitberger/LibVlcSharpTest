namespace RemoteControlRepetierServer.Models.Errors
{
    public enum ErrorType
    {
        UnhandledException,
        RestApiCommunicationError,
        WebSocketError,
        AccessViolation,

        Misc = 99,
    }
}
