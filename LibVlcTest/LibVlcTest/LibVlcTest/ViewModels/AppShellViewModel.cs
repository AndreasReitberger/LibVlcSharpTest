using LibVlcTest.Resources.Localization;
using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.Models.Messaging;
using RemoteControlRepetierServer.Models.Settings;
using RemoteControlRepetierServer.Models.ShellHelper.Navigation;
using RemoteControlRepetierServer.Utilities;
using RemoteControlRepetierServer.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RemoteControlRepetierServer.ViewModels
{

    [Preserve(AllMembers = true)]
    public class AppShellViewModel : BaseViewModel
    {

        #region Module
        bool _isOnStartup = false;
        public bool IsOnStartup
        {
            get => _isOnStartup;
            set
            {
                if (_isOnStartup == value) return;
                _isOnStartup = value;
                OnPropertyChanged();
            }
        }

        bool _autoTabletMode;
        public bool AutoTabletMode
        {
            get => _autoTabletMode;
            set
            {
                if (_autoTabletMode == value) return;
                _autoTabletMode = value;
                OnPropertyChanged();
            }
        }

        bool _enableTabletModeManually;
        public bool EnableTabletModeManually
        {
            get => _enableTabletModeManually;
            set
            {
                if (_enableTabletModeManually == value) return;
                _enableTabletModeManually = value;
                OnPropertyChanged();
            }
        }

        bool _showingConfigureMessage = false;
        public bool ShowingConfigureMessage
        {
            get => _showingConfigureMessage;
            set
            {
                if (_showingConfigureMessage == value) return;
                _showingConfigureMessage = value;
                OnPropertyChanged();
            }
        }

        bool _showingOfflineMessage = false;
        public bool ShowingOfflineMessage
        {
            get => _showingOfflineMessage;
            set
            {
                if (_showingOfflineMessage == value) return;
                _showingOfflineMessage = value;
                OnPropertyChanged();
            }
        }

        bool _showingSelectPrinterMessage = false;
        public bool ShowingSelectPrinterMessage
        {
            get => _showingSelectPrinterMessage;
            set
            {
                if (_showingSelectPrinterMessage == value) return;
                _showingSelectPrinterMessage = value;
                OnPropertyChanged();
            }
        }

        bool _showingSelectServerMessage = false;
        public bool ShowingSelectServerMessage
        {
            get => _showingSelectServerMessage;
            set
            {
                if (_showingSelectServerMessage == value) return;
                _showingSelectServerMessage = value;
                OnPropertyChanged();
            }
        }

        bool _showingAuthErrorMessage = false;
        public bool ShowingAuthErrorMessage
        {
            get => _showingAuthErrorMessage;
            set
            {
                if (_showingAuthErrorMessage == value) return;
                _showingAuthErrorMessage = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor, LoadSettings

        public AppShellViewModel()
        {
            InitCommands();
           
            IsLoading = true;
            LoadSettings();
            IsLoading = false;

            // Init LibVlc
            InitLibVlc();
            RegisterMessages();

            // Log 
            if (Device.Idiom != TargetIdiom.Phone && Device.Idiom != TargetIdiom.Tablet)
                EventManager.LogError(new Error()
                {
                    Message = string.Format(
                        Strings.ErrorDeviceTypeNotRecognizedFormated,
                        $"{Device.Idiom}, DisplyInfo: {DeviceDisplay.MainDisplayInfo}"
                        ),
                    Level = ErrorLevel.Critical,
                    Type = ErrorType.Misc,
                });

            //NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;
        }

        void InitCommands()
        {
            ShowSettingsCommand = new Command(async () => await ShowSettingsAction());
            ShowPrivacyCommand = new Command(async () => await ShowPrivacyAction());
            ShowAboutAppCommand = new Command(async () => await ShowAboutAppAction());
        }

        void InitLibVlc()
        {
            try
            {
                GlobalLibVlcManager.InitLibVlc();
            }
            catch (Exception exc)
            {
                EventManager.LogError(exc);
            }
        }

        void RegisterMessages()
        {

            #region DemoMode

            MessagingCenter.Subscribe<AppMessageInfo>(this, Messages.OnDemoModeChanged.ToString(), async(value) => {
                await OnDemoModeChanged(value);
            });
            #endregion

            // Callbacks
            MessagingCenter.Subscribe<PrintServerMessageInfo>(this, Messages.OnServerSelectionPageClosed.ToString(), (value) => {
                OnServerSelectionPageClosed(value);
            });
            MessagingCenter.Subscribe<PrintServerMessageInfo>(this, Messages.OnPrinterSelectionPageClosed.ToString(), (value) => {
                OnPrinterSelectionPageClosed(value);
            });
        }

        void LoadSettings()
        {
            IsDemoModeOn = SettingsManager.Demo_Mode;
            AutoTabletMode = SettingsManager.Theme_AutoTabletMode;
            EnableTabletModeManually = SettingsManager.Theme_EnableTabletModeManually;
        }
        #endregion

        #region Events
        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            MessagingCenter.Send(sender, Messages.OnConnectivityChanged.ToString(), e);
            Debug.WriteLine($"App: Connectivity has changed => NetworkAccess: '{e.NetworkAccess}'!");
        }
        #endregion

        #region DemoMode
        async Task OnDemoModeChanged(AppMessageInfo info)
        {
            try
            {
                IsDemoModeOn = SettingsManager.Demo_Mode;
                if (!IsDemoModeOn)
                {
                    // Clear navigation stack and go to LoadingPage
                    await ShellNavigationManager.Instance.GoToAsync($"///{nameof(LoadingPage)}");
                }
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
                Debug.WriteLine(string.Format("Messaging: Exception => {0}", exc.Message));
            }
        }
        #endregion

        #region Callbacks

        void OnServerSelectionPageClosed(PrintServerMessageInfo info)
        {
            try
            {
                if (ShowingSelectServerMessage)
                    ShowingSelectServerMessage = false;
                //await Task.Delay(1);
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
                Debug.WriteLine(string.Format("Messaging: Exception => {0}", exc.Message));
            }
        }
        void OnPrinterSelectionPageClosed(PrintServerMessageInfo info)
        {
            try
            {
                if (ShowingSelectPrinterMessage)
                    ShowingSelectPrinterMessage = false;
                //await Task.Delay(1);
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
                Debug.WriteLine(string.Format("Messaging: Exception => {0}", exc.Message));
            }
        }

        #endregion

        #region Command
        public Command ShowSettingsCommand { get; set; }
        async Task ShowSettingsAction()
        {
            try
            {
                await ShellNavigationManager.Instance.GoToAsync(ShellRoute.Setting, false);
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }

        public Command ShowPrivacyCommand { get; set; }
        async Task ShowPrivacyAction()
        {
            try
            {
                await ShellNavigationManager.Instance.GoToAsync(ShellRoute.Privacy, false);
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }

        public Command ShowAboutAppCommand { get; set; }
        async Task ShowAboutAppAction()
        {
            try
            {
                await ShellNavigationManager.Instance.GoToAsync(ShellRoute.About, false);
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }

        #endregion

        #region Methods

        // Never gets called on AppShell
        public void OnAppearing()
        {
            try
            {
                IsBusy = true;
                LoadSettings();
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            IsBusy = false;
            IsStartUp = false;
        }

        public void OnDisappearing()
        {
            try
            {
                // Do not unsubscribe, because this view model handles vital events for the whole app session.
                //UnsubscribeServerEvents();
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }
        #endregion
    }
}
