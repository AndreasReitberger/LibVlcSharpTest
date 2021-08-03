using System.Collections.Generic;
using System.Linq;

namespace RemoteControlRepetierServer.Models.Documentation
{
    public static class ChangelogManager
    {
        public const string ChangelogBaseUrl = @"https://andreas-reitberger.de/en/apps/remote-control-repetier-server-pro/rc-repetier-changelog/";

        public static List<ChangelogInfo> List => new List<ChangelogInfo>
        {
            // 1.0.2
            new ChangelogInfo("1.0.2", "Unit price added to calculation result", ChangelogType.Changed),
            new ChangelogInfo("1.0.2", "German localization updated", ChangelogType.Updated),
            new ChangelogInfo("1.0.2", "Minor changes to design", ChangelogType.Updated),
            new ChangelogInfo("1.0.2", "Cumulative prices are now displayed at selection", ChangelogType.New),
            new ChangelogInfo("1.0.2", "Service and repair logbook added", ChangelogType.New), 
            // 1.0.3
            new ChangelogInfo("1.0.3", "Fixed crash when sending app in background", ChangelogType.BugFix), 
            new ChangelogInfo("1.0.3", "Keyboard overlapped entry boxes", ChangelogType.BugFix), 
            new ChangelogInfo("1.0.3", "Function to collapse and expand file groups", ChangelogType.New), 
            new ChangelogInfo("1.0.3", "Option to rotate webcam view", ChangelogType.New), 
            new ChangelogInfo("1.0.3", "Page for calling web actions added", ChangelogType.New), 
            new ChangelogInfo("1.0.3", "Improved landscape mode", ChangelogType.Updated), 
            new ChangelogInfo("1.0.3", "Webcam blacked out when returning to the Dashboard", ChangelogType.Updated), 

            // 1.0.4
            new ChangelogInfo("1.0.4", "Fixed crash when switching back to dashboard (quick fix)", ChangelogType.BugFix),

            // 1.0.5
            new ChangelogInfo("1.0.5", "Multi server support added", ChangelogType.New),
            new ChangelogInfo("1.0.5", "Printer overview added to dashboard", ChangelogType.New),
            new ChangelogInfo("1.0.5", "Option to filter model groups", ChangelogType.New),
            new ChangelogInfo("1.0.5", "Option switch webcam", ChangelogType.New),
            new ChangelogInfo("1.0.5", "Option to hide progress bar in top view", ChangelogType.New),
            new ChangelogInfo("1.0.5", "Added printer history", ChangelogType.New),
            new ChangelogInfo("1.0.5", "Fixed error on starting web actions", ChangelogType.BugFix),
            new ChangelogInfo("1.0.5", "Fixed error keeping webacm from starting after resuming app", ChangelogType.BugFix),
            new ChangelogInfo("1.0.5", "Print image was not updated when switching printer", ChangelogType.BugFix),

            // 1.0.7
            new ChangelogInfo("1.0.7", "Real fullscreen mode for webcam", ChangelogType.New),
            new ChangelogInfo("1.0.7", "Added project page (pro only)", ChangelogType.New),
            new ChangelogInfo("1.0.7", "Print image was not loaded when the print was already active before the app had started", ChangelogType.BugFix),
            new ChangelogInfo("1.0.7", "Moving axes did not work as expected", ChangelogType.BugFix),
            new ChangelogInfo("1.0.7", "Percentage label moved outside of progress circle", ChangelogType.Updated),

            // 1.0.8
            new ChangelogInfo("1.0.8", "Fixed timer stopped during connection loss", ChangelogType.BugFix),
            new ChangelogInfo("1.0.8", "Button to restart timer from the dashboard", ChangelogType.New),
            new ChangelogInfo("1.0.8", "Improved event manager", ChangelogType.Updated),
            
            // 1.0.9
            new ChangelogInfo("1.0.9", "Minor bug fixes from 1.0.8", ChangelogType.BugFix),
            new ChangelogInfo("1.0.9", "German translation updated", ChangelogType.Updated),
            new ChangelogInfo("1.0.9", "Wifi off detection improved", ChangelogType.Updated),

            // 1.0.10
            new ChangelogInfo("1.0.10", "Local notifications implemented", ChangelogType.New),
            new ChangelogInfo("1.0.10", "Improved websocket communication", ChangelogType.Updated),
            new ChangelogInfo("1.0.10", "Updated all dependencies", ChangelogType.Updated),

            // 1.0.11
            new ChangelogInfo("1.0.11", "App crashes when sent to background (caused by new theme switching function)", ChangelogType.BugFix),
            new ChangelogInfo("1.0.11", "Removed 'location' from iOS info.plist", ChangelogType.BugFix),

            // 1.0.12
            new ChangelogInfo("1.0.12", "App could not detect if device is 'Phone' or 'Tablet' on some devices", ChangelogType.BugFix),

            // 1.0.13
            new ChangelogInfo("1.0.13", "Updated Xamarin.Forms to latest version", ChangelogType.BugFix),
            new ChangelogInfo("1.0.13", "Updated 'Pause' and 'Stop' button while printing", ChangelogType.Updated),
            new ChangelogInfo("1.0.13", "Changed regex schema for api key verification", ChangelogType.Updated),

            // 1.0.14
            new ChangelogInfo("1.0.14", "Updated Xamarin.Forms to latest version", ChangelogType.Updated),
            new ChangelogInfo("1.0.14", "Updated Syncfusion packages to latest version", ChangelogType.Updated),
            new ChangelogInfo("1.0.14", "Fullscreen button was overlapped by an invisible control", ChangelogType.BugFix),
            new ChangelogInfo("1.0.14", "Replaced icon for collapsing pause and stop button", ChangelogType.Changed),
            new ChangelogInfo("1.0.14", "Button to turn on webcam was made clearer", ChangelogType.Changed),

            // 1.0.15
            new ChangelogInfo("1.0.15", "Fullscreen button for WebCam was not working while printing", ChangelogType.BugFix),

            // 1.0.16
            new ChangelogInfo("1.0.16", "Server communication improved", ChangelogType.BugFix),
            new ChangelogInfo("1.0.16", "Overall performance improved", ChangelogType.BugFix),
            new ChangelogInfo("1.0.16", "Slow switching from printers have been solved", ChangelogType.BugFix),
            new ChangelogInfo("1.0.16", "Openening error page leaded to a crash", ChangelogType.BugFix),
            new ChangelogInfo("1.0.16", "Introducing new single page control panel (Pro only for now)", ChangelogType.New),
            new ChangelogInfo("1.0.16", "Introducing new event manager showing background information from the app", ChangelogType.New),
            new ChangelogInfo("1.0.16", "QR code button removed till Repetier Server shows a QR code for the api key", ChangelogType.Changed),
            new ChangelogInfo("1.0.16", "Cleaned code behind and removed unneeded stuff", ChangelogType.Changed),
            new ChangelogInfo("1.0.16", "Select printer / server page could not be refreshed if the list was empty", ChangelogType.Changed),
            new ChangelogInfo("1.0.16", "All dependencies updated", ChangelogType.Updated),
            new ChangelogInfo("1.0.16", "German translation updated", ChangelogType.Updated),

            // 1.0.17
            new ChangelogInfo("1.0.17", "ShellNavigationManager blocked UI thread", ChangelogType.BugFix),
            new ChangelogInfo("1.0.17", "Fixed hanging on page refreshing (caused by webcam view)", ChangelogType.BugFix),
            new ChangelogInfo("1.0.17", "App checked server connection on any network change, now only when wifi is turned off", ChangelogType.BugFix),
            new ChangelogInfo("1.0.17", "WebCam funcions improved / optimized", ChangelogType.Updated),
            new ChangelogInfo("1.0.17", "Added 'printer is offline' warning on new control panel page", ChangelogType.Updated),
            new ChangelogInfo("1.0.17", "Added current layer in current print overview", ChangelogType.New),
            
            // 1.0.18
            new ChangelogInfo("1.0.18", "Starting from a fresh installation no printer selection was shown", ChangelogType.BugFix),
            new ChangelogInfo("1.0.18", "Last used printer slug was set before checking online status", ChangelogType.BugFix),
            new ChangelogInfo("1.0.18", "Reduced XAML treeviews and removed not needed styles", ChangelogType.Updated),
            new ChangelogInfo("1.0.18", "Improved loading times on each page", ChangelogType.Updated),

            // 1.0.19
            new ChangelogInfo("1.0.19", "WebCam does not start automatically when activated", ChangelogType.BugFix),
            new ChangelogInfo("1.0.19", "WebCam does not work on some devices", ChangelogType.BugFix),
            new ChangelogInfo("1.0.19", "Switching from demo mode to live mode did not always work", ChangelogType.BugFix),
            new ChangelogInfo("1.0.19", "'About Pro Version' page crashed the app", ChangelogType.BugFix),
            new ChangelogInfo("1.0.19", "Removed inactive nugets from the proejct", ChangelogType.Changed),
            new ChangelogInfo("1.0.19", "Added options to add individual settings for webcams", ChangelogType.New),

            // 1.0.20
            new ChangelogInfo("1.0.20", "App stuck at splash on some devices", ChangelogType.BugFix),
            new ChangelogInfo("1.0.20", "App crashes if printer config was changed remotely", ChangelogType.BugFix),
            new ChangelogInfo("1.0.20", "Control panel showed static temp for heating chamber", ChangelogType.BugFix),
            new ChangelogInfo("1.0.20", "Control panel didn't show the heated bed when a heating chamber was available", ChangelogType.BugFix),
            new ChangelogInfo("1.0.20", "After connection loss the app returned always to the dashboard", ChangelogType.BugFix),
            
            // 1.0.21
            new ChangelogInfo("1.0.21", "App stuck at splash on some devices (hopefully fixed)", ChangelogType.BugFix),
            new ChangelogInfo("1.0.21", "Button to expand / collapse top view", ChangelogType.New),

            // 1.0.22
            new ChangelogInfo("1.0.22", "App stuck at splash on some devices (hopefully fixed)", ChangelogType.BugFix),
            new ChangelogInfo("1.0.22", "Added russian translation", ChangelogType.New),

            // 1.1.0
            new ChangelogInfo("1.1.0", "Sometimes the WebCam doesn't started on startup", ChangelogType.BugFix),
            new ChangelogInfo("1.1.0", "Improved sliding for ListViewItems", ChangelogType.Updated),
            new ChangelogInfo("1.1.0", "Improved russian translation", ChangelogType.Updated),
            new ChangelogInfo("1.1.0", "Added Microsoft AppCenter to get crash data", ChangelogType.New),
            new ChangelogInfo("1.1.0", "Added additional print server settings", ChangelogType.New),
            new ChangelogInfo("1.1.0", "Added option to show/hide emergency stop button", ChangelogType.New),

            // 1.1.1
            new ChangelogInfo("1.1.1", "Display issues when two or more printers were active", ChangelogType.BugFix),
            new ChangelogInfo("1.1.1", "WebCam settings couldn't be saved if the index was higher as 0", ChangelogType.BugFix),
            new ChangelogInfo("1.1.1", "Model filter didn't work at the dashboard and control panel page", ChangelogType.BugFix),
            new ChangelogInfo("1.1.1", "Minor bug fixes and adjustments", ChangelogType.BugFix),

            // 1.1.2
            new ChangelogInfo("1.1.2", "Fixed not working webcam settings page", ChangelogType.BugFix),

            // 1.1.3
            new ChangelogInfo("1.1.3", "Backup & restore function (settings) added", ChangelogType.New),
            new ChangelogInfo("1.1.3", "Notifiaction for server updates", ChangelogType.New),
            new ChangelogInfo("1.1.3", "New page for your server details and updates", ChangelogType.New),
            new ChangelogInfo("1.1.3", "Switched to modal pages", ChangelogType.New),
            new ChangelogInfo("1.1.3", "Reverse proxies can now be used with the app", ChangelogType.Updated),
            new ChangelogInfo("1.1.3", "Updated third party libraries", ChangelogType.Updated),
            new ChangelogInfo("1.1.3", "Connection using SSL was not possible", ChangelogType.BugFix),
            new ChangelogInfo("1.1.3", "Websocket did not connect when using SSL", ChangelogType.BugFix),

            // 1.1.4
            new ChangelogInfo("1.1.4", "Print progess notification switched between printing and not printing during print", ChangelogType.BugFix),
            new ChangelogInfo("1.1.4", "Added 'Stop' button to stop background mode", ChangelogType.New),
            new ChangelogInfo("1.1.4", "Added settings to adjust background mode", ChangelogType.New),

            // 1.1.6
            new ChangelogInfo("1.1.6", "Improved offline detection / restart after connection loss", ChangelogType.Updated),
            new ChangelogInfo("1.1.6", "MessagingCenter replaced by events", ChangelogType.Updated),
            new ChangelogInfo("1.1.6", "Online check interval reduced", ChangelogType.Updated),
            new ChangelogInfo("1.1.6", "Library for Repetier Server REST-API cleaned and improved", ChangelogType.Updated),
            new ChangelogInfo("1.1.6", "Background work of the app reduced or optimized", ChangelogType.Updated),
            new ChangelogInfo("1.1.6", "Tablet optimization", ChangelogType.Updated),
            new ChangelogInfo("1.1.6", "Russian translation updated", ChangelogType.Updated),
            new ChangelogInfo("1.1.6", "Preparations for Apple Watch integration", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Print jobs added to history", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Print reports can now be exported (pdf)", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Possibility to change the server in the flyout", ChangelogType.New),
            new ChangelogInfo("1.1.6", "The selected server is now displayed on the “Offline” page (at startup)", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Background worker for notifications and Apple Watch", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Card view for files / printers (can be selected in the settings)", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Option to choose theme color", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Option to set the start page of the app", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Option to switch the tablet mode", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Server status and license can now be displayed in the app", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Checking for server updates in the app is now possible", ChangelogType.New),
            new ChangelogInfo("1.1.6", "Long loading time when opening a model (large view)", ChangelogType.BugFix),
            new ChangelogInfo("1.1.6", "With the new background worker, push notifications can also be sent in the background", ChangelogType.BugFix),
            new ChangelogInfo("1.1.6", "Corrected gray levels for light / dark theme", ChangelogType.BugFix),
            new ChangelogInfo("1.1.6", "When changing the server on the 'Printer' page, the online status was not queried", ChangelogType.BugFix),

        };

        public static List<ChangelogInfo> GetChangelogsForVersion(string version)
        {
            var list = List.Where(x => x.Version == version).ToList();
            return list;
        }

        public static List<string> GetAllVersions()
        {
            var list = List.Select(changelog => changelog.Version).Distinct().ToList();
            return list;
        }
    }
}
