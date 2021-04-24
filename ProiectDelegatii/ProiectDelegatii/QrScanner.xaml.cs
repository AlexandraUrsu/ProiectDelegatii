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
            var doc = (Document)BindingContext;
            await App.Database.SaveDocumentAsync(doc);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var doc = (Document)BindingContext;
            await App.Database.DeleteDocumentAsync(doc);
            await Navigation.PopAsync();
        }
    }
}