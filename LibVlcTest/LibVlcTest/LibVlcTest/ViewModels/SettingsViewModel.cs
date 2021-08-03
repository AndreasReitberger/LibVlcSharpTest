using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.Models.Messaging;
using RemoteControlRepetierServer.Models.Settings;

using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RemoteControlRepetierServer.ViewModels
{

    [Preserve(AllMembers = true)]
    public class SettingsViewModel : BaseViewModel
    {
        #region Properties
        bool _isRefreshing = false;
        public new bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing == value) return;
                _isRefreshing = value;
                RefreshDashboardCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        bool _demoModeToggled = false;
        public bool DemoModeToggled
        {
            get => _demoModeToggled;
            set
            {
                if (_demoModeToggled == value) return;
                _demoModeToggled = value;
                OnPropertyChanged();
            }
        }

        bool _demoMode = false;
        public bool DemoMode
        {
            get => _demoMode;
            set
            {
                if (_demoMode == value) return;
                if (!IsLoading)
                {
                    SettingsManager.Demo_Mode = value;
                    SettingsManager.SettingsChanged = true;
                }
                DemoModeToggled = true;
                _demoMode = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor, LoadSettings

        public SettingsViewModel()
        {
            InitCommands();

            IsLoading = true;
            LoadSettings();
            IsLoading = false;
        }
        void InitCommands()
        {
            RefreshDashboardCommand = new Command(async () => await RefreshDashboardAction(), RefreshDashboardCommand_CanExcecute);
        }

        void LoadSettings()
        {
            DemoMode = SettingsManager.Demo_Mode;
        }
#endregion


        #region Command

        public Command RefreshDashboardCommand { get; set; }
        bool RefreshDashboardCommand_CanExcecute()
        {
            return !IsRefreshing;
        }
        async Task RefreshDashboardAction()
        {
            try
            {
                IsRefreshing = true;
                await Task.Delay(10);
                // Nothing to do here yet
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            IsRefreshing = false;
        }

        #endregion

        #region Methods
        public void OnDisappearing()
        {
            try
            {
                if (SettingsManager.SettingsChanged)
                {
                    // Notify other modules
                    MessagingCenter.Send(new AppMessageInfo(), Messages.OnSettingsChanged.ToString());
                    SettingsManager.SettingsChanged = false;
                }
                if(DemoModeToggled)
                {
                    // Notify AppShell to check connection again
                    MessagingCenter.Send(new AppMessageInfo(), Messages.OnDemoModeChanged.ToString());
                    DemoModeToggled = false;
                }
            }
            catch (Exception exc) {
                // Log error
                EventManager.LogError(exc);
            }
        }
        #endregion

    }

}
