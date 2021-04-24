using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectDelegatii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Harta : ContentPage
    {
        public Harta()
        {
            InitializeComponent();
        }

        async void OnDeschideClicked(object sender, EventArgs e)
        {
           await NavigateToBuilding25();
        }

        public async Task NavigateToBuilding25()
        {
            var location = new Location(46.7731747, 23.6192053);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

            await Map.OpenAsync(location, options);
        }

        
        public async Task OpenPlacemarkOnMap(Placemark placemark)
        {
            try
            {
                await placemark.OpenMapsAsync();
            }
            catch (Exception ex)
            {
                // No map application available to open
            }
        }
    }
}