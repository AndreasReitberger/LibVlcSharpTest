using LibVlcTest.Resources.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace RemoteControlRepetierServer.Models.Localization
{
    #region Interface
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
    #endregion
    public class LocalizationManager
    {
        #region Static
        const string _defaultCultureCode = "en-US";

        //const string _baseFlagImageUri = @"pack://application:,,,/WpfFramework;component/Resources/Localization/Flags/";
        const string _baseFlagImageUri = @"";//"/Resources/Localization/Flags/";


        static LocalizationManager _instance = null;

        public static LocalizationManager GetInstance(string cultureCode = _defaultCultureCode)
        {
            if (_instance == null)
                _instance = new LocalizationManager(cultureCode);

            return _instance;
        }


        public static Uri GetImageUri(string cultureCode)
        {
            Uri image;
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    image = new Uri(_baseFlagImageUri + cultureCode.Replace("-", "_") + ".png", UriKind.RelativeOrAbsolute);
                    break;
                case Device.iOS:
                    image = new Uri(_baseFlagImageUri + cultureCode, UriKind.RelativeOrAbsolute);
                    break;
                default:
                    image = new Uri(_baseFlagImageUri + cultureCode + ".png", UriKind.RelativeOrAbsolute);
                    break;
            }
            return image;
        }


        public static List<LocalizationInfo> List => new List<LocalizationInfo>
        {
            new LocalizationInfo("English", "English", GetImageUri("en-US"), "Andreas", "en-US",100, true),
            new LocalizationInfo("German", "Deutsch",  GetImageUri("de-DE"), "Andreas", "de-DE",100, true),
            new LocalizationInfo("Russian", "русский",  GetImageUri("ru-RU"), "Alexander B.", "ru-RU",100, false),

        };

        public static LocalizationInfo GetLocalizationInfoBasedOnCode(string cultureCode)
        {
            return List.FirstOrDefault(x => x.Code == cultureCode) ?? null;
        }
        #endregion

        #region Properties

        public LocalizationInfo Current { get; set; } = new LocalizationInfo();

        public CultureInfo Culture { get; set; }

        #endregion

        #region Constructors
        LocalizationManager(string cultureCode = _defaultCultureCode)
        {
            if (string.IsNullOrEmpty(cultureCode))
                cultureCode = CultureInfo.CurrentCulture.Name;

            var info = GetLocalizationInfoBasedOnCode(cultureCode) ?? List.First();

            if (info.Code != List.First().Code)
            {
                Change(info);
            }
            else
            {
                Current = info;
                Culture = new CultureInfo(info.Code);
            }
        }
        #endregion

        #region Methods
        public void Change(LocalizationInfo info)
        {
            Current = info;

            Culture = new CultureInfo(info.Code);
        }
        public void ChangeOnTheFly(LocalizationInfo info)
        {
            Current = info;
            Culture = new CultureInfo(info.Code);
            DependencyService.Get<ILocalize>().SetLocale(Culture);
            Strings.Culture = Culture;
        }
        #endregion
    }
}
