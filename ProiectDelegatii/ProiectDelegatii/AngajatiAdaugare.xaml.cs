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
    public partial class AngajatiAdaugare : ContentPage
    {
            Delegatie dl;

            public AngajatiAdaugare(Delegatie del)
            {
                InitializeComponent();
                dl = del;
            }

            async void OnSaveButtonClicked(object sender, EventArgs e)
            {
            if (nume.Text == null || nume.Text == "" || prenume.Text == null || prenume.Text == "" || manager.Text == null || manager.Text == "" || filiala.SelectedItem == null)
            {
                DisplayAlert("Nu se poate salva", "Toate câmpurile trebuie completate", "Ok");
            }
            else
            {
                var angajat = (Angajat)BindingContext;
                await App.Database.SaveAngajatAsync(angajat);
                await Navigation.PopAsync();
            }
            }
            async void OnDeleteButtonClicked(object sender, EventArgs e)
            {
                var angajat = (Angajat)BindingContext;
                await App.Database.DeleteAngajatAsync(angajat);
                await Navigation.PopAsync();
            }
            protected override async void OnAppearing()
            {
                base.OnAppearing();

            }

        
    }
}