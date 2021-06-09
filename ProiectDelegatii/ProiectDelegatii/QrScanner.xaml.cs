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
    public partial class QrScanner : ContentPage
    {
        public QrScanner()
        {
            InitializeComponent();
            DatePicker.MinimumDate = DateTime.UtcNow.AddDays(-30);
            DatePicker.MaximumDate = DateTime.UtcNow;

        }

        void OnScan(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                scanResult.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
            });
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            int result;

            if (denumire.Text == null || denumire.Text == "" || suma.Text == null || suma.Text == "" || moneda.SelectedItem == null)
            {
                DisplayAlert("Nu putem salva documentul", "Toate câmpurile trebuie completate", "Ok");
            }
            else if(int.TryParse(suma.Text, out result))
            {
                var doc = (Document)BindingContext;
                await App.Database.SaveDocumentAsync(doc);
                await Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Nu putem salva documentul", "Introduceți doar numere în câmpul destinat sumei", "Ok");
            }
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var doc = (Document)BindingContext;
            await App.Database.DeleteDocumentAsync(doc);
            await Navigation.PopAsync();
        }
    }
}