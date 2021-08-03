using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControlRepetierServer.Models.Gcode
{
    public static class GcodeCommandManager
    {
        public const string ChangelogBaseUrl = @"https://andreas-reitberger.de/en/3d-druckkosten-kalkulator-app/changelog-3dpcc-app/";

        public static List<GcodeCommand> List => new List<GcodeCommand>
        {
            new GcodeCommand() {Type = GcodeCategory.GCommand, Command = "G0", Description = "Rapid linear Move", Example = "G0 X12", Uri = "https://reprap.org/wiki/G-code/de#G0_.26_G1:_Move"},
            new GcodeCommand() {Type = GcodeCategory.GCommand, Command = "G1", Description = "Linear Move", Example = "G1 X25.2", Uri = "https://reprap.org/wiki/G-code/de#G0_.26_G1:_Move"},
            new GcodeCommand() {Type = GcodeCategory.GCommand, Command = "G2", Description = "Clockwise Arc", Example = "G2 X90.6 Y13.8 I5 J10 E22.4", Uri = "https://reprap.org/wiki/G-code/de#G2_.26_G3:_Controlled_Arc_Move"},
            new GcodeCommand() {Type = GcodeCategory.GCommand, Command = "G3", Description = "Counter-Clockwise Arc", Example = "G3 X90.6 Y13.8 I5 J10 E22.4", Uri = "https://reprap.org/wiki/G-code/de#G2_.26_G3:_Controlled_Arc_Move"},

        };
    }
}
