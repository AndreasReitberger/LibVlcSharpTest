using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControlRepetierServer.Models.Privacy
{
    public static class PrivacyManager
    {
        public static List<PrivacyInfo> List => new List<PrivacyInfo>
        {
           new PrivacyInfo(false, true, "Apple CloudKit", "A service to store data at your iCloud drive.", "Apple Inc.", $"https://developer.apple.com/icloud/cloudkit/"),
           new PrivacyInfo(false, true, "Google Firebase", "An analytics software to track the behavior in apps or games.", "Google Inc.", $"https://firebase.google.com/support/privacy"),
           new PrivacyInfo(false, true, "Google AdMob", "An ad provider for mobile apps.", "Google Inc.", $""),
           //new PrivacyInfo(true, true, "Test", "An ad provider for mobile apps.", "Google Inc.", $""),
        };
    }
}
