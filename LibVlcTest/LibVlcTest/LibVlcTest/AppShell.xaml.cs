using RemoteControlRepetierServer.ViewModels;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemoteControlRepetierServer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        // This never gets called...
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                ((AppShellViewModel)BindingContext).OnAppearing();
            }
            catch (Exception) { }
        }

        // Quickfix for lagging on android 
        // Source: https://github.com/xamarin/Xamarin.Forms/issues/7521#issuecomment-883622574
        /*
        bool startUp = true;
        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            startUp = false;
        }
        
        protected async override void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (!startUp && propertyName.Equals("CurrentItem") && Device.RuntimePlatform == Device.Android)
            {
                FlyoutIsPresented = true;
                await Task.Delay(300);
                FlyoutIsPresented = false;
            }
        }
        */
        /*
        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            // implement your logic
            base.OnNavigating(args);
        }
        */
    }
}