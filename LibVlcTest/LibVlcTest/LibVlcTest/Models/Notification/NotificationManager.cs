using Plugin.LocalNotification;
using RemoteControlRepetierServer.Models.Errors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RemoteControlRepetierServer.Models.Notification
{
    public class NotificationManager
    {
        #region Notifications
        int _notificationNumber = 0;
        #endregion


        #region Instance
        static NotificationManager _instance = null;
        static readonly object Lock = new object();
        public static NotificationManager Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance == null)
                        _instance = new NotificationManager();
                }
                return _instance;
            }

            set
            {
                if (_instance == value) return;
                lock (Lock)
                {
                    _instance = value;
                }
            }

        }
        #endregion


        #region Constructor
        public NotificationManager()
        {
            _notificationNumber = 0;
            NotificationCenter.Current.NotificationTapped -= OnLocalNotificationTapped;
            NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

            NotificationCenter.Current.NotificationActionTapped -= OnNotificationActionTapped;
            NotificationCenter.Current.NotificationActionTapped += OnNotificationActionTapped;
        }

        ~NotificationManager()
        {
            NotificationCenter.Current.NotificationTapped -= OnLocalNotificationTapped;
            NotificationCenter.Current.NotificationActionTapped -= OnNotificationActionTapped;
        }
        #endregion

        #region Notifications
        public void SendNotification(string title, string message)
        {
            var notification = new NotificationRequest
            {
                NotificationId = _notificationNumber++,
                Title = title,
                Description = message,
            };
            NotificationCenter.Current.Show(notification);
            EventManager.LogEvent(new AppEvent()
            {
                Message = $"Notification shown: {notification.Description}"
            });
        }

        void OnLocalNotificationTapped(Plugin.LocalNotification.NotificationEventArgs e)
        {
            //Debug.WriteLine($"Tapped event received: {e.Request}");
            EventManager.LogEvent(new AppEvent()
            {
                Message = $"Notification tapped event received: {e.Request}"
            });
            // your code goes here
        }

        private void OnNotificationActionTapped(NotificationActionEventArgs e)
        {
            EventManager.LogEvent(new AppEvent()
            {
                Message = $"Action tapped event received: {e.Request}"
            });
        }
        #endregion
    }
}
