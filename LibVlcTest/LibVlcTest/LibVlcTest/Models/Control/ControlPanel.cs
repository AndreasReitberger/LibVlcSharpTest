using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RemoteControlRepetierServer.Models.Control
{

    [Preserve(AllMembers = true)]
    public class ControlPanel
    {
        #region Properties

        public string Header { get; set; }

        public string Content { get; set; }
        public double ValueRead { get; set; }
        public double ValueSet { get; set; }

        public View RotatorItem { get; set; }

        #endregion
    }
}
