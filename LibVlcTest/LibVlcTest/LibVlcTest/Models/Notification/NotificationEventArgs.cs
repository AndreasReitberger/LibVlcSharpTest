using System;

namespace RemoteControlRepetierServer.Models.Notification
{
    public class NotificationEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
