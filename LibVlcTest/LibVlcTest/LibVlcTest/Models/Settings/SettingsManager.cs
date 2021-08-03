using Newtonsoft.Json;
using RemoteControlRepetierServer.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Models.Settings
{
    public static class SettingsManager
    {
        #region Properties
        static bool _settingsChanged = false;
        public static bool SettingsChanged
        {
            get => _settingsChanged;
            set
            {
                if (_settingsChanged == value) return;
                _settingsChanged = value;
            }
        }
        #endregion

        #region DeviceSettings
        public static void OpenDeviceSettings()
        {
            AppInfo.ShowSettingsUI();
        }
        #endregion

        #region Settings

        #region General 
        public static bool Theme_UseDeviceDefaultSettings
        {
            get => Preferences.Get("theme_device_default_settings", SettingsStaticDefault.General_UseDeviceSettings);
            set => Preferences.Set("theme_device_default_settings", value);
        }
        public static bool Theme_UseDarkTheme
        {
            get => Preferences.Get("theme_darkmode", SettingsStaticDefault.General_UseDarkTheme);
            set => Preferences.Set("theme_darkmode", value);
        }
        public static string Theme_PrimaryThemeColor
        {
            get => Preferences.Get("theme_primary_theme_color", SettingsStaticDefault.Theme_PrimaryThemeColor);
            set => Preferences.Set("theme_primary_theme_color", value);
        }

        public static bool Theme_ShowPrintProgressInTitleView
        {
            get => Preferences.Get("theme_print_progress_in_titleview", SettingsStaticDefault.General_ShowPrintProgressInTitleView);
            set => Preferences.Set("theme_print_progress_in_titleview", value);
        }
        public static bool Theme_ShowRemainingPrintTimeInTitleView
        {
            get => Preferences.Get("theme_remaining_print_time_in_titleview", SettingsStaticDefault.General_ShowRemainingPrintTimeInTitleView);
            set => Preferences.Set("theme_remaining_print_time_in_titleview", value);
        }
        public static string Theme_AppEntryPoint
        {
            get => Preferences.Get("theme_app_entry_point", nameof(DashboardPage));
            set => Preferences.Set("theme_app_entry_point", value);
        }
        public static bool Theme_AutoTabletMode
        {
            get => Preferences.Get("theme_auto_tablet_mode", SettingsStaticDefault.Theme_AutoTabletMode);
            set => Preferences.Set("theme_auto_tablet_mode", value);
        }
        public static bool Theme_EnableTabletModeManually
        {
            get => Preferences.Get("theme_enable_tablet_mode_manually", SettingsStaticDefault.Theme_EnableTabletModeManually);
            set => Preferences.Set("theme_enable_tablet_mode_manually", value);
        }
        public static bool General_ShowOnlyWebCamInLandscape
        {
            get => Preferences.Get("general_show_only_webcam_landscape", SettingsStaticDefault.General_ShowOnlyWebCamInLandscape);
            set => Preferences.Set("general_show_only_webcam_landscape", value);
        }
        public static bool General_RefreshOnPageAppearing
        {
            get => Preferences.Get("general_refresh_on_appearing", SettingsStaticDefault.General_RefreshOnAppearing);
            set => Preferences.Set("general_refresh_on_appearing", value);
        }
        public static bool General_ShowWikiUris
        {
            get => Preferences.Get("general_show_wiki_uris", SettingsStaticDefault.General_ShowWikiUris);
            set => Preferences.Set("general_show_wiki_uris", value);
        }
        public static bool General_ShowTitlesInBar
        {
            get => Preferences.Get("general_show_title_in_bar", SettingsStaticDefault.General_ShowTitlesInBar);
            set => Preferences.Set("general_show_title_in_bar", value);
        }
        public static bool General_ShowPreviewImage
        {
            get => Preferences.Get("general_show_preview_image", SettingsStaticDefault.General_ShowPreviewImage);
            set => Preferences.Set("general_show_preview_image", value);
        }
        public static bool General_HideProgressBarInTopView
        {
            get => Preferences.Get("general_hide_progressbar_topview", SettingsStaticDefault.General_HideProgressBarInTopView);
            set => Preferences.Set("general_hide_progressbar_topview", value);
        }
        public static bool General_CollapseTopViewWhileNotPrinting
        {
            get => Preferences.Get("general_collapse_topview_while_not_printing", SettingsStaticDefault.General_CollapseTopViewWhileNotPrinting);
            set => Preferences.Set("general_collapse_topview_while_not_printing", value);
        }
        public static bool General_ExpandTopView
        {
            get => Preferences.Get("general_expand_top_view", SettingsStaticDefault.General_ExpandTopView);
            set => Preferences.Set("general_expand_top_view", value);
        }
        public static int General_GaugeHeight
        {
            get => Preferences.Get("general_gauge_height", Device.Idiom == TargetIdiom.Phone ? 
                SettingsStaticDefault.General_GaugeHeight : SettingsStaticDefault.General_GaugeHeightTablet);
            set => Preferences.Set("general_gauge_height", value);
        }
        public static int General_GaugeHeightPrinting
        {
            get => Preferences.Get("general_gauge_height_printing", Device.Idiom == TargetIdiom.Phone ? 
                SettingsStaticDefault.General_GaugeHeightPrinting : SettingsStaticDefault.General_GaugeHeightPrintingTablet);
            set => Preferences.Set("general_gauge_height_printing", value);
        }
        #endregion

        #region Privacy
        public static bool Privacy_ShowPrivacySettings
        {
            get => Preferences.Get("privacy_show_privacy_settings", SettingsStaticDefault.Privacy_ShowPrivacySettings);
            set => Preferences.Set("privacy_show_privacy_settings", value);
        }
        public static bool Privacy_AllowCrashAnalytics
        {
            get => Preferences.Get("privacy_allow_crash_analytics", SettingsStaticDefault.Privacy_AllowCrashAnalytics);
            set => Preferences.Set("privacy_allow_crash_analytics", value);
        }
        public static bool Privacy_AllowAnalyticsData
        {
            get => Preferences.Get("privacy_allow_analytics_data", SettingsStaticDefault.Privacy_AllowAnalyticsData);
            set => Preferences.Set("privacy_allow_analytics_data", value);
        }
        public static bool Privacy_AllowPersonalizedAds
        {
            get => Preferences.Get("privacy_allow_personalized_ads", SettingsStaticDefault.Privacy_AllowPersonalizedAds);
            set => Preferences.Set("privacy_allow_personalized_ads", value);
        }
        public static bool Privacy_AllowAppTracking
        {
            get => Preferences.Get("privacy_allow_app_tracking", SettingsStaticDefault.Privacy_AllowAppTracking);
            set => Preferences.Set("privacy_allow_app_tracking", value);
        }
        #endregion

        #region BackgroundMode
        public static bool BackgroundMode_Enabled
        {
            get => Preferences.Get("backgroundmode_enabled", SettingsStaticDefault.BackgroundMode_Enabled);
            set => Preferences.Set("backgroundmode_enabled", value);
        }
        public static bool BackgroundMode_CloseAppIfIdle
        {
            get => Preferences.Get("backgroundmode_close_app_if_idle", SettingsStaticDefault.BackgroundMode_Enabled);
            set => Preferences.Set("backgroundmode_close_app_if_idle", value);
        }
        public static int BackgroundMode_UpdateInterval
        {
            get => Preferences.Get("backgroundmode_update_interval", SettingsStaticDefault.BackgroundMode_UpdateInterval);
            set => Preferences.Set("backgroundmode_update_interval", value);
        }
        public static int BackgroundMode_IdleDetectionThreshold
        {
            get => Preferences.Get("backgroundmode_idle_detection_threshold", SettingsStaticDefault.BackgroundMode_IdleDetectionThreshold);
            set => Preferences.Set("backgroundmode_idle_detection_threshold", value);
        }
        #endregion

        #region Backup
        public static bool Backup_FullBackup
        {
            get => Preferences.Get("backup_full", SettingsStaticDefault.Backup_FullBackup);
            set => Preferences.Set("backup_full", value);
        }
        public static bool Backup_Settings
        {
            get => Preferences.Get("backup_settings", SettingsStaticDefault.Backup_Settings);
            set => Preferences.Set("backup_settings", value);
        }
        public static bool Backup_EncryptBackupFile
        {
            get => Preferences.Get("backup_encrypt_file", SettingsStaticDefault.Backup_EncryptBackupFile);
            set => Preferences.Set("backup_encrypt_file", value);
        }
        public static DateTime Backup_LastBackup
        {
            get => Preferences.Get("backup_last_backup", DateTime.MinValue);
            set => Preferences.Set("backup_last_backup", value);
        }
        #endregion

        #region Ads        
        public static int Ads_InterstitialCounter
        {
            get => Preferences.Get("ads_interstitial_counter", SettingsStaticDefault.Ads_InterstitialAdCounter);
            set => Preferences.Set("ads_interstitial_counter", value);
        }

        public static bool Ads_AskForPersonalizedAds
        {
            get => Preferences.Get("ads_ask_for_personalized_ads", true);
            set => Preferences.Set("ads_ask_for_personalized_ads", value);
        }

        /*
        public static bool Ads_ShowPersonalizedAds
        {
            get => Preferences.Get("ads_show_personalized_ads", SettingsStaticDefault.Ads_ShowPersonalizedAds);
            set => Preferences.Set("ads_show_personalized_ads", value);
        }
        */

        public static bool Ads_ShowBannerAdTop
        {
            get => Preferences.Get("ads_show_banner_ad_top", SettingsStaticDefault.Ads_ShowBannerAdTop);
            set => Preferences.Set("ads_show_banner_ad_top", value);
        }
        #endregion

        #region Notifications
        public static bool Notification_NotifyOnNewMessage
        {
            get => Preferences.Get("notification_notify_on_new_message", SettingsStaticDefault.Notification_NotifyOnNewMessage);
            set => Preferences.Set("notification_notify_on_new_message", value);
        }
        public static bool Notification_NotifyOnPrintJobDone
        {
            get => Preferences.Get("notification_notify_on_printjob_done", SettingsStaticDefault.Notification_NotifyOnPrintJobDone);
            set => Preferences.Set("notification_notify_on_printjob_done", value);         
        }
        public static bool Notification_NotifyOnWebSocketErrors
        {
            get => Preferences.Get("notification_notify_on_websocket_error", SettingsStaticDefault.Notification_NotifyOnWebSocketErrors);
            set => Preferences.Set("notification_notify_on_websocket_error", value);
        }
        public static bool Notification_NotifyOnServerOffline
        {
            get => Preferences.Get("notification_notify_on_server_offline", SettingsStaticDefault.Notification_NotifyOnServerOffline);
            set => Preferences.Set("notification_notify_on_server_offline", value);
        }
        public static bool Notification_NotifyOnUpdateAvailable
        {
            get => Preferences.Get("notification_notify_on_update_available", SettingsStaticDefault.Notification_NotifyOnUpdateAvailable);
            set => Preferences.Set("notification_notify_on_update_available", value);
        }
        #endregion

        #region Demo Mode
        public static bool Demo_Mode
        {
            get => Preferences.Get("demo_mode", SettingsStaticDefault.General_DemoMode);
            set => Preferences.Set("demo_mode", value);
        }

        public static bool Demo_Mode_SimulatePrint
        {
            get => Preferences.Get("demo_mode_simulate_print", SettingsStaticDefault.DemoMode_SimulatePrint);
            set => Preferences.Set("demo_mode_simulate_print", value);
        }
        public static bool Demo_Mode_HasDoubleExtruder
        {
            get => Preferences.Get("demo_mode_has_doubleExtruder", SettingsStaticDefault.DemoMode_HasDoubleExtruder);
            set => Preferences.Set("demo_mode_has_doubleExtruder", value);
        }
        public static bool Demo_Mode_HasHeatedBed
        {
            get => Preferences.Get("demo_mode_has_heatedBed", SettingsStaticDefault.DemoMode_HasHeatedBed);
            set => Preferences.Set("demo_mode_has_heatedBed", value);
        }
        public static bool Demo_Mode_HasHeatedChamber
        {
            get => Preferences.Get("demo_mode_has_heatedChamber", SettingsStaticDefault.DemoMode_HasHeatedChamber);
            set => Preferences.Set("demo_mode_has_heatedChamber", value);
        }
        #endregion

        #region Localization
        public static string Localization_CultureCode
        {
            get => Preferences.Get("localization_culture_code", SettingsStaticDefault.Localization_Default);
            set => Preferences.Set("localization_culture_code", value);

        }
        #endregion

        #region PrintServer

        #region Connection
        /*
        public static string PrintServer_Address
        {
            get => Preferences.Get("printserver_address", "");
            set => Preferences.Set("printserver_address", value);        
        }
        public static int PrintServer_Port
        {
            get => Preferences.Get("printserver_port", SettingsStaticDefault.RepetierServer_Port);
            set => Preferences.Set("printserver_port", value);           
        }
        public static string PrintServer_API
        {
            get => Preferences.Get("printserver_api", "");
            set => Preferences.Set("printserver_api", value);
        }
        public static bool PrintServer_EnableSecureConnection
        {
            get => Preferences.Get("printserver_ssl", SettingsStaticDefault.RepetierServer_EnableSecureConnection);
            set => Preferences.Set("printserver_ssl", value);
        }
        public static bool PrintServer_SaveSettingsOnServer
        {
            get => Preferences.Get("printserver_save_settings_serverside", SettingsStaticDefault.RepetierServer_SaveSettingsOnServer);
            set => Preferences.Set("printserver_save_settings_serverside", value);
        }
        public static bool PrintServer_AutoConnectOnStartup
        {
            get => Preferences.Get("printserver_autoconnect", SettingsStaticDefault.RepetierServer_ConnectOnStartup);
            set =>Preferences.Set("printserver_autoconnect", value);
        }
        */
        public static string PrintServer_LastUsedPrinterProfile
        {
            get => Preferences.Get("printserver_last_printerprofile", "");
            set => Preferences.Set("printserver_last_printerprofile", value);
        }
        public static bool PrintServer_EnableLogging
        {
            get => Preferences.Get("printserver_logging", SettingsStaticDefault.RepetierServer_EnableLogging);
            set => Preferences.Set("printserver_logging", value);
        }  
        public static bool PrintServer_ShowEncryptionWarning
        {
            get => Preferences.Get("printserver_show_encryption_warning", SettingsStaticDefault.RepetierServer_ShowEncryptionWarning);
            set => Preferences.Set("printserver_show_encryption_warning", value);
        }
        public static int PrintServer_UpdateInterval
        {
            get => Preferences.Get("printserver_update_interval", SettingsStaticDefault.RepetierServer_DefaultUpdateInterval);
            set => Preferences.Set("printserver_update_interval", value);
        }
        #endregion

        #region General
     
        public static bool RepetierServer_WebCamEnabeled
        {
            get => Preferences.Get("printserver_webcam", SettingsStaticDefault.RepetierServer_WebCamEnabeled);
            set => Preferences.Set("printserver_webcam", value);
        }
        public static int PrintServer_TimeoutWebActions
        {
            get => Preferences.Get("printserver_timeout_webactions", SettingsStaticDefault.RepetierServer_TimeoutWebActions);
            set => Preferences.Set("printserver_timeout_webactions", value);
        }
        public static bool RepetierServerPro_ShowLegalNote
        {
            get => Preferences.Get("repetier_show_legal_note", SettingsStaticDefault.RepetierServer_ShowLegalNote);
            set =>Preferences.Set("repetier_show_legal_note", value);
        }
        #endregion

        #region Global
        public static bool PrintServer_Global_LoadModelImages
        {
            get => Preferences.Get("repetier_global_load_model_images", SettingsStaticDefault.RepetierServer_Global_LoadModelImages);
            set => Preferences.Set("repetier_global_load_model_images", value);
        }
        public static bool PrintServer_Global_LoadModelImagesInBackground
        {
            get => Preferences.Get("repetier_global_load_model_images_background", SettingsStaticDefault.RepetierServer_Global_LoadModelImagesBackground);
            set => Preferences.Set("repetier_global_load_model_images_background", value);
        }
        public static bool PrintServer_Global_ReduceHeightOfFirstRowWhileScrolling
        {
            get => Preferences.Get("repetier_global_reduce_height_first_row_scrolling", SettingsStaticDefault.RepetierServer_Global_ReduceHeightOfFirstRowWhileScrolling);
            set => Preferences.Set("repetier_global_reduce_height_first_row_scrolling", value);
        }
        public static bool PrintServer_Global_UseFileCardTemplate
        {
            get => Preferences.Get("repetier_global_use_file_card_template", SettingsStaticDefault.PrintServer_Global_UseFileCardTemplate);
            set => Preferences.Set("repetier_global_use_file_card_template", value);
        }
        public static bool PrintServer_Global_UsePrinterCardTemplate
        {
            get => Preferences.Get("repetier_global_use_printer_card_template", SettingsStaticDefault.PrintServer_Global_UsePrinterCardTemplate);
            set => Preferences.Set("repetier_global_use_printer_card_template", value);
        }
        #endregion

        #region GcodeScripts
        public static string PrintServer_AutoBedLevelingGcodeScript
        {
            get => Preferences.Get("printserver_script_autobedleveling", SettingsStaticDefault.PrintServer_AutoBedLevelingGcodeScript);
            set => Preferences.Set("printserver_script_autobedleveling", value);
        }
        #endregion

        #region Servers
        public static Guid PrintServer_LastUsedServer
        {
            get
            {
                var id =Preferences.Get("printserver_last_used_server", Guid.Empty.ToString());
                Guid guid = Guid.Empty;
                Guid.TryParse(id, out guid);
                return guid;
            }
            set => Preferences.Set("printserver_last_used_server", value.ToString());
        }
        #endregion

        #endregion

        #region WebCam
        public static int WebCam_NetworkBufferTime
        {
            get => Preferences.Get("webcam_networkbuffertime", SettingsStaticDefault.WebCam_NetworkBufferTime);
            set => Preferences.Set("webcam_networkbuffertime", value);
        }
        public static int WebCam_FileCachingTime
        {
            get => Preferences.Get("webcam_filecachingtime", SettingsStaticDefault.WebCam_FileCachingTime);
            set => Preferences.Set("webcam_filecachingtime", value);
        }
        public static int WebCam_Rotation
        {
            get => Preferences.Get("webcam_rotation", SettingsStaticDefault.WebCam_Rotation);
            set => Preferences.Set("webcam_rotation", value);
        }

        public static bool WebCam_AutoStart
        {
            get => Preferences.Get("webcam_autostart", SettingsStaticDefault.WebCam_AutoStart);
            set => Preferences.Set("webcam_autostart", value);
        }
        
        #endregion

        #region Printer Control
        public static double PrinterControl_SpeedMin
        {
            get => Preferences.Get("printercontrol_speed_min", SettingsStaticDefault.PrinterControl_SpeedMin);
            set => Preferences.Set("printercontrol_speed_min", value);
        }
        public static double PrinterControl_SpeedMax
        {
            get => Preferences.Get("printercontrol_speed_max", SettingsStaticDefault.PrinterControl_SpeedMax);
            set => Preferences.Set("printercontrol_speed_max", value);
        }

        public static double PrinterControl_FlowMin
        {
            get => Preferences.Get("printercontrol_flow_min", SettingsStaticDefault.PrinterControl_FlowMin);
            set => Preferences.Set("printercontrol_flow_min", value);
        }
        public static double PrinterControl_FlowMax
        {
            get => Preferences.Get("printercontrol_flow_max", SettingsStaticDefault.PrinterControl_FlowMax);
            set => Preferences.Set("printercontrol_flow_max", value);
        }

        public static double PrinterControl_ExtruderTempMin
        {
            get => Preferences.Get("printercontrol_extruder_temp_min", SettingsStaticDefault.PrinterControl_ExtruderTempMin);
            set => Preferences.Set("printercontrol_extruder_temp_min", value);
        }
        public static double PrinterControl_ExtruderTempMax
        {
            get => Preferences.Get("printercontrol_extruder_temp_max", SettingsStaticDefault.PrinterControl_ExtruderTempMax);
            set => Preferences.Set("printercontrol_extruder_temp_max", value);
        }

        public static double PrinterControl_HeatedBedTempMin
        {
            get => Preferences.Get("printercontrol_heatedbed_temp_min", SettingsStaticDefault.PrinterControl_HeadedbedTempMin);
            set => Preferences.Set("printercontrol_heatedbed_temp_min", value);
        }
        public static double PrinterControl_HeatedBedTempMax
        {
            get => Preferences.Get("printercontrol_heatedbed_temp_max", SettingsStaticDefault.PrinterControl_HeatedbedTempMax);
            set => Preferences.Set("printercontrol_heatedbed_temp_max", value);
        }
        public static double PrinterControl_HeatedChamberTempMin
        {
            get => Preferences.Get("printercontrol_heatedchamber_temp_min", SettingsStaticDefault.PrinterControl_HeadedChamberTempMin);
            set => Preferences.Set("printercontrol_heatedchamber_temp_min", value);
        }
        public static double PrinterControl_HeatedChamberTempMax
        {
            get => Preferences.Get("printercontrol_heatedchamber_temp_max", SettingsStaticDefault.PrinterControl_HeadedChamberTempMax);
            set => Preferences.Set("printercontrol_heatedchamber_temp_max", value);
        }
        #endregion

        #region Additional Functions
        public static bool PrintServer_Additional_EnableEmergencyStopButton
        {
            get => Preferences.Get("print_server_additional_enable_emergency_stop_button", SettingsStaticDefault.PrintServer_Additional_EnableEmergencyStopButton);
            set => Preferences.Set("print_server_additional_enable_emergency_stop_button", value);
        }
        public static bool PrintServer_Additional_EnableSecurityQuestionForEmergencyStop
        {
            get => Preferences.Get("print_server_additional_enable__security_question_emergency_stop_button", SettingsStaticDefault.PrintServer_Additional_EnableSecurityQuestionForEmergencyStop);
            set => Preferences.Set("print_server_additional_enable__security_question_emergency_stop_button", value);
        }
        #endregion

        #region Scripts
        public static bool Scripts_ShowEditorWarning
        {
            get => Preferences.Get("scripts_show_editor_warning", SettingsStaticDefault.Scripts_ShowEditorWarning);
            set => Preferences.Set("scripts_show_editor_warning", value);
        }
        #endregion

        #endregion

        #region Methods
        public static void Clear()
        {
            Preferences.Clear();
            //AppSettings.Clear();
            SecureStorage.RemoveAll();
        }
        #endregion
    }
}
