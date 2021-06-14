using ProiectDelegatii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectDelegatii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelegatieLista : ContentPage
    {
        public DelegatieLista()
        {
            InitializeComponent();
            startDatePicker.MinimumDate = DateTime.UtcNow;
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
            if (tara.SelectedItem == null || loc.SelectedItem == null)
            {
                DisplayAlert("Nu putem salva delegația", "Toate câmpurile trebuie completate", "Ok");
            } else
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
           
        }
        async void GetOrase(object sender, EventArgs e)
        {
            switch (tara.SelectedItem)
            {

                case "Anglia":
                    var orase_anglia = new List<string>();
                    orase_anglia.Add("Bolton");
                    orase_anglia.Add("Cambridge");
                    orase_anglia.Add("Derby");
                    orase_anglia.Add("Liverpool");
                    orase_anglia.Add("Londra");
                    orase_anglia.Add("Manchester");
                    orase_anglia.Add("Oxford");

                    loc.ItemsSource = orase_anglia;

                    break;

                case "Austria":
                    var orase_austria = new List<string>();
                    orase_austria.Add("Graz");
                    orase_austria.Add("Innsbruck");
                    orase_austria.Add("Klagenfurt");
                    orase_austria.Add("Linz");
                    orase_austria.Add("Salzburg");
                    orase_austria.Add("Sankt Pölten");
                    orase_austria.Add("Viena");
                   
                    loc.ItemsSource = orase_austria;

                    break;

                case "Belgia":
                    var orase_belgia = new List<string>();
                    orase_belgia.Add("Anvers");
                    orase_belgia.Add("Bruxelles");
                    orase_belgia.Add("Bruges");
                    orase_belgia.Add("Gent");
                    orase_belgia.Add("Liege");
                    orase_belgia.Add("Leuven");

                    loc.ItemsSource = orase_belgia;

                    break;

                case "Bosnia Herțegovina":
                    var orase_bosnia = new List<string>();
                    orase_bosnia.Add("Banja Luka");
                    orase_bosnia.Add("Bihać");
                    orase_bosnia.Add("Bijeljina");
                    orase_bosnia.Add("Doboj");
                    orase_bosnia.Add("Prijedor");
                    orase_bosnia.Add("Mostar");
                    orase_bosnia.Add("Sarajevo");
                    orase_bosnia.Add("Tuzla");
                    orase_bosnia.Add("Zenica");

                    loc.ItemsSource = orase_bosnia;

                    break;

                case "Bulgaria":
                    var orase_buglaria = new List<string>();
                    orase_buglaria.Add("Burgas");
                    orase_buglaria.Add("Dobrici");
                    orase_buglaria.Add("Plovdiv");
                    orase_buglaria.Add("Ruse");
                    orase_buglaria.Add("Sofia");
                    orase_buglaria.Add("Varna");

                    loc.ItemsSource = orase_buglaria;

                    break;

                case "Canada":
                    var orase_canada = new List<string>();
                    orase_canada.Add("Ottawa");
                    orase_canada.Add("Montreal");
                    orase_canada.Add("Toronto");
                    orase_canada.Add("Vancouver");

                    loc.ItemsSource = orase_canada;

                    break;

                case "China":
                    var orase_china = new List<string>();
                    orase_china.Add("Beijing");
                    orase_china.Add("Macao");
                    orase_china.Add("Hong Kong");
                    orase_china.Add("Shanghai");
                    orase_china.Add("Xi'an");
                    
                    loc.ItemsSource = orase_china;

                    break;

                case "Croaţia":
                    var orase_croatia = new List<string>();
                    orase_croatia.Add("Dubrovnik");
                    orase_croatia.Add("Opatija");
                    orase_croatia.Add("Split");
                    orase_croatia.Add("Zadar ");
                    orase_croatia.Add("Zagreb");

                    loc.ItemsSource = orase_croatia;

                    break;

                case "Danemarca":
                    var orase_danemarca = new List<string>();
                    orase_danemarca.Add("Aalborg");
                    orase_danemarca.Add("Aarhus");
                    orase_danemarca.Add("Copenhaga");
                    orase_danemarca.Add("Frederiksberg");
                    orase_danemarca.Add("Odense");

                    loc.ItemsSource = orase_danemarca;

                    break;

                case "Elveţia":
                    var orase_elvetia = new List<string>();
                    orase_elvetia.Add("Basel");
                    orase_elvetia.Add("Berna");
                    orase_elvetia.Add("Geneva");
                    orase_elvetia.Add("Lausanne");
                    orase_elvetia.Add("Lucerna");
                    orase_elvetia.Add("St. Gallen");
                    orase_elvetia.Add("Winterthur");
                    orase_elvetia.Add("Zürich");

                    loc.ItemsSource = orase_elvetia;

                    break;

                case "Estonia":
                    var orase_estonia = new List<string>();
                    orase_estonia.Add("Tallinn");
                    orase_estonia.Add("Tartu");
                    orase_estonia.Add("Narva");
                    orase_estonia.Add("Kohtla-Järve");
                    orase_estonia.Add("Pärnu");

                    loc.ItemsSource = orase_estonia;

                    break;

            }
        }
    }
}