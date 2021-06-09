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
    public partial class AngajatiCompanie : ContentPage
    {
        
        Delegatie dl;

        public AngajatiCompanie(Delegatie del)
        {
            InitializeComponent();
            dl = del;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetAngajatAsync();
        }

        async void OnAngajatAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AngajatiAdaugare(dl)
            {
                BindingContext = new Angajat()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AngajatiAdaugare(dl)
                {
                    BindingContext = e.SelectedItem as Angajat
                });
            }
        }

        async void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            if (searchBar.Text.Equals(""))
            {
                OnAppearing();
            }
            else
            {
                listView.ItemsSource = await App.Database.GetSearchAngajatiResults(searchBar.Text);
            }
        }

        private async void Handle_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            Angajat a;
            if (e.SelectedItem != null)
            {
                a = e.SelectedItem as Angajat;
                var actionSheet = await DisplayActionSheet(a.Nume + " " + a.Prenume, "Închide", null, "Adaugă la delegație", "Vizualizare");

                switch (actionSheet)
                {

                    case "Adaugă la delegație":
                        var la = new ListAngajat()
                        {
                            DelegatieID = dl.ID,
                            AngajatID = a.ID
                        };

                        Task<ListAngajat> taskListAngajat = App.Database.GetListAngajatAsync(la.DelegatieID, la.AngajatID);
                        ListAngajat listang = taskListAngajat.Result;

                        if (listang != null) 
                        {
                            DisplayAlert("Atenție", "Angajatul este deja adăugat", "Ok");
                        }
                        else
                        {
                            await App.Database.SaveListAngajatAsync(la);
                            a.ListAngajati = new List<ListAngajat> { la };
                            await Navigation.PopAsync();
                           
                        }

                        break;

                    case "Vizualizare":

                        await Navigation.PushAsync(new AngajatiAdaugare(dl)
                        {
                            BindingContext = e.SelectedItem as Angajat
                        });

                        break;

                }
            }
        }


    }
}