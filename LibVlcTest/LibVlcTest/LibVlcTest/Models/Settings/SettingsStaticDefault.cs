using System.Collections.ObjectModel;

namespace RemoteControlRepetierServer.Models.Settings
{
    public class SettingsStaticDefault
    {
        #region App
        public static bool App_IsBeta = false;
#if PRO
        public static bool App_IsLightVersion = false;
#else
        public static bool App_IsLightVersion = true;
#endif
        public static string App_SupportMail = "kontakt@andreas-reitberger.de";
#endregion

#region Privacy
        public static string privacy_policy = "https://andreas-reitberger.de/datenschutz/pp-rc-repetier/";
        public static bool Privacy_ShowPrivacySettings = true;
        // Needs to be off by default!
        public static bool Privacy_AllowCrashAnalytics = false;
        public static bool Privacy_AllowAnalyticsData = false;
        public static bool Privacy_AllowPersonalizedAds = false;
        public static bool Privacy_AllowAppTracking = false;
        // This is only needed, if personal data are collected or ads are used
#if PRO
        public static bool Privacy_ConsentAppTrackingNeeded = false;
#else
        public static bool Privacy_ConsentAppTrackingNeeded = true;
#endif

#endregion

#region Localization
        public static string Localization_Default = "";  //en-US
#endregion

#region General
        public static bool General_UseDarkTheme = true;
        public static string Theme_PrimaryThemeColor = "";
        public static bool Theme_AutoTabletMode = true;
        public static bool Theme_EnableTabletModeManually = false;

        public static bool General_UseDeviceSettings = true;
        public static bool General_ShowPrintProgressInTitleView = true;
        public static bool General_ShowRemainingPrintTimeInTitleView = true;
        public static bool General_ShowOnlyWebCamInLandscape = true;
        public static bool General_DemoMode = false;
        public static bool General_RefreshOnAppearing = false;
        public static bool General_ShowWikiUris = true;
        public static bool General_ShowTitlesInBar = false;
        public static bool General_ShowPreviewImage = true;
        public static bool General_HideProgressBarInTopView = false;
        public static bool General_CollapseTopViewWhileNotPrinting = false;
        public static bool General_ExpandTopView = true;

        public static int General_GaugeHeight = 175;
        public static int General_GaugeHeightPrinting = 175;
        public static int General_MaxGaugeHeigh = 500;

        public static int General_GaugeHeightTablet = 300;
        public static int General_GaugeHeightPrintingTablet = 300;
        public static int General_MaxGaugeHeighTablet = 1000;
#endregion

#region Backup
        public static string Backup_FolderName = "Backups";
        public static bool Backup_FullBackup = true;
        public static bool Backup_Settings = true;
        public static bool Backup_EncryptBackupFile = true;
        public static int Backup_MinPasswordLength = 8;
#endregion

#region BackgroundMode
        public static bool BackgroundMode_Enabled = false;
        public static bool BackgroundMode_CloseAppIfIdle = false;
        public static int BackgroundMode_UpdateInterval = 100;
        public static int BackgroundMode_IdleDetectionThreshold = 5;
#endregion

#region Notifications
        public static bool Notification_NotifyOnNewMessage = false;
        public static bool Notification_NotifyOnPrintJobDone = true;
        public static bool Notification_NotifyOnWebSocketErrors = false;
        public static bool Notification_NotifyOnServerOffline = true;
        public static bool Notification_NotifyOnUpdateAvailable = true;
#endregion

#region Ads
        public static bool Ads_ShowPersonalizedAds = false;
        public static bool Ads_ShowBannerAdTop = false;
        public static int Ads_InterstitialAdCounter = 5;
#endregion

#region Demo Mode
        //public static OctoPrintConnectionStates DemoMode_ConnectionState = OctoPrintConnectionStates.Printing;
        public static bool DemoMode_SimulatePrint = true;
        public static bool DemoMode_HasDoubleExtruder = true;
        public static bool DemoMode_HasHeatedBed = true;
        public static bool DemoMode_HasHeatedChamber = true;
#endregion

#region RepetierServer
        public static bool RepetierServer_WebCamEnabeled = false;
        public static bool RepetierServer_EnableLogging = true;
        public static bool RepetierServer_EnableSecureConnection = false;
        public static bool RepetierServer_SaveSettingsOnServer = true;
        public static bool RepetierServer_ConnectOnStartup = true;
        public static bool RepetierServer_ShowEncryptionWarning = true;
        public static int RepetierServer_DefaultUpdateInterval = 2;
        public static int RepetierServer_MinUpdateInterval = 1;
        public static int RepetierServer_MaxUpdateInterval = 5;
        public static int RepetierServer_Port = 3344;
        public static bool RepetierServer_ShowLegalNote = true;
        public static int RepetierServer_TimeoutWebActions = 10000;
        public static int RepetierServer_TimerRestartCounter = 1;

        public static bool RepetierServer_Global_LoadModelImages = false;
        public static bool RepetierServer_Global_LoadModelImagesBackground = true;
        public static bool RepetierServer_Global_ReduceHeightOfFirstRowWhileScrolling = true;
        public static bool PrintServer_Global_UseFileCardTemplate = true;
        public static bool PrintServer_Global_UsePrinterCardTemplate = true;

        public static string PrintServer_AutoBedLevelingGcodeScript = "G29 // AutoBedLeveling; M400 // Wait till finished; M500 // Save to EEPROM;";
#endregion

#region WebCam
        public static int WebCam_NetworkBufferTime = 150;
        public static int WebCam_FileCachingTime = 1000;
        public static int WebCam_Rotation = 0;
        public static bool WebCam_AutoStart = true;
        public static bool WebCam_Enabled = false;
#endregion

#region Additional Functions
        public static bool PrintServer_Additional_EnableEmergencyStopButton = false;
        public static bool PrintServer_Additional_EnableSecurityQuestionForEmergencyStop = true;
#endregion

#region Scripts
        public static bool Scripts_ShowEditorWarning = true;
#endregion

#region Gcode
        public static string[] Gcode_ValidFileTypes = new string[] { ".gcode", ".gco" };
#endregion

#region PrinterControl
        public static double PrinterControl_SpeedMin = 50;
        public static double PrinterControl_SpeedMax = 200;

        public static double PrinterControl_FlowMin = 50;
        public static double PrinterControl_FlowMax = 200;

        public static double PrinterControl_FanSpeedMin = 50;
        public static double PrinterControl_FanSpeedMax = 200;

        public static double PrinterControl_ExtruderTempMin = 0;
        public static double PrinterControl_ExtruderTempMax = 300;

        public static double PrinterControl_HeadedbedTempMin = 0;
        public static double PrinterControl_HeatedbedTempMax = 120;

        public static double PrinterControl_HeadedChamberTempMin = 0;
        public static double PrinterControl_HeadedChamberTempMax = 80;
#endregion
    }
}
