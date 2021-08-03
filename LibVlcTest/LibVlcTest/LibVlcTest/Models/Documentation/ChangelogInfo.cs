using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControlRepetierServer.Models.Documentation
{
    public class ChangelogInfo
    {
        #region Properties
        public ChangelogType Type { get; set; }
        public string Changelog { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string GlyphIcon { get; set; } = string.Empty;
        #endregion

        #region Constructor
        public ChangelogInfo(string version, string changelog, ChangelogType type = ChangelogType.New)
        {
            Version = version;
            Changelog = changelog;
            Type = type;
        }
        #endregion
    }

    public enum ChangelogType
    {
        BugFix,
        New,
        Changed,
        Updated,
    }
}
