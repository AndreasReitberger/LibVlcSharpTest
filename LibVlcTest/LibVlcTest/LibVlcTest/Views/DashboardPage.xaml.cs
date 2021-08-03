using LibVLCSharp.Forms.Shared;
using RemoteControlRepetierServer.Models.Errors;
using RemoteControlRepetierServer.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemoteControlRepetierServer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await ((DashboardViewModel)BindingContext).OnAppearing();
                //videoView.PropertyChanged += VideoView_PropertyChanged;
                //videoViewTablet.PropertyChanged += VideoView_PropertyChanged;

                //Console.WriteLine($"videoView: {videoView.MediaPlayer?.Media}");
                //Console.WriteLine($"videoViewTablet: {videoViewTablet.MediaPlayer?.Media}");
            }
            catch (Exception) { }
            //your code here;

        }

        private void VideoView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is not MediaPlayerElement view) return;
            if (e.PropertyName.Equals("MediaPlayer"))
            {
                Console.WriteLine($"MediaPlayer binding has changed to: {view.MediaPlayer?.Media}");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            try
            {
                ((DashboardViewModel)BindingContext).OnDisappearing();
                //videoView.PropertyChanged -= VideoView_PropertyChanged;
                //videoViewTablet.PropertyChanged -= VideoView_PropertyChanged;
            }
            catch (Exception) { }
            //your code here;

        }
    }
}