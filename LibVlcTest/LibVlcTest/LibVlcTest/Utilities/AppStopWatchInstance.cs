using LibVlcTest.Resources.Localization;
using RemoteControlRepetierServer.Models.Errors;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RemoteControlRepetierServer.Utilities
{
    public static class AppStopWatchInstance
    {
        public static async Task StopWatchActionAsync(Func<Task> action, string LogTitle, string SourceName)
        {
            Stopwatch sw = Stopwatch.StartNew();
            await action();
            sw.Stop();
            EventManager.LogInfo(new Info()
            {
                Level = ErrorLevel.Performance,
                SourceName = SourceName,
                Message = string.Format(Strings.EventDurationForTaskInMilliSeconds, LogTitle, sw.ElapsedMilliseconds),
            });
        }
        public static void StopWatchAction(Func<Task> action, string LogTitle, string SourceName)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            EventManager.LogInfo(new Info()
            {
                Level = ErrorLevel.Performance,
                SourceName = SourceName,
                Message = string.Format(Strings.EventDurationForTaskInMilliSeconds, LogTitle, sw.ElapsedMilliseconds),
            });
        }
    }
}
