using System;
using System.Threading.Tasks;
using Xamarin.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Repository;

namespace Xamarin.Template.View
{
    public partial class MainPage : ContentPage
    {
        SpaceRepository spaceRepository;
        public MainPage()
        {
            spaceRepository = new SpaceRepository();
            InitializeComponent();
            initListView();

        }

        private async Task initListView()
        {            

            listView.ItemsSource = await spaceRepository.GetSpaces();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Espace());
        }

        private async void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Space selectedItem = e.Item as Space;

            await Navigation.PushAsync(new Reservation(selectedItem.IdSpace));

            ((ListView)sender).SelectedItem = null;


        }

        private async void Delete_Clicked(object sender, System.EventArgs e)
        {
        }
    }
}
