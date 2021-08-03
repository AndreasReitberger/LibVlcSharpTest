using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.Models.Settings;
using RemoteControlRepetierServer.Models.ShellHelper.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RemoteControlRepetierServer.ViewModels
{
    [Preserve(AllMembers = true)]
    public class LoadingPageViewModel : BaseViewModel
    {
        #region Properties

        Guid _lastServerId = Guid.Empty;
        public Guid LastServerId
        {
            get => _lastServerId;
            set
            {
                if (_lastServerId == value) return;
                if (!IsLoading)
                    SettingsManager.PrintServer_LastUsedServer = value;
                _lastServerId = value;
                OnPropertyChanged();
            }
        }

        string _appEntryPoint;
        public string AppEntryPoint
        {
            get => _appEntryPoint;
            set
            {
                if (_appEntryPoint == value) return;
                _appEntryPoint = value;
                OnPropertyChanged();
            }
        }

        bool _isStartup = true;
        public bool IsStartup
        {
            get => _isStartup;
            set
            {
                if (_isStartup == value) return;
                _isStartup = value;
                OnPropertyChanged();
            }
        }

        bool _isChecking = false;
        public bool IsChecking
        {
            get => _isChecking;
            set
            {
                if (_isChecking == value) return;
                _isChecking = value;
                OnPropertyChanged();
            }
        }

        bool _isReachable = false;
        public bool IsReachable
        {
            get => _isReachable;
            set
            {
                if (_isReachable == value) return;
                _isReachable = value;
                OnPropertyChanged();
            }
        }

        bool _isMissConfigured = false;
        public bool IsMissConfigured
        {
            get => _isMissConfigured;
            set
            {
                if (_isMissConfigured == value) return;
                _isMissConfigured = value;
                OnPropertyChanged();
            }
        }

        string _lastPrinterSlug;
        public string LastPrinterSlug
        {
            get => _lastPrinterSlug;
            set
            {
                if (_lastPrinterSlug == value) return;
                if (!IsLoading)
                    SettingsManager.PrintServer_LastUsedPrinterProfile = value;
                _lastPrinterSlug = value;
                OnPropertyChanged();
            }
        }

        string _selectedServerAddress;
        public string SelectedServerAddress
        {
            get => _selectedServerAddress;
            set
            {
                if (_selectedServerAddress == value) return;
                _selectedServerAddress = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor, LoadSettings

        public LoadingPageViewModel()
        {
            InitCommands();

            IsLoading = true;
            LoadSettings();
            IsLoading = false;
        }

        void InitCommands()
        {
            GoBackCommand = new Command(() => GoBackAction(), GoBackCommand_CanExcecute);
        }

        void LoadSettings()
        {
            IsDemoModeOn = SettingsManager.Demo_Mode;

            LastPrinterSlug = SettingsManager.PrintServer_LastUsedPrinterProfile;
            LastServerId = SettingsManager.PrintServer_LastUsedServer;

            AppEntryPoint = SettingsManager.Theme_AppEntryPoint;
            if(!string.IsNullOrEmpty(AppEntryPoint) && ShellNavigationManager.Instance.AvailableEntryPages.Contains(AppEntryPoint))
            {
                ShellNavigationManager.Instance.RootPage = AppEntryPoint;
            }
        }

        #endregion

        #region Commands
        
        public Command GoToDeviceSettingsCommand
        {
            get => new Command(() => GoToDeviceSettingsAction(), GoToDeviceSettingsCommand_CanExcecute);
        }
        bool GoToDeviceSettingsCommand_CanExcecute()
        {
            return true;
        }
        void GoToDeviceSettingsAction()
        {
            try
            {
                SettingsManager.OpenDeviceSettings();
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }

        public Command CloseCommand
        {
            get => new Command(async () => await CloseAction(), CloseCommand_CanExcecute);
        }
        bool CloseCommand_CanExcecute()
        {
            return true;
        }
        async Task CloseAction()
        {
            try
            {
                //await await ShellNavigationManager.Instance.GoToAsync($"..", false, 500);
                await ShellNavigationManager.Instance.GoBackAsync(false, 500);
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }

#region GoBackOverride
        public Command GoBackCommand { get; set; }
        bool GoBackCommand_CanExcecute()
        {
            return true;
        }
        //async Task GoBackAction()
        void GoBackAction()
        {
            try
            {
                return;
                //await ShellNavigationManager.Instance.GoBackAsync(false);
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }
#endregion

#endregion

        #region Methods

        public async Task OnAppearing()
        {
            try
            {
                LoadSettings();
                IsBusy = true;

                if (IsStartUp)
                {
                    // Avoids freezes on some devices
                    await Task.Delay(Device.RuntimePlatform == "Android" ? 350 : 100);
                    IsReachable = true;
                    _ = await ShellNavigationManager.Instance.GoToAsync($"///{ShellNavigationManager.Instance.RootPage}", false, 150);
                }
                else
                    _ = await ShellNavigationManager.Instance.GoToAsync($"///{ShellNavigationManager.Instance.RootPage}", false, 150);

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
                if (SettingsManager.SettingsChanged)
                {
                    // Notify other modules
                    //MessagingCenter.Send(new AppMessageInfo(), Messages.OnSettingsChanged.ToString());
                    SettingsManager.SettingsChanged = false;
                }
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
