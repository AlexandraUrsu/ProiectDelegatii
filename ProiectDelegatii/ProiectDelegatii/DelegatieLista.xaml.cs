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
               
                if (slist.Data_Plecare.ToString() == "01.01.0001 00:00:00")
                {
                    slist.Data_Plecare = DateTime.Now;
                }
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

        async void UnsetOrase(object sender, EventArgs e)
        {
            var orase = new List<string>();
            orase.Add("");
            loc.ItemsSource = orase;
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
                    orase_estonia.Add("Kohtla-Järve");
                    orase_estonia.Add("Narva");
                    orase_estonia.Add("Pärnu");
                    orase_estonia.Add("Tallinn");
                    orase_estonia.Add("Tartu");

                    loc.ItemsSource = orase_estonia;

                    break;

                case "Finlanda":
                    var orase_finlanda = new List<string>();
                    orase_finlanda.Add("Helsinki");
                    orase_finlanda.Add("Oulu");
                    orase_finlanda.Add("Rovaniemi");
                    orase_finlanda.Add("Tampere");
                    orase_finlanda.Add("Turku");

                    loc.ItemsSource = orase_finlanda;

                    break;

                case "Franţa":
                    var orase_franta = new List<string>();
                    orase_franta.Add("Bordeaux");
                    orase_franta.Add("Lille");
                    orase_franta.Add("Lyon");
                    orase_franta.Add("Marsilia");
                    orase_franta.Add("Nantes");
                    orase_franta.Add("Nisa");
                    orase_franta.Add("Paris");
                    orase_franta.Add("Rennes");
                    orase_franta.Add("Strasbourg");
                    orase_franta.Add("Toulouse");

                    loc.ItemsSource = orase_franta;

                    break;

                case "Georgia":
                    var orase_georgia = new List<string>();
                    orase_georgia.Add("Batumi");
                    orase_georgia.Add("Gori");
                    orase_georgia.Add("Kutaisi");
                    orase_georgia.Add("Poti");
                    orase_georgia.Add("Sagarejo");
                    orase_georgia.Add("Tbilisi");

                    loc.ItemsSource = orase_georgia;

                    break;

                case "Germania":
                    var orase_germania = new List<string>();
                    orase_germania.Add("Berlin");
                    orase_germania.Add("Dortmund");
                    orase_germania.Add("Düsseldorf");
                    orase_germania.Add("Essen");
                    orase_germania.Add("Hamburg");
                    orase_germania.Add("Köln");
                    orase_germania.Add("Frankfurt");
                    orase_germania.Add("München");
                    orase_germania.Add("Stuttgart");
                    orase_germania.Add("Tbilisi");

                    loc.ItemsSource = orase_germania;

                    break;

                case "Grecia":
                    var orase_grecia = new List<string>();
                    orase_grecia.Add("Atena");
                    orase_grecia.Add("Alexandroupolis");
                    orase_grecia.Add("Heraklion");
                    orase_grecia.Add("Patras");
                    orase_grecia.Add("Salonic");

                    loc.ItemsSource = orase_grecia;

                    break;

                case "India":
                    var orase_india = new List<string>();
                    orase_india.Add("Ahmedabad");
                    orase_india.Add("Bangalore");
                    orase_india.Add("Chennai");
                    orase_india.Add("Delhi");
                    orase_india.Add("Kolkata");
                    orase_india.Add("Mumbai");
                    orase_india.Add("Pune");
                    orase_india.Add("Surat");

                    loc.ItemsSource = orase_india;

                    break;

                case "Irlanda":
                    var orase_irlanda = new List<string>();
                    orase_irlanda.Add("Cork");
                    orase_irlanda.Add("Drogheda");
                    orase_irlanda.Add("Dublin");
                    orase_irlanda.Add("Galway");
                    orase_irlanda.Add("Limerick");
                    orase_irlanda.Add("Waterford");

                    loc.ItemsSource = orase_irlanda;

                    break;

                case "Islanda":
                    var orase_islanda = new List<string>();
                    orase_islanda.Add("Akureyri");
                    orase_islanda.Add("Hafnarfjörður");
                    orase_islanda.Add("Kópavogur");
                    orase_islanda.Add("Reykjavík");
                    orase_islanda.Add("Seltjarnarnes");
                    orase_islanda.Add("Vestmannaeyjar");

                    loc.ItemsSource = orase_islanda;

                    break;

                case "Italia":
                    var orase_italia = new List<string>();
                    orase_italia.Add("Bologna");
                    orase_italia.Add("Catania");
                    orase_italia.Add("Florența");
                    orase_italia.Add("Genova");            
                    orase_italia.Add("Milano");
                    orase_italia.Add("Napoli");
                    orase_italia.Add("Palermo");
                    orase_italia.Add("Pisa");
                    orase_italia.Add("Roma");
                    orase_italia.Add("Torino");
                    orase_italia.Add("Veneția");
                    orase_italia.Add("Verona");

                    loc.ItemsSource = orase_italia;

                    break;

                case "Japonia":
                    var orase_japonia = new List<string>();
                    orase_japonia.Add("Kobe");
                    orase_japonia.Add("Kyoto");
                    orase_japonia.Add("Nagoya");
                    orase_japonia.Add("Osaka");
                    orase_japonia.Add("Sapporo");
                    orase_japonia.Add("Sendai");
                    orase_japonia.Add("Yokohama");
                    orase_japonia.Add("Tokyo");

                    loc.ItemsSource = orase_japonia;

                    break;

                case "Letonia":
                   var orase_letonia = new List<string>();
                    orase_letonia.Add("Daugavpils");
                    orase_letonia.Add("Jelgava");
                    orase_letonia.Add("Jūrmala");
                    orase_letonia.Add("Liepāja");
                    orase_letonia.Add("Riga");

                    loc.ItemsSource = orase_letonia;

                    break;

                case "Lituania":
                    var orase_lituania = new List<string>();
                    orase_lituania.Add("Kaunas");
                    orase_lituania.Add("Klaipėda");
                    orase_lituania.Add("Šiauliai");
                    orase_lituania.Add("Vilnius");

                    loc.ItemsSource = orase_lituania;

                    break;

                case "Luxemburg":
                    var orase_luxemburg = new List<string>();
                    orase_luxemburg.Add("Diekirch");
                    orase_luxemburg.Add("Ettelbruck");
                    orase_luxemburg.Add("Luxemburg");
                    orase_luxemburg.Add("Wiltz");

                    loc.ItemsSource = orase_luxemburg;

                    break;

                case "Moldova":
                    var orase_moldova = new List<string>();
                    orase_moldova.Add("Bălți");
                    orase_moldova.Add("Chișinău");
                    orase_moldova.Add("Rîbnița");
                    orase_moldova.Add("Tiraspol");

                    loc.ItemsSource = orase_moldova;

                    break;

                case "Muntenegru":
                    var orase_muntenegru = new List<string>();
                    orase_muntenegru.Add("Budva");
                    orase_muntenegru.Add("Kotor");
                    orase_muntenegru.Add("Podgorița");
                    orase_muntenegru.Add("Tivat");
                    orase_muntenegru.Add("Ulcinj");
                  
                    loc.ItemsSource = orase_muntenegru;

                    break;

                case "Norvegia":
                    var orase_norvegia = new List<string>();
                    orase_norvegia.Add("Bærum");
                    orase_norvegia.Add("Bergen");
                    orase_norvegia.Add("Fredrikstad");
                    orase_norvegia.Add("Kristiansand");
                    orase_norvegia.Add("Oslo");
                    orase_norvegia.Add("Stavanger");
                    orase_norvegia.Add("Trondheim");

                    loc.ItemsSource = orase_norvegia;

                    break;

                case "Olanda":
                    var orase_olanda = new List<string>();
                    orase_olanda.Add("Amsterdam");
                    orase_olanda.Add("Eindhoven");
                    orase_olanda.Add("Haga");
                    orase_olanda.Add("Groningen");
                    orase_olanda.Add("Rotterdam");
                    orase_olanda.Add("Tilburg");
                    orase_olanda.Add("Utrecht");

                    loc.ItemsSource = orase_olanda;

                    break;

                case "Polonia":
                    var orase_polonia = new List<string>();
                    orase_polonia.Add("Bydgoszcz");
                    orase_polonia.Add("Gdańsk ");
                    orase_polonia.Add("Katowice");
                    orase_polonia.Add("Lublin");
                    orase_polonia.Add("Poznań ");
                    orase_polonia.Add("Szczecin");

                    loc.ItemsSource = orase_polonia;

                    break;

                case "Portugalia":
                    var orase_portugalia = new List<string>();
                    orase_portugalia.Add("Amadora");
                    orase_portugalia.Add("Braga ");
                    orase_portugalia.Add("Lisabona");
                    orase_portugalia.Add("Porto ");
                    orase_portugalia.Add("Vila Nova de Gaia");

                    loc.ItemsSource = orase_portugalia;

                    break;

                case "Republica Cehă":
                    var orase_cehia = new List<string>();
                    orase_cehia.Add("Ceske Budejovice");
                    orase_cehia.Add("Brno");
                    orase_cehia.Add("Liberec");
                    orase_cehia.Add("Olomouc");
                    orase_cehia.Add("Ostrava");
                    orase_cehia.Add("Plzen");
                    orase_cehia.Add("Praga");

                    loc.ItemsSource = orase_cehia;

                    break;

                case "România":
                    var orase_romania = new List<string>();
                    orase_romania.Add("Alba Iulia");
                    orase_romania.Add("Arad");
                    orase_romania.Add("Bacău"); 
                    orase_romania.Add("Brăila");
                    orase_romania.Add("Brașov");
                    orase_romania.Add("București");
                    orase_romania.Add("Cluj-Napoca");
                    orase_romania.Add("Constanța");
                    orase_romania.Add("Craiova");
                    orase_romania.Add("Drobeta-Turnu Severin");
                    orase_romania.Add("Galați");
                    orase_romania.Add("Iași");
                    orase_romania.Add("Oradea");
                    orase_romania.Add("Pitești");
                    orase_romania.Add("Ploiești");
                    orase_romania.Add("Râmnicu Vâlcea");
                    orase_romania.Add("Satu Mare");
                    orase_romania.Add("Sibiu");
                    orase_romania.Add("Suceava");
                    orase_romania.Add("Târgu Mureș");
                    orase_romania.Add("Timișoara");

                    loc.ItemsSource = orase_romania;

                    break;

                case "Rusia":
                    var orase_rusia = new List<string>();
                    orase_rusia.Add("Ekaterinburg");
                    orase_rusia.Add("Moscova");
                    orase_rusia.Add("Novosibirsk");
                    orase_rusia.Add("Sankt Petersburg");

                    loc.ItemsSource = orase_rusia;

                    break;

                case "Serbia":
                    var orase_serbia = new List<string>();
                    orase_serbia.Add("Belgrad");
                    orase_serbia.Add("Kragujevac");
                    orase_serbia.Add("Niš");
                    orase_serbia.Add("Novi Sad");
                    orase_serbia.Add("Smederevo");
                    orase_serbia.Add("Zrenjanin-Panciova");

                    loc.ItemsSource = orase_serbia;

                    break;

                case "Slovacia":
                    var orase_slovacia = new List<string>();
                    orase_slovacia.Add("Bratislava");
                    orase_slovacia.Add("Košice");
                    orase_slovacia.Add("Nitra");
                    orase_slovacia.Add("Prešov");
                    orase_slovacia.Add("Žilina");

                    loc.ItemsSource = orase_slovacia;

                    break;

                case "Slovenia":
                    var orase_slovenia = new List<string>();
                    orase_slovenia.Add("Celje");
                    orase_slovenia.Add("Kranj");
                    orase_slovenia.Add("Ljubljana");
                    orase_slovenia.Add("Maribor");
                    orase_slovenia.Add("Velenje");

                    loc.ItemsSource = orase_slovenia;

                    break;

                case "Spania":
                    var orase_spania = new List<string>();

                    orase_spania.Add("Barcelona");
                    orase_spania.Add("Bilbao");
                    orase_spania.Add("Granada");
                    orase_spania.Add("Madrid");
                    orase_spania.Add("Palma de Mallorca");
                    orase_spania.Add("Sevilla");
                    orase_spania.Add("Valencia");

                    loc.ItemsSource = orase_spania;

                    break;

                case "Statele Unite ale Americii":
                    var orase_america = new List<string>();
                    orase_america.Add("Chicago");
                    orase_america.Add("Detroit");
                    orase_america.Add("Houston");
                    orase_america.Add("Las Vegas");
                    orase_america.Add("Los Angeles");
                    orase_america.Add("New York City");
                    orase_america.Add("Philadelphia");
                    orase_america.Add("Phoenix");
                    orase_america.Add("Portland");
                    orase_america.Add("San Diego");
                    orase_america.Add("San Francisco");
                    orase_america.Add("Seattle");
                  
                    loc.ItemsSource = orase_america;

                    break;

                case "Suedia":
                    var orase_suedia = new List<string>();
                    orase_suedia.Add("Gothenburg");
                    orase_suedia.Add("Malmö");
                    orase_suedia.Add("Stockholm");
                    orase_suedia.Add("Uppsala");
                    orase_suedia.Add("Västerås");

                    loc.ItemsSource = orase_suedia;

                    break;

                case "Turcia":
                    var orase_turcia = new List<string>();
                    orase_turcia.Add("Ankara");
                    orase_turcia.Add("Istambul");
                    orase_turcia.Add("Izmir");
                    orase_turcia.Add("Konya");
                    orase_turcia.Add("Marmaris");

                    loc.ItemsSource = orase_turcia;

                    break;

                case "Turkmenistan":
                    var orase_turkmenistan = new List<string>();
                    orase_turkmenistan.Add("Așgabat");
                    orase_turkmenistan.Add("Balkanabat");
                    orase_turkmenistan.Add("Dașoguz");
                    orase_turkmenistan.Add("Mary");
                    orase_turkmenistan.Add("Türkmenabat");

                    loc.ItemsSource = orase_turkmenistan;

                    break;

                case "Ucraina":
                    var orase_ucraina = new List<string>();
                    orase_ucraina.Add("Dnepropetrovsk");
                    orase_ucraina.Add("Kharkov");
                    orase_ucraina.Add("Kiev");
                    orase_ucraina.Add("Odessa");

                    loc.ItemsSource = orase_ucraina;

                    break;

                case "Ungaria":
                    var orase_ungaria = new List<string>();
                    orase_ungaria.Add("Budapesta");
                    orase_ungaria.Add("Debrecen");
                    orase_ungaria.Add("Győr");
                    orase_ungaria.Add("Miskolc");
                    orase_ungaria.Add("Pécs");
                    orase_ungaria.Add("Szeged");

                    loc.ItemsSource = orase_ungaria;

                    break;

                case "Vatican":
                    var orase_vatican = new List<string>();
                    orase_vatican.Add("Vatican");
                   
                    loc.ItemsSource = orase_vatican;

                    break;

            }
        }
    }
}