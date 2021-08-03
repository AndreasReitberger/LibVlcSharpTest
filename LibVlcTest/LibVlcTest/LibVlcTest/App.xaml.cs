using LibVlcTest.Resources.Localization;
using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.Models.Localization;
using RemoteControlRepetierServer.Models.Messaging;
using RemoteControlRepetierServer.Models.Settings;
using RemoteControlRepetierServer.Models.ShellHelper.Navigation;
using RemoteControlRepetierServer.Themes;
using System;
using System.Threading;
using Xamarin.Forms;

namespace RemoteControlRepetierServer
{
    public enum Theme { Light, Dark }

    public enum AppState { Starting, Foreground, Background }

    public partial class App : Application
    {
        #region Variables
        public static AppState State = AppState.Foreground;
        #endregion

        #region Properties
        bool _isFirstStart = true;
        public bool IsFirstStart
        {
            get => _isFirstStart;
            set {
                if (_isFirstStart == value) return;
                _isFirstStart = value;
            }
        }

        string _themeColorHexCode = "";
        public string ThemeColorHexCode
        {
            get => _themeColorHexCode;
            set {
                if (_themeColorHexCode == value) return;
                _themeColorHexCode = value;
            }
        }
        #endregion

        public App()
        {
            State = AppState.Starting;
            //Register Syncfusion license
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncfusionLicenseManager.LicenseKey);
            //Device.SetFlags(new string[] { "AppTheme_Experimental" });
            Xamarin.Forms.Device.SetFlags(new string[] { "MediaElement_Experimental", "AppTheme_Experimental" });

            InitializeComponent();

            ShellNavigationManager.RegisterRoutes();

            // Set language
            System.Globalization.CultureInfo culture = LocalizationManager.GetInstance(SettingsManager.Localization_CultureCode).Culture;

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Strings.Culture = culture;

            ThemeColorHexCode = SettingsManager.Theme_PrimaryThemeColor;

            SetTheme(Current.RequestedTheme);
            Current.RequestedThemeChanged += (s, a) => { SetTheme(a.RequestedTheme); };

            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {        
            base.OnStart();
            //MessagingCenter.Send(new LifecycleMessage(), nameof(OnStart));
            State = AppState.Foreground;
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            State = AppState.Background;

        }

        protected override void OnResume()
        {
            base.OnResume();
            State = AppState.Foreground;

            //MessagingCenter.Send(new LifecycleMessage(), nameof(OnResume));
            MessagingCenter.Send(this, Messages.OnAppResume.ToString());
        }

        #region Theme
        void SetTheme(OSAppTheme appTheme)
        {
            try
            {
                //var test = this.Resources;
                switch (appTheme)
                {
                    case OSAppTheme.Dark:
                        Current.Resources = new DarkTheme();
                        break;
                    case OSAppTheme.Light:
                        Current.Resources = new LightTheme();
                        break;
                    case OSAppTheme.Unspecified:
                    default:
                        Current.Resources = new LightTheme();
                        break;
                }
                if(!string.IsNullOrEmpty(ThemeColorHexCode))
                {
                    //Color primary = Color.FromHex($"#{ThemeColorHexCode}");
                    ChangePrimaryColor(ThemeColorHexCode);
                }
            }
            catch (Exception exc)
            {
                EventManager.LogError(exc);
            }
        }

        public static string AppTheme
        {
            get; set;
        }
        public static Theme CurrentAppTheme { get; set; }

        public static void ChangePrimaryColor(Color newColor)
        {
            try
            {
                App.Current.Resources["PrimaryColor"] = newColor;
            }
            catch (Exception exc)
            {
                EventManager.LogError(exc);
            }
        }

        public static void ChangePrimaryColor(string newHexColor)
        {
            try
            {
                Color primary = Color.FromHex(newHexColor.StartsWith("#") ? newHexColor : $"#{newHexColor}");
                Current.Resources["PrimaryColor"] = primary;
                Current.Resources["GradientStart"] = primary;
                Current.Resources["PrimaryGradient"] = primary;

                Color primaryDark = primary.WithLuminosity(primary.Luminosity - (primary.Luminosity * .2));
                Current.Resources["PrimaryDarkColor"] = primaryDark;
                //Current.Resources["GradientEnd"] = primaryDark;

                Color gradientEnd = primary.WithLuminosity(primary.Luminosity - (primary.Luminosity * .5));
                Current.Resources["GradientEnd"] = gradientEnd;
            }
            catch (Exception exc)
            {
                EventManager.LogError(exc);
            }
        }
        #endregion
    }
}
