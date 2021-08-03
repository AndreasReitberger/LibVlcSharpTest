using LibVLCSharp.Shared;
using System.Collections.Generic;

namespace RemoteControlRepetierServer.Models.VLC
{
    public class LibVlcManager
    {

        #region Properties
        int _networkBufferTime = 150;
        public int NetworkBufferTime
        {
            get => _networkBufferTime;
            set
            {
                if (_networkBufferTime == value) return;
                _networkBufferTime = value;
            }
        }

        int _fileCaching = 2000;
        public int FileCaching
        {
            get => _fileCaching;
            set
            {
                if (_fileCaching == value) return;
                _fileCaching = value;
            }
        }
        #endregion

        static List<string> _options = new List<string>();
        public static List<string> Options 
        {
            get => _options;
            set
            {
                if (_options == value) return;
                _options = value;
            }
        }

        static LibVLC _instance = null;

        public static LibVLC GetInstance()
        {
            if (_instance == null)
            {
                Core.Initialize();
                _instance = new LibVLC(Options.ToArray());

            }
            return _instance;
        }

        #region Constructor
        public LibVlcManager()
        {
            Options = new List<string>();
            Options.Add(string.Format("--file-caching={0}", 0));
            Options.Add("-vvv");

            Initialize();
        }
        #endregion

        #region Methods
        public void Initialize()
        {
            Core.Initialize();
        }
        #endregion
    }

}
