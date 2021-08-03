using RemoteControlRepetierServer.Models.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

#if LIGHT
using MarcTron.Plugin;
#endif

namespace RemoteControlRepetierServer.ViewModels
{
    /// <summary>
    /// This viewmodel extends in another viewmodels.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {

#region App
        bool _isBeta = SettingsStaticDefault.App_IsBeta;
        public bool IsBeta
        {
            get { return _isBeta; }
            set { SetProperty(ref _isBeta, value); }
        }
        bool _isLightVersion = SettingsStaticDefault.App_IsLightVersion;
        public bool IsLightVersion
        {
            get { return _isLightVersion; }
            set { SetProperty(ref _isLightVersion, value); }
        }
        
        bool _isStartingUp = false;
        public bool IsStartingUp
        {
            get { return _isStartingUp; }
            set { SetProperty(ref _isStartingUp, value); }
        }

        bool _isResuming = false;
        public bool IsResuming
        {
            get { return _isResuming; }
            set { SetProperty(ref _isResuming, value); }
        }

        bool _isTabletMode = false;
        public bool IsTabletMode
        {
            get { return _isTabletMode; }
            set { SetProperty(ref _isTabletMode, value); }
        }
#endregion

#region Navigation
        bool _isViewShown = false;
        public bool IsViewShown
        {
            get { return _isViewShown; }
            set { SetProperty(ref _isViewShown, value); }
        }
#endregion

#region Connection
        bool _isConnecting = false;
        public bool IsConnecting
        {
            get { return _isConnecting; }
            set { SetProperty(ref _isConnecting, value); }
        }
#endregion

#region Orientation
        bool _isPortrait = true;
        public bool IsPortrait
        {
            get { return _isPortrait; }
            set { SetProperty(ref _isPortrait, value); }
        }
        bool _isListening = false;
        public bool IsListening
        {
            get { return _isListening; }
            set { SetProperty(ref _isListening, value); }
        }

        bool _isListeningToWebSocket = false;
        public bool IsListeningToWebsocket
        {
            get { return _isListeningToWebSocket; }
            set { SetProperty(ref _isListeningToWebSocket, value); }
        }

        bool _closeWebSocketWhenLeaving = false;
        public bool CloseWebSocketWhenLeaving
        {
            get { return _closeWebSocketWhenLeaving; }
            set { SetProperty(ref _closeWebSocketWhenLeaving, value); }
        }
        #endregion

        #region Module

        string _printerName = string.Empty;
        public string PrinterName
        {
            get { return _printerName; }
            set { SetProperty(ref _printerName, value); }
        }

        bool _timerActive = false;
        public bool TimerActive
        {
            get { return _timerActive; }
            set { SetProperty(ref _timerActive, value); }
        }

        bool _wifiOn = false;
        public bool WifiOn
        {
            get { return _wifiOn; }
            set { SetProperty(ref _wifiOn, value); }
        }

        bool _isAppStartupCompleted = false;
        public bool IsAppStartupCompleted
        {
            get { return _isAppStartupCompleted; }
            set { SetProperty(ref _isAppStartupCompleted, value); }
        }

        bool _hasRestApiError = false;
        public bool HasRestApiError
        {
            get { return _hasRestApiError; }
            set { SetProperty(ref _hasRestApiError, value); }
        }

        bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        bool _isReady = false;
        public bool IsReady
        {
            get { return _isReady; }
            set { SetProperty(ref _isReady, value); }
        }

        bool _isStartUp = true;
        public bool IsStartUp
        {
            get { return _isStartUp; }
            set { SetProperty(ref _isStartUp, value); }
        }

        bool _isDemoModeOn;
        public bool IsDemoModeOn
        {
            get { return _isDemoModeOn; }
            set { SetProperty(ref _isDemoModeOn, value); }
        }

        bool _refreshOnAppearing = true;
        public bool RefreshOnAppearing
        {
            get { return _refreshOnAppearing; }
            set { SetProperty(ref _refreshOnAppearing, value); }
        }

        bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        bool _showTitleInBar = false;
        public bool ShowTitleInBar
        {
            get => _showTitleInBar;
            set
            {
                if (_showTitleInBar == value) return;
                _showTitleInBar = value;
                OnPropertyChanged();
            }
        }
        bool _showWikiUris = true;
        public bool ShowWikiUris
        {
            get => _showWikiUris;
            set
            {
                if (_showWikiUris == value) return;
                _showWikiUris = value;
                OnPropertyChanged();
            }
        }

        bool _showPrintProgressInTitleView = false;
        public bool ShowPrintProgressInTitleView
        {
            get => _showPrintProgressInTitleView;
            set
            {
                if (_showPrintProgressInTitleView == value) return;
                _showPrintProgressInTitleView = value;
                OnPropertyChanged();
            }
        }
        bool _showRemainingPrintTimeInTitleView = false;
        public bool ShowRemainingPrintTimeInTitleView
        {
            get => _showRemainingPrintTimeInTitleView;
            set
            {
                if (_showRemainingPrintTimeInTitleView == value) return;
                _showRemainingPrintTimeInTitleView = value;
                OnPropertyChanged();
            }
        }
#endregion

#region GlobalPrintInfo
        bool _isPrinterOnline = false;
        public bool IsPrinterOnline
        {
            get { return _isPrinterOnline; }
            set { SetProperty(ref _isPrinterOnline, value); }
        }

        bool _isPrinting = false;
        public bool IsPrinting
        {
            get { return _isPrinting; }
            set { SetProperty(ref _isPrinting, value); }
        }

        bool _isPaused = false;
        public bool IsPaused
        {
            get { return _isPaused; }
            set { SetProperty(ref _isPaused, value); }
        }

        double _progress = 0;
        public double Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }

        long _layers = 0;
        public long Layers
        {
            get { return _layers; }
            set { SetProperty(ref _layers, value); }
        }

        long _currentlayer = 0;
        public long CurrentLayer
        {
            get { return _currentlayer; }
            set { SetProperty(ref _currentlayer, value); }
        }

        double _remainingPrintTime = 0;
        public double RemainingPrintTime
        {
            get { return _remainingPrintTime; }
            set { SetProperty(ref _remainingPrintTime, value); }
        }
#endregion

#region Ads

        bool _disableAds = true;
        public bool DisableAds
        {
            get => _disableAds;
            set
            {
                if (_disableAds == value) return;
                _disableAds = value;
                OnPropertyChanged();
            }
        }

        int _interstitialCounter = SettingsStaticDefault.Ads_InterstitialAdCounter;
        public int InterstitialCounter
        {
            get => _interstitialCounter;
            set
            {
                if (_interstitialCounter == value) return;
                if (!IsLoading)
                    SettingsManager.Ads_InterstitialCounter = value;
                _interstitialCounter = value;
                OnPropertyChanged();
            }
        }

        bool _askForPersonalAdsConsent = true;
        public bool AskForPersonalAdsConsent
        {
            get => _askForPersonalAdsConsent;
            set
            {
                if (_askForPersonalAdsConsent == value) return;
                _askForPersonalAdsConsent = value;
                if (!IsLoading)
                    SettingsManager.Ads_AskForPersonalizedAds = value;

                OnPropertyChanged();
            }
        }

        bool _showPersonalizedAds = SettingsStaticDefault.Ads_ShowPersonalizedAds;
        public bool ShowPersonalizedAds
        {
            get => _showPersonalizedAds;
            set
            {
                if (_showPersonalizedAds == value) return;
                _showPersonalizedAds = value;
#if LIGHT
                CrossMTAdmob.Current.UserPersonalizedAds = value;
#endif
                if (!IsLoading)
                    SettingsManager.Privacy_AllowPersonalizedAds = value;

                OnPropertyChanged();
            }
        }

        bool _showBannerAdTop = true;
        public bool ShowBannerAdTop
        {
            get { return _showBannerAdTop; }
            set { SetProperty(ref _showBannerAdTop, value); }
        }

        string _adId_Banner_Android = "ca-app-pub-4086046848347384/9082175765";
        string _adId_Banner_Bottom_Android = "ca-app-pub-4086046848347384/1801671296";
        string _adId_Banner_iOS = "ca-app-pub-4086046848347384/5390342763";
        string _adId_Banner_Bottom_iOS = "ca-app-pub-4086046848347384/8773756834";
        public string AdId_Banner
        {
            get
            {

                if (Device.RuntimePlatform == "iOS")
                    return _adId_Banner_iOS;
                else
                    return _adId_Banner_Android;
            }

        }
        public string AdId_Banner_Bottom
        {
            get
            {

                if (Device.RuntimePlatform == "iOS")
                    return _adId_Banner_Bottom_iOS;
                else
                    return _adId_Banner_Bottom_Android;
            }

        }

        string _adId_Interstitial_Android = "ca-app-pub-4086046848347384/8270784837";
        // Test ID
        //"ca-app-pub-3940256099942544/4411468910";
        string _adId_Interstitial_iOS = "ca-app-pub-4086046848347384/1294312945";
        public string AdId_Interstitial
        {
            get
            {
                if (Device.RuntimePlatform == "iOS")
                    return _adId_Interstitial_iOS;
                else
                    return _adId_Interstitial_Android;
            }

        }
#endregion

#region Constructor
        public BaseViewModel()
        {
            IsLoading = true;
            LoadSettings();
            IsLoading = false;
        }

        void LoadSettings()
        {
            InterstitialCounter = SettingsManager.Ads_InterstitialCounter;
            AskForPersonalAdsConsent = SettingsManager.Ads_AskForPersonalizedAds;
            ShowPersonalizedAds = SettingsManager.Privacy_AllowPersonalizedAds;
#if LIGHT
            CrossMTAdmob.Current.UseRestrictedDataProcessing = true;
#endif
        }
#endregion

#region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#endregion

#region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            // Ordinarily, we release unmanaged resources here;
            // but all are wrapped by safe handles.

            // Release disposable objects.
            if (disposing)
            {

            }
        }
#endregion
    }
}
