using System.Diagnostics.CodeAnalysis;

namespace RemoteControlRepetierServer.Utilities
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class RegexHelper
    {
        public const string OctoPrintApiKey = @"([A-Z]|[0-9])*";

        // Repetier Server Pro API Key
        public const string RepetierServerProApiKey = @"((\w{8}-\w{4}-\w{4}-\w{4}-\w{12})|(.{8}-.{4}-.{4}-.{4}-.{12})|(.+-.+-.+-.+-.+))";
        public const string Fqdn = @"(?=^.{4,253}$)(^((?!-)[a-zA-Z0-9-]{1,63}(?<!-)\.)+[a-zA-Z]{2,63}$)";

        // Match IPv4-Address like 192.168.178.1
        const string IPv4AddressValues = @"(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])";
        public const string IPv4AddressRegex = "^" + IPv4AddressValues + "$";

        // Match IPv6-Address
        public const string IPv6AddressRegex = @"(?:^|(?<=\s))(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))(?=\s|$)";

        // Match IPv4-Address Range like 192.168.178.1-192.168.178.127
        public const string IPv4AddressRangeRegex = "^" + IPv4AddressValues + "-" + IPv4AddressValues + "$";

        // Match IPv4-Address within a string
        public const string IPv4AddressExctractRegex = @"\d{1,3}(\.\d{1,3}){3}";


        // Match a MAC-Address 000000000000 00:00:00:00:00:00, 00-00-00-00-00-00-00 or 0000.0000.0000
        public const string MACAddressRegex = @"^^[A-Fa-f0-9]{12}$|^[A-Fa-f0-9]{2}(:|-){1}[A-Fa-f0-9]{2}(:|-){1}[A-Fa-f0-9]{2}(:|-){1}[A-Fa-f0-9]{2}(:|-){1}[A-Fa-f0-9]{2}(:|-){1}[A-Fa-f0-9]{2}$|^[A-Fa-f0-9]{4}.[A-Fa-f0-9]{4}.[A-Fa-f0-9]{4}$$";

        // Matche the first 3 bytes of a MAC-Address 000000, 00:00:00, 00-00-00
        public const string MACAddressFirst3BytesRegex = @"^[A-Fa-f0-9]{6}$|^[A-Fa-f0-9]{2}(:|-){1}[A-Fa-f0-9]{2}(:|-){1}[A-Fa-f0-9]{2}$|^[A-Fa-f0-9]{4}.[A-Fa-f0-9]{2}$";


        // Match any filepath --> https://www.codeproject.com/Tips/216238/Regular-Expression-to-Validate-File-Path-and-Exten
        public const string FilePath = @"^(?:[\w]\:|\\)(\\[a-z_\-\s0-9\.]+)+\.[a-zA-z0-9]{1,4}$";

        public const string HtmlTags = @"<.*?>";

    }
}
