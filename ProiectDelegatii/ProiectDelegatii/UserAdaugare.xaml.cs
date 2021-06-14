using ProiectDelegatii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectDelegatii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAdaugare : ContentPage
    {
        public UserAdaugare()
        {
            InitializeComponent();
        }

        static string passwordEncryption(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)

            {

                sBuilder.Append(data[i].ToString("x2"));

            }
            return sBuilder.ToString();

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (user.Text == null || user.Text == "" || pass.Text == null || pass.Text == "" || rol.SelectedItem == null)
            {
                DisplayAlert("Nu putem adăuga utilizatorul", "Toate câmpurile trebuie completate", "Ok");
            }
            else
            {
                try
                {
                    var user = (User)BindingContext;
                    user.Parola = passwordEncryption(user.Parola);
                    await App.Database.SaveUserAsync(user);
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Utiliaztorul există deja");
                    await Navigation.PopAsync();
                }
                
            }
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            await App.Database.DeleteUserAsync(user);
            await Navigation.PopAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}