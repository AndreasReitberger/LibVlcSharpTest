using LibVLCSharp.Shared;
using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.Models.Messaging;
using RemoteControlRepetierServer.Models.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
//using Xamarin.CommunityToolkit.Core;

namespace RemoteControlRepetierServer.ViewModels
{
    [Preserve(AllMembers = true)]
    public class DashboardViewModel : BaseViewModel
    {

        #region Dummy

        int _dummyTabIndex = 0;
        public int DummyTabIndex
        {
            get => _dummyTabIndex;
            set
            {
                if (_dummyTabIndex == value) return;
                _dummyTabIndex = value;
                OnPropertyChanged();
            }
        }

        MediaPlayer _dummyMediaPlayer;
        public MediaPlayer DummyMediaPlayer
        {
            get => _dummyMediaPlayer;
            set
            {
                if (_dummyMediaPlayer == value) return;
                _dummyMediaPlayer = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Module

        bool _isDemoModeOn;
        public new bool IsDemoModeOn
        {
            get => _isDemoModeOn;
            set
            {
                if (_isDemoModeOn == value) return;
                _isDemoModeOn = value;
                EnableWebCamCommand.ChangeCanExecute();
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
                IsOnTabletMode();
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
                IsOnTabletMode();
                OnPropertyChanged();
            }
        }

        bool _simulatePrint = true;
        public bool SimulatePrint
        {
            get => _simulatePrint;
            set
            {
                if (_simulatePrint == value) return;
                _simulatePrint = value;
                OnPropertyChanged();
            }
        }

        bool _showImage = true;
        public bool ShowImage
        {
            get => _showImage;
            set
            {
                if (_showImage == value) return;
                if (!IsLoading)
                    SettingsManager.General_ShowPreviewImage = value;
                _showImage = value;
                OnPropertyChanged();
            }
        }

        bool _showOnlyWebCamInLandscape = true;
        public bool ShowOnlyWebCamInLandscape
        {
            get => _showOnlyWebCamInLandscape;
            set
            {
                if (_showOnlyWebCamInLandscape == value) return;
                if (!IsLoading)
                    SettingsManager.General_ShowOnlyWebCamInLandscape = value;
                _showOnlyWebCamInLandscape = value;
                OnPropertyChanged();
            }
        }

        bool _hideProgressBarInTopView = false;
        public bool HideProgressBarInTopView
        {
            get => _hideProgressBarInTopView;
            set
            {
                if (_hideProgressBarInTopView == value) return;
                if (!IsLoading)
                {
                    SettingsManager.General_HideProgressBarInTopView = value;
                }
                _hideProgressBarInTopView = value;
                OnPropertyChanged();
            }
        }

        bool _collapseTopViewWhileNotPrinting = false;
        public bool CollapseTopViewWhileNotPrinting
        {
            get => _collapseTopViewWhileNotPrinting;
            set
            {
                if (_collapseTopViewWhileNotPrinting == value) return;
                if (!IsLoading)
                {
                    SettingsManager.General_CollapseTopViewWhileNotPrinting = value;
                }
                _collapseTopViewWhileNotPrinting = value;
                OnPropertyChanged();
            }
        }

        bool _isLoadingImage = false;
        public bool IsLoadingImage
        {
            get => _isLoadingImage;
            set
            {
                if (_isLoadingImage == value) return;
                _isLoadingImage = value;
                OnPropertyChanged();
            }
        }

        bool _isNewPrintJob = true;
        public bool IsNewPrintJob
        {
            get => _isNewPrintJob;
            set
            {
                if (_isNewPrintJob == value) return;
                _isNewPrintJob = value;
                OnPropertyChanged();
            }
        }

        bool _refreshOnAppearing = true;
        public new bool RefreshOnAppearing
        {
            get => _refreshOnAppearing;
            set
            {
                if (_refreshOnAppearing == value) return;
                _refreshOnAppearing = value;
                OnPropertyChanged();
            }
        }

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

        int _gaugeHeight = 200;
        public int GaugeHeight
        {
            get => _gaugeHeight;
            set
            {
                if (_gaugeHeight == value) return;
                _gaugeHeight = value;
                if (!IsLoading)
                    SettingsManager.General_GaugeHeight = value;
                OnPropertyChanged();
            }
        }

        int _gaugeHeightPrinting = 150;
        public int GaugeHeightPrinting
        {
            get => _gaugeHeightPrinting;
            set
            {
                if (_gaugeHeightPrinting == value) return;
                _gaugeHeightPrinting = value;
                if (!IsLoading)
                    SettingsManager.General_GaugeHeightPrinting = value;
                OnPropertyChanged();
            }
        }

        bool _expandPrintOptions = true;
        public bool ExpandPrintOptions
        {
            get => _expandPrintOptions;
            set
            {
                if (_expandPrintOptions == value) return;
                _expandPrintOptions = value;
                OnPropertyChanged();
            }
        }

        bool _expandTopView = true;
        public bool ExpandTopView
        {
            get => _expandTopView;
            set
            {
                if (_expandTopView == value) return;
                if (!IsLoading)
                    SettingsManager.General_ExpandTopView = value;
                _expandTopView = value;
                OnPropertyChanged();
            }
        }

        bool _loadModelImages = true;
        public bool LoadModelImages
        {
            get => _loadModelImages;
            set
            {
                if (_loadModelImages == value) return;
                if (!IsLoading)
                    SettingsManager.PrintServer_Global_LoadModelImages = value;
                _loadModelImages = value;
                OnPropertyChanged();
            }
        }

        bool _loadModelImagesInBackground = true;
        public bool LoadModelImagesInBackground
        {
            get => _loadModelImagesInBackground;
            set
            {
                if (_loadModelImagesInBackground == value) return;
                if (!IsLoading)
                    SettingsManager.PrintServer_Global_LoadModelImagesInBackground = value;
                _loadModelImagesInBackground = value;
                OnPropertyChanged();
            }
        }

        bool _enableEmergencyStopButton = SettingsStaticDefault.PrintServer_Additional_EnableEmergencyStopButton;
        public bool EnableEmergencyStopButton
        {
            get => _enableEmergencyStopButton;
            set
            {
                if (_enableEmergencyStopButton == value) return;
                if (!IsLoading)
                    SettingsManager.PrintServer_Additional_EnableEmergencyStopButton = value;
                _enableEmergencyStopButton = value;
                OnPropertyChanged();
            }
        }

        bool _enableSecurityQuestionForEmergencyStopButton = SettingsStaticDefault.PrintServer_Additional_EnableSecurityQuestionForEmergencyStop;
        public bool EnableSecurityQuestionForEmergencyStopButton
        {
            get => _enableSecurityQuestionForEmergencyStopButton;
            set
            {
                if (_enableSecurityQuestionForEmergencyStopButton == value) return;
                if (!IsLoading)
                    SettingsManager.PrintServer_Additional_EnableSecurityQuestionForEmergencyStop = value;
                _enableSecurityQuestionForEmergencyStopButton = value;
                OnPropertyChanged();
            }
        }

        bool _showPrivacySettings = true;
        public bool ShowPrivacySettings
        {
            get => _showPrivacySettings;
            set
            {
                if (_showPrivacySettings == value) return;
                if (!IsLoading)
                    SettingsManager.Privacy_ShowPrivacySettings = value;
                _showPrivacySettings = value;
                OnPropertyChanged();
            }
        }

        bool _useCardViewForFiles = true;
        public bool UseCardViewForFiles
        {
            get => _useCardViewForFiles;
            set
            {
                if (_useCardViewForFiles == value) return;
                if (!IsLoading)
                    SettingsManager.PrintServer_Global_UseFileCardTemplate = value;
                _useCardViewForFiles = value;
                OnPropertyChanged();
            }
        }

        bool _isTabletMode;
        public new bool IsTabletMode
        {
            get => _isTabletMode;
            set
            {
                if (_isTabletMode == value) return;
                _isTabletMode = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Properties

        #region Notifications
        bool _notifyOnNewMessages = SettingsStaticDefault.Notification_NotifyOnNewMessage;
        public bool NotifyOnNewMessages
        {
            get => _notifyOnNewMessages;
            set
            {
                if (_notifyOnNewMessages == value) return;
                if (!IsLoading)
                    SettingsManager.Notification_NotifyOnNewMessage = value;
                _notifyOnNewMessages = value;
                OnPropertyChanged();
            }
        }

        bool _notifyOnPrintJobDone = SettingsStaticDefault.Notification_NotifyOnPrintJobDone;
        public bool NotifyOnPrintJobDone
        {
            get => _notifyOnPrintJobDone;
            set
            {
                if (_notifyOnPrintJobDone == value) return;
                if (!IsLoading)
                    SettingsManager.Notification_NotifyOnPrintJobDone = value;
                _notifyOnPrintJobDone = value;
                OnPropertyChanged();
            }
        }

        bool _notifyOnWebSocketErrors = SettingsStaticDefault.Notification_NotifyOnWebSocketErrors;
        public bool NotifyOnWebSocketErrors
        {
            get => _notifyOnWebSocketErrors;
            set
            {
                if (_notifyOnWebSocketErrors == value) return;
                if (!IsLoading)
                    SettingsManager.Notification_NotifyOnWebSocketErrors = value;
                _notifyOnWebSocketErrors = value;
                OnPropertyChanged();
            }
        }

        bool _notifyOnServerOffline = SettingsStaticDefault.Notification_NotifyOnServerOffline;
        public bool NotifyOnServerOffline
        {
            get => _notifyOnServerOffline;
            set
            {
                if (_notifyOnServerOffline == value) return;
                if (!IsLoading)
                    SettingsManager.Notification_NotifyOnServerOffline = value;
                _notifyOnServerOffline = value;
                OnPropertyChanged();
            }
        }

        bool _notifyOnUpdateAvailable = SettingsStaticDefault.Notification_NotifyOnUpdateAvailable;
        public bool NotifyOnUpdateAvailable
        {
            get => _notifyOnUpdateAvailable;
            set
            {
                if (_notifyOnUpdateAvailable == value) return;
                if (!IsLoading)
                    SettingsManager.Notification_NotifyOnUpdateAvailable = value;
                _notifyOnServerOffline = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Limits

        double _limitFan = 100;
        public double LimitFan
        {
            get => _limitFan;
            set
            {
                if (_limitFan == value) return;
                _limitFan = value;
                OnPropertyChanged();
            }
        }

        double _fanInterval = 25;
        public double FanInterval
        {
            get => _fanInterval;
            set
            {
                if (_fanInterval == value) return;
                _fanInterval = value;
                OnPropertyChanged();
            }
        }

        double _limitFlowLow = 50;
        public double LimitFlowLow
        {
            get => _limitFlowLow;
            set
            {
                if (_limitFlowLow == value) return;
                _limitFlowLow = value;
                OnPropertyChanged();
            }
        }

        double _limitFlow = 200;
        public double LimitFlow
        {
            get => _limitFlow;
            set
            {
                if (_limitFlow == value) return;
                _limitFlow = value;
                OnPropertyChanged();
            }
        }

        double _limitSpeed = 200;
        public double LimitSpeed
        {
            get => _limitSpeed;
            set
            {
                if (_limitSpeed == value) return;
                _limitSpeed = value;
                OnPropertyChanged();
            }
        }

        double _limitSpeedLow = 50;
        public double LimitSpeedLow
        {
            get => _limitSpeedLow;
            set
            {
                if (_limitSpeedLow == value) return;
                _limitSpeedLow = value;
                OnPropertyChanged();
            }
        }

        double _limitExtruder = 300;
        public double LimitExtruder
        {
            get => _limitExtruder;
            set
            {
                if (_limitExtruder == value) return;
                _limitExtruder = value;
                MiddleExtruder = _limitExtruder / 2;
                OnPropertyChanged();
            }
        }

        double _middleExtruder = 150;
        public double MiddleExtruder
        {
            get => _middleExtruder;
            set
            {
                if (_middleExtruder == value) return;
                _middleExtruder = value;
                OnPropertyChanged();
            }
        }

        double _extruderInterval = 50;
        public double ExtruderInterval
        {
            get => _extruderInterval;
            set
            {
                if (_extruderInterval == value) return;
                _extruderInterval = value;
                OnPropertyChanged();
            }
        }

        double _limitHeatedBed = 120;
        public double LimitHeatedBed
        {
            get => _limitHeatedBed;
            set
            {
                if (_limitHeatedBed == value) return;
                _limitHeatedBed = value;
                MiddleHeatedBed = _limitHeatedBed / 2;
                OnPropertyChanged();
            }
        }

        double _middleHeatedBed = 60;
        public double MiddleHeatedBed
        {
            get => _middleHeatedBed;
            set
            {
                if (_middleHeatedBed == value) return;
                _middleHeatedBed = value;
                OnPropertyChanged();
            }
        }

        double _heatedBedInterval = 20;
        public double HeatedBedInterval
        {
            get => _heatedBedInterval;
            set
            {
                if (_heatedBedInterval == value) return;
                _heatedBedInterval = value;
                OnPropertyChanged();
            }
        }

        double _limitHeatedChamber = 70;
        public double LimitHeatedChamber
        {
            get => _limitHeatedChamber;
            set
            {
                if (_limitHeatedChamber == value) return;
                _limitHeatedChamber = value;
                MiddleHeatedChamber = _limitHeatedChamber / 2;
                OnPropertyChanged();
            }
        }

        double _middleHeatedChamber = 35;
        public double MiddleHeatedChamber
        {
            get => _middleHeatedChamber;
            set
            {
                if (_middleHeatedChamber == value) return;
                _middleHeatedChamber = value;
                OnPropertyChanged();
            }
        }

        double _heatedChamberInterval = 10;
        public double HeatedChamberInterval
        {
            get => _heatedChamberInterval;
            set
            {
                if (_heatedChamberInterval == value) return;
                _heatedChamberInterval = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Printer

        string _printerName;
        public new string PrinterName
        {
            get => _printerName;
            set
            {
                if (_printerName == value) return;
                _printerName = value;
                // If printer has changed, refresh the page.
                //Task.Run(async () => await RefreshDashboardAction());
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
        #endregion

        #region Server

        bool _fetchPrinterDataViaTimer = true;
        public bool FetchPrinterDataViaTimer
        { 
            get => _fetchPrinterDataViaTimer;
            set
            {
                if (_fetchPrinterDataViaTimer == value) return;
                _fetchPrinterDataViaTimer = value;
                OnPropertyChanged();
            }
        }

        int _updateInterval = 2;
        public int UpdateInterval
        { 
            get => _updateInterval;
            set
            {
                if (_updateInterval == value) return;
                _updateInterval = value;
                OnPropertyChanged();
            }
        }
#endregion

        #region PrintServerSettings

        bool _hasWebCams = false;
        public bool HasWebCams
        {
            get => _hasWebCams;
            set
            {
                if (_hasWebCams == value) return;
                _hasWebCams = value;
                OnPropertyChanged();
            }
        }

        byte[] _thumb;
        public byte[] Thumbnail
        {
            get => _thumb;
            set
            {
                if (_thumb == value)
                    return;
                _thumb = value;
                OnPropertyChanged();
            }
        }

#region PrinterSetup
        int _currentExtruder = 0;
        public int CurrentExtruder
        {
            get => _currentExtruder;
            set
            {
                if (_currentExtruder == value) return;
                _currentExtruder = value;

                //SetSelectedExtruder(value);
                OnPropertyChanged();
                
            }
        }

        int _currentHeatedBed = 0;
        public int CurrentHeatedBed
        {
            get => _currentHeatedBed;
            set
            {
                if (_currentHeatedBed == value) return;              
                _currentHeatedBed = value;
                //SetSelectedHeatedBed(value);
                OnPropertyChanged();
            }
        }

        int _currentHeatedChamber = 0;
        public int CurrentHeatedChamber
        {
            get => _currentHeatedChamber;
            set
            {
                if (_currentHeatedChamber == value) return;              
                _currentHeatedChamber = value;
                //SetSelectedHeatedChamber(value);
                OnPropertyChanged();
                
            }
        }

        int _currentFan = 0;
        public int CurrentFan
        {
            get => _currentFan;
            set
            {
                if (_currentFan == value) return;                
                _currentFan = value;
                //SetSelectedFan(value);
                OnPropertyChanged();
                
            }
        }

#endregion

#endregion

        #region API

        object _versionInfo;
        public object VersionInfo
        {
            get => _versionInfo;
            set
            {
                if (_versionInfo == value) return;

                _versionInfo = value;
                OnPropertyChanged();

            }
        }

        #endregion

        #region Connection

        object _connectionState;
        public object ConnectionState
        {
            get => _connectionState;
            set
            {
                if (_connectionState == value) return;

                _connectionState = value;
                OnPropertyChanged();

            }
        }
        object _connectionSettings;
        public object ConnectionSettings
        {
            get => _connectionSettings;
            set
            {
                if (_connectionSettings == value) return;

                _connectionSettings = value;
                OnPropertyChanged();

            }
        }
        #endregion

        #region WebCam

        bool _isDefaultSetting = false;
        public bool IsDefaultSetting
        {
            get => _isDefaultSetting;
            set
            {
                if (_isDefaultSetting == value) return;
                _isDefaultSetting = value;
                OnPropertyChanged();
            }
        }

        WebCamIdentifier _webCamIdentifier = new WebCamIdentifier() { View = WebCamView.Dashboard };
        public WebCamIdentifier WebCamIdentifier
        {
            get => _webCamIdentifier;
            set
            {
                if (_webCamIdentifier == value) return;
                _webCamIdentifier = value;
                OnPropertyChanged();
            }
        }

        int _rotation = 0;
        public int Rotation
        {
            get => _rotation;
            set
            {
                if (_rotation == value) return;
                _rotation = value;
                OnPropertyChanged();
            }
        }

        int _selectedWebCamIndex = 0;
        public int SelectedWebCamIndex
        {
            get => _selectedWebCamIndex;
            set
            {
                if (_selectedWebCamIndex == value) return;
                _selectedWebCamIndex = value;
                LoadWebCamSettings();
                OnPropertyChanged();
            }
        }

        bool _isLoadingWebCamStream = false;
        public bool IsLoadingWebCamStream
        {
            get => _isLoadingWebCamStream;
            set
            {
                if (_isLoadingWebCamStream == value) return;
                _isLoadingWebCamStream = value;
                OnPropertyChanged();
            }
        }

        bool _WebCamEnabled = false;
        public bool WebCamEnabled
        {
            get => _WebCamEnabled;
            set
            {
                if (_WebCamEnabled == value) return;
                _WebCamEnabled = value;
                if (!IsLoading)
                {
                    //SaveWebCamSettings();
                    SettingsManager.RepetierServer_WebCamEnabeled = value;
                }
                OnPropertyChanged();
            }
        }

        bool _autostart = true;
        public bool Autostart
        {
            get => _autostart;
            set
            {
                if (_autostart == value) return;
                /*
                if (!IsLoading)
                    SaveWebCamSettings();
                */
                _autostart = value;
                OnPropertyChanged();
            }
        }

        int _networkBufferTime = 150;
        public int NetworkBufferTime
        {
            get => _networkBufferTime;
            set
            {
                if (_networkBufferTime == value) return;
                _networkBufferTime = value;
                if (!IsLoading)
                {
                    //SaveWebCamSettings();
                    //MessagingCenter.Send(WebCamIdentifier, Messages.OnRestartWebCam.ToString());
                }
                OnPropertyChanged();
            }
        }

        int _fileCaching = 2000;
        public int FileCaching
        {
            get => _fileCaching;
            set
            {
                if (_fileCaching == value) return;
                _fileCaching = value;
                if (!IsLoading)
                {
                    //SaveWebCamSettings();
                    //MessagingCenter.Send(WebCamIdentifier, Messages.OnRestartWebCam.ToString());
                }
                OnPropertyChanged();
            }
        }

        MediaPlayer _mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set
            {
                if (_mediaPlayer == value)
                    return;
                _mediaPlayer = value;
                OnPropertyChanged();
            }
        }

        string _webCamUri = string.Empty;
        public string WebCamUri
        {
            get => _webCamUri;
            set
            {
                if (value == _webCamUri)
                    return;

                _webCamUri = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region History
        int _position = 0;
        public int Position
        {
            get => _position;
            set
            {
                if (_position == value) return;
                _position = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Segments
        int _tabIndex = 0;
        public int TabIndex
        {
            get => _tabIndex;
            set
            {
                if (_tabIndex == value) return;
                _tabIndex = value;
                OnPropertyChanged();
                //UpdateTabData();
            }
        }

        int _tabletTabIndex = 0;
        public int TabletTabIndex
        {
            get => _tabletTabIndex;
            set
            {
                if (_tabletTabIndex == value) return;
                _tabletTabIndex = value;
                OnPropertyChanged();
                UpdateTabData(false);
            }
        }
        //public ObservableCollection<SfSegmentItem> SegmentButtons { get; set; } = new ObservableCollection<SfSegmentItem>();
        #endregion

        #endregion

        #region Constructor, LoadSettings
        public DashboardViewModel()
        {
            IsOnTabletMode();
            InitCommands();
            //SubscribeVitalServerEvents();

            IsLoading = true;
            LoadSettings();
            IsLoading = false;
        }

        void InitCommands()
        {
            RefreshDashboardCommand = new Command(async () => await RefreshDashboardAction(), RefreshDashboardCommand_CanExcecute);
            
            EnableWebCamCommand = new Command(async () => await EnableWebCamAction(), EnableWebCamCommand_CanExcecute);
            DisableWebCamCommand = new Command(() => DisableWebCamAction(), DisableWebCamCommand_CanExcecute);
            RefreshWebCamViewCommand = new Command(async () => await RefreshWebCamViewAction(), RefreshWebCamViewCommand_CanExcecute);

            StartWebCamStreamCommand = new Command(() => StartWebCamStreamAction(), StartWebCamStreamCommand_CanExcecute);
            StopWebCamViewCommand = new Command(() => StopWebCamViewAction(), StopWebCamViewActionCommand_CanExcecute);
            PauseWebCamStreamCommand = new Command(() => PauseWebCamStreamAction(), PauseWebCamStreamCommand_CanExcecute);
        }

        void LoadSettings()
        {
            IsLoading = true;
            ShowPrivacySettings = SettingsManager.Privacy_ShowPrivacySettings;
            IsLoading = false;
        }
        void LoadWebCamSettings()
        {
            IsLoading = true;

            WebCamEnabled = SettingsManager.RepetierServer_WebCamEnabeled;
            WebCamUri = string.Empty;
            NetworkBufferTime = 150;
            FileCaching = 150;
            Rotation = 0;
            Autostart = true;

            IsLoading = false;
        }
        #endregion


        #region Command

        #region Refresh

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
                if (IsDemoModeOn)
                {
                    // Load data from DemoManager instead
                    IsPrinterOnline = true;
                    await Task.Delay(100);
                }
                else
                {
                    if (WebCamEnabled)
                    {
                        if (!IsResuming)
                        {
                            await RefreshWebCamViewAction();
                            if (Autostart)
                            {
                                await Task.Delay(25);
                                StartWebCamStreamAction();
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            IsRefreshing = false;
        }
        #endregion

        #region WebCam Commands
        public Command EnableWebCamCommand { get; set; }
        bool EnableWebCamCommand_CanExcecute()
        {
            return true; // !IsDemoModeOn;
        }
        async Task EnableWebCamAction()
        {
            try
            {
                WebCamEnabled = true;
                await RefreshWebCamViewAction();
                StartWebCamStreamAction();

            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            //IsLoadingWebCamStream = false;
        }

        public Command DisableWebCamCommand { get; set; }
        bool DisableWebCamCommand_CanExcecute()
        {
            return !IsDemoModeOn;
        }
        void DisableWebCamAction()
        {
            try
            {
                WebCamEnabled = false;
                StopWebCamViewAction();

            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            //IsLoadingWebCamStream = false;
        }

        public Command RefreshWebCamViewCommand { get; set; }

        bool RefreshWebCamViewCommand_CanExcecute()
        {
            return true;
        }

        async Task RefreshWebCamViewAction()
        {
            try
            {
                // Only refresh if the uri has changed
                string newUri = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"; //RepetierServerPro.Instance.GetWebCamUri(SelectedWebCamIndex);
                if (newUri == WebCamUri)
                {
                    await Task.Delay(100);
                    return;
                }
                
                IsLoadingWebCamStream = true;
                WebCamUri = newUri;
                if (!string.IsNullOrEmpty(WebCamUri))
                {
                    try
                    {
                        List<string> options = new()
                        {
                            string.Format("--file-caching={0}", FileCaching)
                        };

                        using LibVLC libvlc = new(options.ToArray());
                        using Media Media = new (libvlc, WebCamUri, FromType.FromLocation);

                        Media.AddOption(string.Format(":network-caching={0}", NetworkBufferTime));
                        Media.AddOption(string.Format(":clock-jitter={0}", 0));
                        Media.AddOption(string.Format(":clock-synchro={0}", 0));

                        MediaParsedStatus result = await Media.Parse(MediaParseOptions.ParseNetwork);

                        MediaPlayer = new MediaPlayer(Media)
                        {
                            EnableHardwareDecoding = true,
                            NetworkCaching = Convert.ToUInt32(NetworkBufferTime),
                            FileCaching = Convert.ToUInt32(FileCaching),

                        };
                    }
                    catch (Exception exc)
                    {
                        MediaPlayer = null;
                        // Log error
                        EventManager.LogError(exc);
                        Debug.WriteLine(string.Format("VlcException => {0} ({1})", exc.Message, exc.StackTrace));
                    }

                }
                IsLoadingWebCamStream = false;
                
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            IsLoadingWebCamStream = false;
        }

        public Command StartWebCamStreamCommand { get; set; }
        bool StartWebCamStreamCommand_CanExcecute()
        {
            return true;
        }
        void StartWebCamStreamAction()
        {
            try
            {
                if (MediaPlayer != null && !MediaPlayer.IsPlaying)
                {
                    ThreadPool.QueueUserWorkItem((object stateInfo) => 
                    {
                        try
                        {
                            if (MediaPlayer != null && !MediaPlayer.IsPlaying)
                            {
                                MediaPlayer.Play();
#if DEBUG
                                EventManager.LogEvent(new()
                                {
                                    Message = $"WebCam => Start playing: {MediaPlayer.Media}"
                                });
#endif
                            }
                        }
                        catch (Exception exc)
                        {
                            // Log error
                            EventManager.LogError(exc);
                        }
                    });
                    
                }                     
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
        }

        public Command PauseWebCamStreamCommand { get; set; }
        bool PauseWebCamStreamCommand_CanExcecute()
        {
            return true;
        }
        void PauseWebCamStreamAction()
        {
            try
            {
                // Avoids starting and refreshing of the WebCam view if it's not needed or allowed
                if (!ValidateWebCamView())
                    return;

                //IsLoadingWebCamStream = true;
                // Needs to be done in a new task
                if (MediaPlayer != null && !MediaPlayer.IsPlaying)
                {
                    //await Task.Delay(50);
                    ThreadPool.QueueUserWorkItem((Object stateInfo) => 
                    {
                        try
                        {
                            if (MediaPlayer != null && MediaPlayer.CanPause)
                            {
                                MediaPlayer.Pause();
#if DEBUG
                                EventManager.LogEvent(new()
                                {
                                    Message = $"WebCam => paused playing"
                                });
#endif
                            }
                        }
                        catch (Exception exc)
                        {
                            // Log error
                            EventManager.LogError(exc);
                        }
                    });
                    
                }                      
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            //IsLoadingWebCamStream = false;
        }

        public Command StopWebCamViewCommand { get; set; }
        bool StopWebCamViewActionCommand_CanExcecute()
        {
            return true;
        }
        void StopWebCamViewAction()
        {
            try
            {
                // Avoids starting and refreshing of the WebCam view if it's not needed or allowed
                if (!ValidateWebCamView(true))
                    return;

                //IsLoadingWebCamStream = true;
                if (MediaPlayer != null && MediaPlayer.IsPlaying)
                {
                    //MediaPlayer.Stop();
                    ThreadPool.QueueUserWorkItem((Object stateInfo) =>
                    {
                        try
                        {
                            if (MediaPlayer != null && MediaPlayer.IsPlaying)
                            {
                                MediaPlayer.Stop();
#if DEBUG
                                EventManager.LogEvent(new()
                                {
                                    Message = $"WebCam => stopped playing"
                                });
#endif
                            }
                        }
                        catch(Exception exc)
                        {
                            // Log error
                            EventManager.LogError(exc);
                        }
                    });
                    //await Task.Delay(100);
                }                                    
                //IsLoadingWebCamStream = false;              
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            //IsLoadingWebCamStream = false;
        }

#endregion

        #endregion

        bool ValidateWebCamView(bool OnlyCheckCurrentRoute = false)
        {
            try
            {
                bool isValid = false;
                if (App.State != AppState.Foreground)
                    isValid = false;
                if (!OnlyCheckCurrentRoute && (!WebCamEnabled))
                    isValid = false;
                // Indicates tablet mode
                else if (IsTabletMode)
                {
                    if (!IsViewShown && MediaPlayer != null && MediaPlayer.IsPlaying)
                    {
                        isValid = true;
                    }
                    else
                        isValid = IsViewShown;
                }
                else
                    isValid = IsViewShown;
                /*
                else if (!IsViewShown)
                    return false;
                else
                    return true;
                */
#if DEBUG
                EventManager.LogEvent(new()
                {
                    Message = $"ValidateWebCamView => {isValid}"
                });
#endif
                return isValid;
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
                return false;
            }
        }

        #region WebCam



        void UpdateWebCamView()
        {
            try
            {
                WebCamUri = string.Empty;
                NetworkBufferTime = 150;
                FileCaching = 150;
                Rotation = 0;
                Autostart = true;

            }
            catch(Exception exc)
            {
                EventManager.LogError(exc);
            }
        }
        #endregion

        #region Tabs
        void UpdateTabData(bool overrideViewState, bool viewShown = false, bool startWebCamIfEnabled = true)
        {
            if (IsOnTabletMode())
            {
                // Indicates that the WebCamView is visible.
                // Otherwise do not start streaming
                IsViewShown = TabletTabIndex == 2;
            }
            else if (overrideViewState)
            {
                IsViewShown = viewShown;
            }
            if (IsViewShown)
            {
                if (WebCamEnabled && startWebCamIfEnabled)
                {
                    MessagingCenter.Send(WebCamIdentifier, Messages.OnRestartWebCam.ToString());
                }
            }
            /*
            EventManager.LogEvent(new()
            {
                Message = $"UpdateTabData => isViewShown: {IsViewShown}"
            });
            */
        }

        bool IsOnTabletMode()
        {
            IsTabletMode = true; // (AutoTabletMode && Device.Idiom == TargetIdiom.Tablet) || (!AutoTabletMode && EnableTabletModeManually);
            return IsTabletMode;
        }
        #endregion

        public async Task OnAppearing()
        {
            try
            {
                // For WebCam refreshing
                IsBusy = true;
                LoadSettings();
                // Indicates TabletMode
                if (IsOnTabletMode())
                {
                    IsViewShown = TabletTabIndex == 2;
                }
                else
                    IsViewShown = true;

                //WebCam
                LoadWebCamSettings();
                WebCamEnabled = true;
                if (IsStartUp)
                {
                    await RefreshDashboardAction();
                }
                else
                {
                    // Refresh on each page appearing
                    if (RefreshOnAppearing)
                    {
                        await RefreshDashboardAction();
                    }
                    else
                    {
                        if (WebCamEnabled && (MediaPlayer == null || !MediaPlayer.IsPlaying))
                        {
                            MessagingCenter.Send(WebCamIdentifier, Messages.OnRestartWebCam.ToString());
                        }
                    }
                }
                if (IsStartingUp)
                    IsStartingUp = false;
            }
            catch (Exception exc)
            {
                // Log error
                EventManager.LogError(exc);
            }
            IsBusy = false;
            IsStartUp = false;
            OnPropertyChanged(nameof(AutoTabletMode));
            OnPropertyChanged(nameof(EnableTabletModeManually));
        }

        public void OnDisappearing()
        {
            try
            {
                //Stop stream before leaving
                StopWebCamViewAction();
                IsViewShown = false;
            }
            catch (Exception exc) {
                // Log error
                EventManager.LogError(exc);
            }
        }

    }
}
