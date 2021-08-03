using System;

namespace RemoteControlRepetierServer.Models.Messaging
{
    public class PrintServerMessageInfo
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string SessionId { get; set; } = string.Empty;
    }
}
