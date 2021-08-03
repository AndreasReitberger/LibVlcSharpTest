using AndreasReitberger.Utilities;
using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.Views;
using RemoteControlRepetierServer.Views.Pages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Models.ShellHelper.Navigation
{
    public class ShellNavigationManager : BaseModel
    {
        #region Instance
        static ShellNavigationManager _instance = null;
        static readonly object Lock = new();
        public static ShellNavigationManager Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance == null)
                        _instance = new ShellNavigationManager();
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

        #region Properties

        public string Current
        {
            get => GetCurrentRoute();
        }

        string _previousRoute = string.Empty;
        public string PreviousRoute
        {
            get => _previousRoute;
            private set
            {
                if (_previousRoute == value) return;
                _previousRoute = value;
                OnPropertyChanged();
            }
        }

        string _rootPage = string.Empty;
        public string RootPage
        {
            get => _rootPage;
            set
            {
                if (_rootPage == value) return;
                _rootPage = value;
                OnPropertyChanged();
            }
        }

        List<string> _availableEntryPages = new()
        {
            nameof(DashboardPage),
        };
        public List<string> AvailableEntryPages
        {
            get => _availableEntryPages;
            private set
            {
                if (_availableEntryPages == value) return;
                _availableEntryPages = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public ShellNavigationManager()
        {
            //RootPage = Device.Idiom == TargetIdiom.Tablet ? $"///{nameof(DashboardTabletPage)}" : $"///{nameof(DashboardPage)}";
            RootPage = nameof(DashboardPage);
        }
        #endregion

        #region Methods

        public async Task<bool> GoToAsync(string Target, bool FlyoutIsPresented = false, int Delay = -1)
        {
            try
            {
                Shell.Current.FlyoutIsPresented = FlyoutIsPresented;
                if (Delay != -1)
                    await Task.Delay(Delay);
                // Workaround for #13510 - https://github.com/xamarin/Xamarin.Forms/issues/13510
                else if(Device.RuntimePlatform == "iOS")
                    await Task.Delay(50);

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        PreviousRoute = GetCurrentRoute();
                        await Shell.Current.GoToAsync(Target);
                        /*
                        if (PreviousRoute != Target)
                            await Shell.Current.GoToAsync(Target);
                        else
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("ShellNavigationManager: Tried to open the same route again", Target));
                        }
                        */
                    }
                    catch (Exception exc)
                    {
                        EventManager.LogError(exc);
                    }
                });
                return true;
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
                return false;
            }
        }
        public async Task<bool> GoToAsync(ShellRoute Target, bool FlyoutIsPresented = false, int Delay = -1)
        {
            return await GoToAsync(Target.ToString(), FlyoutIsPresented, Delay);
        }
        public async Task GoBackAsync(bool FlyoutIsPresented = false, int Delay = -1)
        {
            await GoToAsync("..", FlyoutIsPresented, Delay);
        }

        public bool IsCurrentPathRoot()
        {
            try
            {
                string[] parts = Shell.Current.CurrentState.Location.OriginalString.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                return parts.Length <= 1;
            }
            catch (Exception exc)
            {
                EventManager.LogError(exc);
                return false;
            }
        }

        string GetCurrentRoute()
        {
            try
            {
                ShellNavigationState state = Shell.Current.CurrentState;
                if (state == null) return string.Empty;

                string lastPart = state.Location.ToString().Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).LastOrDefault();
                return lastPart;
            }
            catch (Exception exc)
            {
                EventManager.LogError(exc);
                return string.Empty;
            }
        }

        #endregion

        #region RegisterRoutes

        public static void RegisterRoutes()
        {
            Routing.RegisterRoute("Setting", typeof(SettingsPage));
            Routing.RegisterRoute("Privacy", typeof(PrivacyPage));
            Routing.RegisterRoute("About", typeof(AboutPage));
            Routing.RegisterRoute("VersionDetailPage", typeof(VersionDetailPage));
            Routing.RegisterRoute("ProjectOverviewPage", typeof(ProjectOverviewPage));
            Routing.RegisterRoute("LoadingPage", typeof(LoadingPage));

        }
        
        #endregion
    }

    public enum ShellRoute
    {
        // Main Pages
        Files,
        Dashboard,
        WebCam,
        SingleControlPanelPage,
        LoadingPage,

        // App
        Setting,
        Privacy,
        About,
        CurrentPrint,
        VersionDetailPage,
        ProjectOverviewPage,
        //ErrorsPage,

        // LiteVersion
#if LIGHT
        AboutProVersionPage,
        SettingsAdsSetupPage,
#endif
        // Modals
        AdjustPrivacyModalPage,
        PrintServerStateModalPage,
        SetupProxyModalPage,
        PrintServerMessagesModalPage,
        PrintServerSelectPrinterModalPage,
        PrintServerSelectServerModalPage,
        PrintServerViewModelModalPage,
        PrintServerViewProjectModalPage,
        PrintServerViewCurrentPrintModalPage,
        PrintServerReconnectModalPage,
        PrintServerLoginModalPage,
        FilterMessagesModalPage,
        FilterPrintersModalPage,
        FilterServersModalPage,
        FilterModelsModalPage,
        SettingsQuickModalPage,
        SettingsWebCamModalPage,
        SettingsWebCamNewModalPage,
        SelectColorModalPage,

        // PrintServer
        PrintServerWelcomePage,
        //PrintServerOfflinePage,
        //PrintServerSelectPrinterPage,
        //PrintServerSelectServerPage,
        //PrintServerViewModelDataPage,
        //PrintServerMessagesPage,
        //PrintServerViewProjectPage,
        PrintServerViewWebCamPage,
    }
}
