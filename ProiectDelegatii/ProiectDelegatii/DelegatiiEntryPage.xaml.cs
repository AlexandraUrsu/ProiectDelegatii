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
    public partial class DelegatiiEntryPage : ContentPage
    {
        public DelegatiiEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetDelegatieAsync();
        }
        async void OnDelegatieAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DelegatieLista
            {
                BindingContext = new Delegatie()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListDelegatie
                {
                    BindingContext = e.SelectedItem as Delegatie
                });
            }
        }

        async void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            if (searchBar.Text.Equals(""))
            {
                Navigation.PopAsync();
                Navigation.PushAsync(new DelegatiiEntryPage());
            }
            else
            {
                listView.ItemsSource = await App.Database.GetSearchResults(searchBar.Text);
            }
        }
    }
}