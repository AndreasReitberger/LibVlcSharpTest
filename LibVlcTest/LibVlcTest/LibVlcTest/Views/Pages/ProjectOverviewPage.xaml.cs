using RemoteControlRepetierServer.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemoteControlRepetierServer.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectOverviewPage : ContentPage
    {
        public ProjectOverviewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                ((ProjectOverviewPageViewModel)this.BindingContext).OnAppearing();
            }
            catch (Exception) { }
            //your code here;

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            try
            {
                ((ProjectOverviewPageViewModel)this.BindingContext).OnDisappearing();
            }
            catch (Exception) { }
            //your code here;

        }
    }
}