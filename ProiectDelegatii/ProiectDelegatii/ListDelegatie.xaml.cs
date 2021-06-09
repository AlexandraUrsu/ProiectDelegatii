using ProiectDelegatii.Models;
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
    public partial class ListDelegatie : ContentPage
    {
        public ListDelegatie()
        {
            InitializeComponent();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AngajatiCompanie((Delegatie)
           this.BindingContext)
            {
                BindingContext = new Angajat()
            });

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (tara.Text == null || tara.Text == "" || loc.Text == null || loc.Text == "")
            {
                DisplayAlert("Nu putem modifica delegația", "Toate câmpurile trebuie să fie completate", "Ok");
            }
            else
            {
                var slist = (Delegatie)BindingContext;
                slist.Data = DateTime.UtcNow;
                await App.Database.SaveDelegatieAsync(slist);
                await Navigation.PopAsync();
            }
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (Delegatie)BindingContext;
            await App.Database.DeleteDelegatieAsync(slist);
            await Navigation.PopAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var del = (Delegatie)BindingContext;

            listView.ItemsSource = await App.Database.GetListAngajatiAsync(del.ID);
        }
        private async void OnSelect(object sender, SelectedItemChangedEventArgs e)
        {
            Angajat a;
            var del = (Delegatie)BindingContext;
            if (e.SelectedItem != null)
            {
                a = e.SelectedItem as Angajat;
                var actionSheet = await DisplayActionSheet(a.Nume + " " + a.Prenume, "Închide" ,null, "Ștergere");

                switch (actionSheet)
                {
                    case "Ștergere":
                        Task<ListAngajat> taskListAngajat = App.Database.GetListAngajatAsync(del.ID, a.ID);
                        ListAngajat listang = taskListAngajat.Result;
                        await App.Database.DeleteListAngajatAsync(listang);
                        if (listang != null)
                            DisplayAlert("Șters cu succes", "Angajatul " + a.Nume + " " + a.Prenume + " a fost ștrers din delegația " + del.ID, "Ok");
                        else DisplayAlert("Failed", "Ștegerea nu se poate realiza", "Ok");
                        Navigation.PopAsync();
                        break;
                }
            }
        }

        async void OnScanClicked(object sender, EventArgs e)
        {
            var del = (Delegatie)BindingContext;
            await Navigation.PushAsync(new QrScanner
            {
                BindingContext = new Document(del.ID)
            });
        }

        async void OnViewClicked(object sender, EventArgs e)
        {
            var del = (Delegatie)BindingContext;
            await Navigation.PushAsync(new DocumentLista(del));
        }

        async void OnDeschideHartaClicked(object sender, EventArgs e)
        {
            await NavigateToBuilding25();
        }

        public async Task NavigateToBuilding25()
        {
            var placemark = new Placemark
            {
                CountryName = tara.Text,
                Thoroughfare = adr.Text,
                Locality = loc.Text
            };
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

            await Map.OpenAsync(placemark, options);
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