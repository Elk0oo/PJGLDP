using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Repository;

namespace Xamarin.Template.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reservation : ContentPage
    {
        BookingRepository bookingRepository;
        int spaceId = 0;
        public Reservation(int _spaceId)
        {
            bookingRepository = new BookingRepository();
            InitializeComponent();
            spaceId = _spaceId;
            initListView();
        }

        private async Task initListView()
        {
            listView.ItemsSource = await bookingRepository.GetBookingsBySpaceId(spaceId);
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddReservation(spaceId));
        }
       
    }
}