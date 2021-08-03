using LibVlcTest.Resources.Localization;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Models.Documentation
{
    public static class ProVersionManager
    {
        #region ProLinks
        // For rating
        //static string _proVersionIos = "itms-apps://apple.com/app/id1536269882?action=write-review";
        static string _proVersionIos = "https://apps.apple.com/us/app/id1535367064"; //"itms-apps://apple.com/app/id1518476783";
        static string _proVersionAndroid = "https://play.google.com/store/apps/details?id=com.andreasreitberger.repservapppro";

        public static string ProVersionLink
        {
            get
            {
                return Device.RuntimePlatform == "iOS" ? _proVersionIos : _proVersionAndroid;
            }
        }
        #endregion

        #region List
        public static List<ProVersionFeature> List => new List<ProVersionFeature>
        {
            new ProVersionFeature() { Feature = Strings.ProVersionFeatureNoAds},
            new ProVersionFeature() { Feature = Strings.ProVersionAccessYourProjects},
            new ProVersionFeature() { Feature = Strings.ProVersionSingleControlPanel},

            new ProVersionFeature() { Feature = Strings.ProVersionFeatureAndManyMoreDots},

        };
        #endregion

    }
}
