using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using LibVLCSharp.Forms.Platforms.Android;
using Plugin.LocalNotification;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RemoteControlRepetierServer.Droid
{
    [Activity(Label = "RemoteControlRepetierServer", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", 
        MainLauncher = false, ConfigurationChanges = ConfigChanges.UiMode | ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTop
        )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        #region FileExporter
        public static readonly int WriteFileId = 6265;
        internal static MainActivity Instance { get; private set; }

        public event Action<int, Result, Intent> ActivityResult;
        #endregion

        #region PhotoPicker
        public static readonly int PickImageId = 1000;
        public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }
        #endregion

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (ActivityResult != null)
            {
                ActivityResult(requestCode, resultCode, data);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Needed for LibVlc
            Platform.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Plugin.LocalNotification
            NotificationCenter.CreateNotificationChannel();

            LoadApplication(new App());

            NotificationCenter.NotifyNotificationTapped(Intent);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

#region Notifications
        protected override void OnNewIntent(Intent intent)
        {
            NotificationCenter.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);       
        }
#endregion

#region ForegroundServices
        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }
#endregion
    }
}