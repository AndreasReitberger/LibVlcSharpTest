using RemoteControlRepetierServer.ViewModels.Pages;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemoteControlRepetierServer.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VersionDetailPage : ContentPage
    {
        public VersionDetailPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                ((VersionDetailPageViewModel)this.BindingContext).OnAppearing();
            }
            catch (Exception) { }
            //your code here;
        }
    }
}