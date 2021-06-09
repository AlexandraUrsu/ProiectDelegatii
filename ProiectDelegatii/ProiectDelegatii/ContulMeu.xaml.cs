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
    public partial class ContulMeu : ContentPage
    {
        User u;
        public ContulMeu() { }
        public ContulMeu(User user)
        {
            InitializeComponent();
            u = user;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetUserContulMeuAsync(u.Username);

        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            if (e.SelectedItem != null)
            {
                u = e.SelectedItem as User;
                u.id = 1;
                await Navigation.PushAsync(new ContInfo()
                {
                    BindingContext = e.SelectedItem as User
                });
                DisplayAlert("Atenție!", "Rolul și numele de utilizator nu se pot modifica", "Ok");
            }
        }
    }
}