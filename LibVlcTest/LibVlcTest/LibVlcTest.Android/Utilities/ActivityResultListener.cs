using Android.App;
using Android.Content;
using Java.IO;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RemoteControlRepetierServer.Droid.Utilities
{
    //Source: https://forums.xamarin.com/discussion/81278/how-to-handle-the-result-of-startactivityforresult-in-forms
    public class ActivityResultListener
    {
        public MemoryStream DataStream { get; set; }

        private TaskCompletionSource<string> Complete = new TaskCompletionSource<string>();
        public Task<string> Task { get { return this.Complete.Task; } }
        //public Task<bool> Task { get { return this.Complete.Task; } }
        //public Task Task { get { return this.Complete.Task; } }

        public ActivityResultListener(MainActivity activity)
        {
            // subscribe to activity results
            activity.ActivityResult += OnActivityResult;
        }

        private void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            // unsubscribe from activity results
            var activity = MainActivity.Instance;
            activity.ActivityResult -= OnActivityResult;

            // process result
            if (resultCode != Result.Ok)
                this.Complete.TrySetResult(string.Empty);
            else
            {
                try
                {
                    using (Stream sr = Android.App.Application.Context.ContentResolver.OpenOutputStream(data.Data))
                    {
                        using (var javaStream = new BufferedOutputStream(sr))
                        {
                            javaStream.Write(DataStream.ToArray());
                            javaStream.Close();
                            DataStream.Flush();
                            DataStream.Close();
                            DataStream = null;
                            // Return file path
                            this.Complete.TrySetResult(data.Data.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                    this.Complete.TrySetResult(string.Empty);
                }
            }
        }
    }
}