using LibVlcTest.Resources.Localization;
using RemoteControlRepetierServer.Models.Documentation;
using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.Models.Settings;
using RemoteControlRepetierServer.Models.ShellHelper.Navigation;

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RemoteControlRepetierServer.ViewModels
{
    [Preserve(AllMembers = true)]
    public class AboutPageViewModel : BaseViewModel
    {

        #region Properties
        public ObservableCollection<LibraryInfo> Libraries
        {
            get => new ObservableCollection<LibraryInfo>(LibraryManager.List);
        }

        public ObservableCollection<ResourceInfo> Resources
        {
            get => new ObservableCollection<ResourceInfo>(ResourceManager.List);
        }

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
        #endregion

        #region Constructor, LoadSettings

        public AboutPageViewModel()
        {
            InitCommands();

            IsLoading = true;
            LoadSettings();
            IsLoading = false;

            Version = DependencyService.Get<IAppVersionAndBuild>().GetVersionNumber();
            Build = DependencyService.Get<IAppVersionAndBuild>().GetBuildNumber();
        }

        void InitCommands()
        {
            ShowBuildDetailsCommand = new Command(async () => await ShowBuildDetailsAction(), ShowBuildDetailsCommand_CanExcecute);
        }

        void LoadSettings()
        {
            PrinterName = SettingsManager.PrintServer_LastUsedPrinterProfile;

            ShowTitleInBar = SettingsManager.General_ShowTitlesInBar;
            ShowWikiUris = SettingsManager.General_ShowWikiUris;
        }

        #endregion

        #region Command

        public Command OpenWebSiteCommand
        {
            get => new Command(async (x) => await OpenWebSiteAction(x));
        }
        async Task OpenWebSiteAction(object uri)
        {
            try
            {
                var str = uri.ToString();
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
            }
        }

        public Command OpenSocialMediaPageCommand
        {
            get => new Command(async (x) => await OpenSocialMediaPageAction(x));
        }
        async Task OpenSocialMediaPageAction(object parameter)
        {
            try
            {
                var str = parameter.ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    Uri link;
                    switch (str)
                    {
                        case "Facebook":
                            link = new Uri(DocumentationManager.FacebookUrl);
                            break;
                        case "Instagram":
                            link = new Uri(DocumentationManager.InstagramUrl);
                            break;
                        default:
                            link = new Uri(DocumentationManager.ProjectUrl);
                            break;
                    }

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
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }

        #region ShellNavigation
        public Command ShowBuildDetailsCommand { get; set; }

        bool ShowBuildDetailsCommand_CanExcecute()
        {
            return true;
        }
        async Task ShowBuildDetailsAction()
        {
            try
            {
                await ShellNavigationManager.Instance.GoToAsync(ShellRoute.VersionDetailPage, false);
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }
        #endregion

        #endregion

    }
}
