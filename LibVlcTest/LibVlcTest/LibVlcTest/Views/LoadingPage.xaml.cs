using RemoteControlRepetierServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemoteControlRepetierServer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await ((LoadingPageViewModel)this.BindingContext).OnAppearing();
            }
            catch (Exception) { }
            //your code here;

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            try
            {
                ((LoadingPageViewModel)this.BindingContext).OnDisappearing();
            }
            catch (Exception) { }
            //your code here;

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}