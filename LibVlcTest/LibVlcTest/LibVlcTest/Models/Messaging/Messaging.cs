namespace RemoteControlRepetierServer.Models.Messaging
{
    public enum Messages
    {
        //App
        OnAppStarted,
        OnAppSleep,
        OnAppResume,
        OnConnectivityChanged,
        OnAuthErrorReceived,
        OnAuthErrorCleared,
        //AppShell
        OnServerSettingsChanged,
        OnCheckServerConnection,
        OnSettingsChanged,
        //Dependencies
        OnDemoModeChanged,
        OnRefreshData,
        OnRefreshSettings,
        OnRefreshPrintServerSettings,
        OnRefreshConnectionSettings,
        OnRefreshFiles,
        OnStartupStarted,
        OnStartupDone,
        OnStartupFailed,
        OnRestartTimer,
        OnServerOffline,
        OnServerNotConfigured,

        OnTimerStopped,
        OnTimerStarted,
        OnCurrentJobInfoChanged,
        OnPrinterStateChanged,
        OnFilesChanged,
        OnConnectionStatusChanged,
        OnPrintServerSettingsChanged,
        OnConnectionSettingsChanged,
        //Fitlers
        OnFilterChanged,

        //WebCam
        OnRestartWebCam,
        OnStopWebCam,

        //RepetierServer
        OnConnectionCheckStarted,
        OnConnectionCheckDone,
        OnWebSocketReconnect,
        OnWebSocketDisconnected,
        OnWebSocketConnected,
        OnWebSocketError,
        OnRepetierOnlineStateChanged,
        OnSelectedPrinterChanged,
        OnSelectedServerChanged,
        OnRefreshPrinterState,
        OnRefreshPrinter,
        OnRefreshServer,
        OnRefreshMessages,
        OnRefreshCurrentJobInfo,
        OnRefreshExternalCommands,
        OnRefreshWebCalls,
        
        OnJobsChanged,
        OnMessageReceived,
        OnMessagesChanged,
        OnSessionIdChanged,
        OnWebCallsChanged,
        OnRestApiCallErrorAppeared,
        OnRetryAfterErrorsCleared,
        OnErrorsCleared,

        OnPrinterSelectionPageClosed,
        OnServerSelectionPageClosed,
        OnServerSettingsPageClosed,
    }
}
