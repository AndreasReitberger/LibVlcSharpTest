using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControlRepetierServer.Models.Gcode
{
    public class GcodeCommand
    {
        public GcodeCategory Type { get; set; } = GcodeCategory.GCommand;
        public string Command { get; set; } = "";
        public string Description { get; set; } = "";
        public string Example { get; set; } = "";
        public string Uri { get; set; } = "";
    }
}
