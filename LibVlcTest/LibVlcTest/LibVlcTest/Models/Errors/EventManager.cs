#if DBEUG 
#else
#endif
using LibVlcTest.Resources.Localization;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Models.Errors
{
    public static class EventManager
    {
        #region Properties

        public static bool AllowCrashAnalyticsData { get; set; } = false;
        public static bool AllowAnalyticsData { get; set; } = false;
        public static bool HasCriticalError { get; set; } = false;

        static ObservableCollection<AppEvent> _events = new();
        public static ObservableCollection<AppEvent> Events
        {
            get => _events;
            set
            {
                if (_events == value)
                    return;
                if (_events != null)
                    HasCriticalError = _events.Where(error => error.Level == ErrorLevel.Critical).ToList().Count > 0;
                _events = value;
            }
        }
        #endregion

        #region Methods
        public static void LogError(Exception exc)
        {
            try
            {
                if (exc == null) return;
                // Log error
                //Device.InvokeOnMainThreadAsync(() =>
                //{
                    Events.Add(new Error()
                    {
                        Message = exc.Message,
                        Exception = exc,
                        Level = ErrorLevel.Critical,
                        Type = ErrorType.UnhandledException,
                    });
#if DEBUG
                    Console.WriteLine($"Error logged: {exc.Message}");
#else
                    if (AllowCrashAnalyticsData)
                        Crashes.TrackError(exc);
#endif
                //});
            }
            catch (Exception)
            { }
        }

        public static void LogError(Error error)
        {
            // Log error
            //Device.InvokeOnMainThreadAsync(() =>
            //{
                Events.Add(error);
#if DEBUG
                Console.WriteLine($"Error logged: {error.Message}");
#else
                if (AllowCrashAnalyticsData)
                    Crashes.TrackError(error?.Exception);
#endif
            //});
        }

        public static async Task LogErrorAsync(Exception exc, bool showErrorMessage = false)
        {
            if (exc == null) return;
            // Log error
            //await Device.InvokeOnMainThreadAsync(() =>
            //{
                Events.Add(new Error()
                {
                    Message = exc.Message,
                    Exception = exc,
                    Level = ErrorLevel.Critical,
                    Type = ErrorType.UnhandledException,
                });// 

#if DEBUG
                Console.WriteLine($"Error logged: {exc.Message}");
#else
                if (AllowCrashAnalyticsData)
                    Crashes.TrackError(exc);
#endif
            //});
            if (showErrorMessage)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Strings.DialogUnexpectedErrorOccurredHeadline,
                    string.Format(Strings.DialogUnexpectedErrorOccurredFormatedContent, exc.Message),
                    Strings.Close
                    );
            }
        }

        public static void LogInfo(Info info)
        {
            try
            {
                //Device.InvokeOnMainThreadAsync(() =>
                //{
                    Events.Add(info);
#if DEBUG
                Console.WriteLine($"Info logged: {info.Message}");
#else
                    if (AllowAnalyticsData)
                        Analytics.TrackEvent($"Info:{info.Message}");
#endif
                //});
            }
            catch (Exception)
            { }
        }
        public static void LogWarning(Warning warning)
        {
            try
            {
                //Device.InvokeOnMainThreadAsync(() =>
                //{
                    Events.Add(warning);
#if DEBUG
                Console.WriteLine($"Warning logged: {warning.Message}");
#else
                    if (AllowAnalyticsData)
                        Analytics.TrackEvent($"Warning:{warning.Message}");
#endif
                //});
            }
            catch (Exception)
            { }
        }

        public static void LogEvent(AppEvent appEvent)
        {
            try
            {
                //Device.InvokeOnMainThreadAsync(() => { 
                    Events.Add(appEvent);
#if DEBUG
                Console.WriteLine($"AppEvent logged: {appEvent.Message}");
#else
                    if (AllowAnalyticsData)
                        Analytics.TrackEvent($"Event:{appEvent.Message}");
#endif
                //});
            }
            catch (Exception)
            { }
        }
#endregion
    }
}
