using LibVlcTest.Resources.Localization;
using RemoteControlRepetierServer.Models.Documentation;
using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.Models.Messaging;
using RemoteControlRepetierServer.Models.Settings;
using RemoteControlRepetierServer.Models.ShellHelper.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RemoteControlRepetierServer.ViewModels.Pages
{

    [Preserve(AllMembers = true)]
    public class ProjectOverviewPageViewModel : BaseViewModel
    {
        #region Module
        bool _askOnLeaving = true;
        public bool AskOnLeaving
        {
            get => _askOnLeaving;
            set
            {
                if (_askOnLeaving == value) return;
                _askOnLeaving = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Properties
        string _version = string.Empty;
        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }

        string _build = string.Empty;
        public string Build
        {
            get { return _build; }
            set { SetProperty(ref _build, value); }
        }

        List<string> _versions = new List<string>();
        public List<string> Versions
        {
            get => _versions;
            set
            {
                if (_versions == value) return;
                _versions = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor, LoadSettings

        public ProjectOverviewPageViewModel()
        {

            Version = DependencyService.Get<IAppVersionAndBuild>().GetVersionNumber();
            Build = DependencyService.Get<IAppVersionAndBuild>().GetBuildNumber();

            IsLoading = true;
            LoadSettings();
            IsLoading = false;

            RegisterMessages();
        }

        void RegisterMessages()
        {
            MessagingCenter.Subscribe<AppMessageInfo>(this, Messages.OnRefreshSettings.ToString(), (value) => {
                OnRefreshSettings(value);
            });
        }
        void LoadSettings()
        {
            IsDemoModeOn = SettingsManager.Demo_Mode;
            ShowTitleInBar = SettingsManager.General_ShowTitlesInBar;

        }
        #endregion

        #region Messages
        void OnRefreshSettings(AppMessageInfo info)
        {
            try
            {
                //Reload settings
                LoadSettings();
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
                Debug.WriteLine(string.Format("Messaging: Exception => {0}", exc.Message));
            }
        }
        #endregion

        #region Commands

        public Command GoBackCommand
        {
            get => new Command(async () => await GoBackAction(), GoBackCommand_CanExcecute);

        }
        bool GoBackCommand_CanExcecute()
        {
            return true;
        }
        async Task GoBackAction()
        {
            try
            {
                if (AskOnLeaving)
                {
                    var result = await Application.Current.MainPage.DisplayAlert(
                        Strings.DialogConfirmGoBackHeadline,
                        Strings.DialogConfirmGoBackContent,
                        Strings.GoBack,
                        Strings.Close
                        );

                    if (result)
                        await ShellNavigationManager.Instance.GoBackAsync(false);
                }
                else
                    await ShellNavigationManager.Instance.GoBackAsync(false);
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
                await Application.Current.MainPage.DisplayAlert(
                    Strings.DialogUnexpectedErrorOccurredHeadline,
                    string.Format(Strings.DialogUnexpectedErrorOccurredFormatedContent, exc.Message),
                    Strings.Close
                    );
            }
        }

        #region Actions
        public Command OpenProjectWebsiteCommand
        {

            get => new Command(async () => await OpenProjectWebsiteAction());

        }
        async Task OpenProjectWebsiteAction()
        {
            try
            {
                var str = DocumentationManager.ProjectUrl;
                Uri link = new Uri(str);
                if (link != null)
                {
                    var res = await Shell.Current.DisplayAlert(
                    Strings.DialogOpenExternalUriHeadline,
                    string.Format(Strings.DialogOpenExternalUriFormatedContent, link.ToString()),
                    Strings.OK,
                    Strings.Cancel
                    );
                    if (res)
                    {
                        await Browser.OpenAsync(link, BrowserLaunchMode.SystemPreferred);
                    }
                }
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
                await Application.Current.MainPage.DisplayAlert(
                    Strings.DialogUnexpectedErrorOccurredHeadline,
                    string.Format(Strings.DialogUnexpectedErrorOccurredFormatedContent, exc.Message),
                    Strings.Close
                    );
            }
        }
        public Command OpenSubmitBugCommand
        {

            get => new Command(async () => await OpenSubmitBugAction());

        }
        async Task OpenSubmitBugAction()
        {
            try
            {
                var str = DocumentationManager.ProjectSubmitBugUrl;
                Uri link = new Uri(str);
                if (link != null)
                {
                    var res = await Shell.Current.DisplayAlert(
                    Strings.DialogOpenExternalUriHeadline,
                    string.Format(Strings.DialogOpenExternalUriFormatedContent, link.ToString()),
                    Strings.OK,
                    Strings.Cancel
                    );
                    if (res)
                    {
                        await Browser.OpenAsync(link, BrowserLaunchMode.SystemPreferred);
                    }
                }
            }
            catch (Exception exc)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Strings.DialogUnexpectedErrorOccurredHeadline,
                    string.Format(Strings.DialogUnexpectedErrorOccurredFormatedContent, exc.Message),
                    Strings.Close
                    );
            }
        }

        public Command OpenSubmitFeatureCommand
        {

            get => new Command(async () => await OpenSubmitFeatureAction());

        }
        async Task OpenSubmitFeatureAction()
        {
            try
            {
                var str = DocumentationManager.ProjectSubmitFeatureUrl;
                Uri link = new Uri(str);
                if (link != null)
                {
                    var res = await Shell.Current.DisplayAlert(
                    Strings.DialogOpenExternalUriHeadline,
                    string.Format(Strings.DialogOpenExternalUriFormatedContent, link.ToString()),
                    Strings.OK,
                    Strings.Cancel
                    );
                    if (res)
                    {
                        await Browser.OpenAsync(link, BrowserLaunchMode.SystemPreferred);
                    }
                }
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
                await Application.Current.MainPage.DisplayAlert(
                    Strings.DialogUnexpectedErrorOccurredHeadline,
                    string.Format(Strings.DialogUnexpectedErrorOccurredFormatedContent, exc.Message),
                    Strings.Close
                    );
            }
        }
        #endregion

        #endregion

        #region Methods
        public void OnAppearing()
        {
            try
            {
                IsBusy = true;
                if (!IsStartUp)
                    LoadSettings(); 
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            IsStartUp = false;
            IsBusy = false;
        }

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
            }
            catch (Exception exc) {
                // Log error
                EventManager.LogError(exc);
            }
        }
        #endregion

    }
}
