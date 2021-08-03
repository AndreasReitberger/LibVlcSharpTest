using LibVlcTest.Resources.Localization;
using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.Models.Privacy;
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
    public class PrivacyPageViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<PrivacyInfo> UsedServices
        {
            get => new ObservableCollection<PrivacyInfo>(PrivacyManager.List);
        }

        #endregion

        #region Constructor, LoadSettings

        public PrivacyPageViewModel()
        {
            IsLoading = true;
            LoadSettings();
            IsLoading = false;
        }

        void LoadSettings()
        {
            ShowWikiUris = SettingsManager.General_ShowWikiUris;
            ShowTitleInBar = SettingsManager.General_ShowTitlesInBar;
        }

        #endregion

        #region Command
        public Command ShowPrivacySettingsCommand
        {
            get => new Command(async (x) => await ShowPrivacySettingsAction());
        }
        async Task ShowPrivacySettingsAction()
        {
            try
            {
                await ShellNavigationManager.Instance.GoToAsync(ShellRoute.AdjustPrivacyModalPage, false);
            }
            catch (Exception exc)
            {
                //Log error
                EventManager.LogError(exc);
            }
        }

        public Command OpenWebSiteCommand
        {
            get => new Command(async (x) => await OpenWebSiteAction());
        }
        async Task OpenWebSiteAction()
        {
            try
            {
                Uri link = new Uri(SettingsStaticDefault.privacy_policy);
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
                //Log error
                EventManager.LogError(exc);
            }
        }

        #endregion

    }
}
