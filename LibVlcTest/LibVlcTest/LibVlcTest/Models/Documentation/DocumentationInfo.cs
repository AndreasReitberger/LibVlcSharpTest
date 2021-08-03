using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControlRepetierServer.Models.Documentation
{
    public class DocumentationInfo
    {
        public DocumentationIdentifier Identifier { get; set; }
        public string Path { get; set; }

        public DocumentationInfo(DocumentationIdentifier identifier, string path)
        {
            Identifier = identifier;
            Path = path;
        }
    }
}
