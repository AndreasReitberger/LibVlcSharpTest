using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteControlRepetierServer.Models.Documentation
{

    public static class DocumentationManager
    {
        public const string DocumentationBaseUrl = @"https://andreas-reitberger.de/en/docs/remote-control-fuer-repetier-server-app/";
        public const string ChangelogBaseUrl = @"https://andreas-reitberger.de/apps/remote-control-repetier-server-pro/rc-repetier-changelog/";
        public const string ProjectUrl = @"https://github.com/AndreasReitberger/RemoteControlRepetierServerProApp";

        public const string ProjectSubmitBugUrl = @"https://github.com/AndreasReitberger/RemoteControlRepetierServerProApp/issues/new?assignees=&labels=&template=bug_report.md&title=";
        public const string ProjectSubmitFeatureUrl = @"https://github.com/AndreasReitberger/RemoteControlRepetierServerProApp/issues/new?assignees=AndreasReitberger&labels=enhancement&template=feature_request.md&title=%5BFeatureRequest%5D";
        
        public const string FacebookUrl = @"https://www.facebook.com/andreas.reitberger.kleinunternehmen";
        public const string InstagramUrl = @"https://www.instagram.com/andreas.reitberger/";

        public static List<DocumentationInfo> List => new List<DocumentationInfo>
        {
            new DocumentationInfo(DocumentationIdentifier.SetupConnection, @"einrichten-loslegen/verbindung-mit-repetier-server-einrichten/"),
            new DocumentationInfo(DocumentationIdentifier.NotReachable, @"einrichten-loslegen/verbindung-mit-repetier-server-einrichten/"),
        };

        public static string CreateUrl(DocumentationIdentifier documentationIdentifier)
        {
            var info = List.FirstOrDefault(x => x.Identifier == documentationIdentifier);

            var url = DocumentationBaseUrl;

            if (info != null)
                url += info.Path;

            return url;
        }
    }
}
