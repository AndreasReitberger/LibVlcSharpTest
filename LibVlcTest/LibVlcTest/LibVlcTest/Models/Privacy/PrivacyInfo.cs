
namespace RemoteControlRepetierServer.Models.Privacy
{
    public class PrivacyInfo
    {
        string _iconActive = "\U000f0134";
        string _iconInactive = "\U000f015a";
        
        public string Icon
        {
            get {
                return ServiceIsUsed ? _iconActive : _iconInactive;
            }
        }
        public bool ServiceIsUsed { get; set; }
        public bool IsThirdPartyHandled { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerOrCompany { get; set; }
        public string PrivacyPolicyUrl { get; set; }

        public PrivacyInfo(bool serviceIsUsed, bool isThirdPartyHandled, string name, string description, string owner, string privacyUri)
        {
            ServiceIsUsed = serviceIsUsed;
            IsThirdPartyHandled = isThirdPartyHandled;
            Name = name;
            Description = description;
            OwnerOrCompany = owner;
            PrivacyPolicyUrl = privacyUri;
        }
    }
}
