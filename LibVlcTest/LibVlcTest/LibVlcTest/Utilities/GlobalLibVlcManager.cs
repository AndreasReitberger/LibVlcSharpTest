using LibVLCSharp.Shared;
using RemoteControlRepetierServer.Models.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlRepetierServer.Utilities
{
    public class GlobalLibVlcManager : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region Instance
        static GlobalLibVlcManager _instance = null;
        static readonly object Lock = new object();
        public static GlobalLibVlcManager Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance == null)
                        _instance = new GlobalLibVlcManager();
                }
                return _instance;
            }

            set
            {
                if (_instance == value) return;
                lock (Lock)
                {
                    _instance = value;
                }
            }

        }

        #endregion

        #region Properties
        LibVLC _libVLC;
        public LibVLC LibVLC
        {
            get => _libVLC;
            set
            {
                if (_libVLC == value) return;
                _libVLC = value;
                OnPropertyChanged();
            }
        }

        static bool _isInitialized = false;
        public static bool IsInitialized 
        {
            get => _isInitialized;
            set
            {
                if (_isInitialized == value)
                    return;
                _isInitialized = value;
            }
        }
        #endregion

        #region Constructor
        public GlobalLibVlcManager()
        { }
        public GlobalLibVlcManager(LibVLC lib)
        {
            LibVLC = lib;
            //Instance = this;
        }
        #endregion

        #region Methods

        #region Private

        #endregion

        #region Public
        public void UpdateLibVlc(LibVLC lib)
        {
            this.LibVLC = lib;
        }
        #endregion

        #region Static

        public static void InitLibVlc()
        {
            try
            {
                if (IsInitialized) return;
                Core.Initialize();
                IsInitialized = true;
            }
            catch (Exception exc)
            {
                EventManager.LogError(exc);
                IsInitialized = false;
            }
        }
        public static async Task InitLibVlcAsync()
        {
            try
            {
                if (IsInitialized) return;
                await Task.Run(() => { 
                    Core.Initialize();

                });
                IsInitialized = true;
            }
            catch (Exception exc)
            {
                EventManager.LogError(exc);
                IsInitialized = false;
            }
        }
        #endregion

        #endregion
    }
}
