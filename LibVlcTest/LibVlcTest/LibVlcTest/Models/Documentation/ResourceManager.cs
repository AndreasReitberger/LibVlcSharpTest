using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControlRepetierServer.Models.Documentation
{
    public static class ResourceManager
    {
        public static List<ResourceInfo> List => new List<ResourceInfo>
        {
            new ResourceInfo("flag-icon-css","https://github.com/lipis/flag-icon-css","A collection of all country flags in SVG"),
            new ResourceInfo("Material Design Icons","https://github.com/Templarian/MaterialDesign","A collection of awesome icons"),
        };
    }
}
