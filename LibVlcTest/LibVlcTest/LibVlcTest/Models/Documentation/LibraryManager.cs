using System.Collections.Generic;

namespace RemoteControlRepetierServer.Models.Documentation
{
    public static class LibraryManager
    {
        public static List<LibraryInfo> List => new List<LibraryInfo>
        {
            new LibraryInfo("LibVLCSharp", "https://github.com/videolan/libvlcsharp", ".NET library for playing and streaming videos", "GNU Lesser General Public License v2.1" , "https://github.com/videolan/libvlcsharp/blob/3.x/LICENSE"),
            new LibraryInfo("LibVLCSharp.Forms", "https://code.videolan.org/videolan/LibVLCSharp", ".NET library for video controls and media players (Xamarin Forms).", "LGPL-2.1-or-later" , "https://licenses.nuget.org/LGPL-2.1-or-later"),
            new LibraryInfo("Newtonsoft.Json", "https://www.newtonsoft.com/json", "Json.NET is a popular high-performance JSON framework for .NET", "MIT" , "https://licenses.nuget.org/MIT"),
            new LibraryInfo("RestSharp", "http://restsharp.org/", "Simple REST and HTTP API Client", "Apache-2.0" , "https://licenses.nuget.org/Apache-2.0"),
            new LibraryInfo("Syncfusion Essential Studio", "https://www.syncfusion.com/?utm_source=nuget&utm_medium=listing", "Includes more than 1,000 components and frameworks for WinForms, WPF, ASP.NET (Web Forms, MVC, Core), UWP, Xamarin, Flutter, JavaScript, Angular, Blazor, Vue and React.", "ESSENTIAL STUDIO SOFTWARE LICENSE AGREEMENT" , "https://www.syncfusion.com/license/studio/17.4.0.39/syncfusion_essential_studio_eula.pdf"),
            new LibraryInfo("Xamarin.Forms", "https://github.com/xamarin/Xamarin.Forms", "Xamarin.Forms provides a way to quickly build native apps for iOS, Android, Windows and macOS, completely in C#.", "MIT" , "https://github.com/xamarin/Xamarin.Forms/blob/5.0.0/LICENSE"),
            new LibraryInfo("XamarinCommunityToolkit", "https://github.com/xamarin/XamarinCommunityToolkit", "The Xamarin Community Toolkit is a collection of common elements for mobile development with Xamarin.Forms that people tend to replicate across multiple apps.", "MIT" , "https://github.com/xamarin/XamarinCommunityToolkit/blob/main/LICENSE"),
            new LibraryInfo("Xam.Plugin.Messaging", "https://github.com/cjlotz/Xamarin.Plugins/tree/master/Messaging", "Messaging plugin for Xamarin and Windows to make a phone call, send a sms or send an e-mail using the default messaging applications on the different mobile platforms.", "MIT" , "https://github.com/cjlotz/Xamarin.Plugins/blob/master/Messaging/LICENSE.md"),
            new LibraryInfo("Plugin.LocalNotification", "https://github.com/thudugala/Plugin.LocalNotification", "The local notification plugin provides a way to show local notifications from Xamarin.Forms apps.", "MIT" , "https://github.com/thudugala/Plugin.LocalNotification/blob/master/LICENSE"),
            new LibraryInfo("WebSocket4Net", "https://github.com/kerryjiang/WebSocket4Net", "A popular .NET WebSocket Client", "APACHE LICENSE, VERSION 2.0" , "https://www.apache.org/licenses/LICENSE-2.0.html"),

#if LIGHT        
            new LibraryInfo("MTAdMob", "https://github.com/marcojak/MTAdmob", "With this Plugin you can add a Google Admob Ads inside your Xamarin Android and iOS Projects with a single line!!! This plugin supports: Banners, Interstitial and Rewarded Videos", "MIT" , "https://github.com/marcojak/MTAdmob/blob/master/LICENSE.txt"),
            new LibraryInfo("Xamarin.Firebase.Ads", "https://github.com/xamarin/GooglePlayServicesComponents", "Xamarin.Android Bindings for Google Play Services - Xamarin.Firebase.Ads 118.3.0", "MIT" , "https://github.com/xamarin/GooglePlayServicesComponents/blob/master/LICENSE.md"),
            new LibraryInfo("Xamarin.Firebase.iOS.AdMob", "https://github.com/xamarin/GoogleApisForiOSComponents/tree/master/source/Firebase/AdMob", "C# bindings for Firebase APIs AdMob iOS Library", "MIT" , "https://www.nuget.org/packages/Xamarin.Firebase.iOS.AdMob/7.57.0/license"),
            new LibraryInfo("Xamarin.Google.iOS.MobileAds", "https://github.com/xamarin/GoogleApisForiOSComponents/tree/master/source/Google/MobileAds", "C# bindings for Google APIs Mobile Ads iOS Library", "MIT" , "https://www.nuget.org/packages/Xamarin.Google.iOS.MobileAds/7.57.0/license"),
            new LibraryInfo("GoogleUserMessagingPlatform", "https://github.com/GalaxiaGuy/GoogleUserMessagingPlatform", "A cross-platform wrapper for Google's User Messaging Platform for Android and iOS.", "MIT" , "https://github.com/GalaxiaGuy/GoogleUserMessagingPlatform/blob/master/LICENSE"),
#endif

            new LibraryInfo("FontAwesome5", "https://github.com/FortAwesome/Font-Awesome", "The internet's most popular icon toolkit", "Font Awesome Free License" , "https://github.com/FortAwesome/Font-Awesome/blob/master/LICENSE.txt"),
        };
    }
}
