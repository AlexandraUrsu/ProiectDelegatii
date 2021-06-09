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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetTotiUseriiAsync();
        }

        async void OnUserAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserAdaugare()
            {
                BindingContext = new User()

            });
        }

        private async void Handle_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            User u;
            if (e.SelectedItem != null)
            {
                u = e.SelectedItem as User;
                var actionSheet = await DisplayActionSheet(u.Username, "Închide", null, "Modificare", "Ștergere");

                switch (actionSheet)
                {
                    case "Ștergere":

                        await App.Database.DeleteUserAsync(u);

                        Navigation.PushAsync(new AdminPage());
                        Navigation.PopAsync();


                        break;

                    case "Modificare":
                        u.id = 1;
                        await Navigation.PushAsync(new UserAdaugare()
                        {
                            BindingContext = e.SelectedItem as User
                        });
                        DisplayAlert("Atenție!","Numele de utilizator nu se poate modifica","Ok");

                        break;

                }
            }
        }
    }
}