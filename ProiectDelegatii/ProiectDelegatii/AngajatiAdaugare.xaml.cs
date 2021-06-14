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
            int result;
            if (nume.Text == null || nume.Text == "" || prenume.Text == null || prenume.Text == "" || cnp.Text == null || cnp.Text == "" || buletin.Text == null || buletin.Text == "" || nume_manager.Text == null || nume_manager.Text == "" || prenume_manager.Text == null || prenume_manager.Text == "" || filiala.SelectedItem == null)
            {
                DisplayAlert("Nu se poate salva", "Toate câmpurile trebuie completate", "Ok");
            }
            else
                 if (int.TryParse(cnp.Text, out result) && cnp.Text.Length==10)
                {
                try
                {
                    var angajat = (Angajat)BindingContext;
                    await App.Database.SaveAngajatAsync(angajat);
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Angajatul există deja");
                    await Navigation.PopAsync();
                }
                }
                else
                {
                    DisplayAlert("Nu se poate salva", "CNP eronat", "Ok");
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