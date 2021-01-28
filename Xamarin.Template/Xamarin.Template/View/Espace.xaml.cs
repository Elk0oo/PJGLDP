using Android.Arch.Lifecycle;
using Rg.Plugins.Popup.Services;
using Xamarin.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Template.ViewModels;

namespace Xamarin.Template.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Espace : ContentPage
    {       
        public Espace()
        {
            InitializeComponent();
            BindingContext = new EspaceViewModel();
        }

        private void ShowPop_Clicked(object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopUpViewSpace(BindingContext));
        }
        private async void Cancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
       
    }
}