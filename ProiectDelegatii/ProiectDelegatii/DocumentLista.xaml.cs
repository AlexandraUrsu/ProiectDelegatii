using ProiectDelegatii.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using Syncfusion.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ProiectDelegatii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentLista : ContentPage
    {
		Delegatie dl;

		public DocumentLista(Delegatie del)
		{
			InitializeComponent();
			dl = del;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			listView.ItemsSource = await App.Database.GetListDocumentAsync(dl.ID);
		}

		private async void Handle_Selected(object sender, SelectedItemChangedEventArgs e)
		{
			Document d;
			if (e.SelectedItem != null)
			{
				await Navigation.PushAsync(new Documente()
				{
					BindingContext = e.SelectedItem as Document
				});

			}
		}

		private string CreateDocument()
		{
			var document = new PdfDocument();

			var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Example.pdf");

			byte[] byteArray = Encoding.UTF8.GetBytes(filePath);
			//byte[] byteArray = Encoding.ASCII.GetBytes(contents);
			MemoryStream stream = new MemoryStream(byteArray);

			MemoryStream ms2 = new MemoryStream();

			ms2.Write(byteArray, 0, byteArray.Length);

			document.Save(ms2);

			StreamReader reader = new StreamReader(stream);
			string file = reader.ReadToEnd();

			return file;
		}

		async void OnDescarcaClicked(object sender, EventArgs e)
		{

			try
			{
				var filePath = await Task.Run(() => CreateDocument());
				await Launcher.OpenAsync(new OpenFileRequest(Path.GetFileName(filePath), new ReadOnlyFile(filePath)));
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message, "Close");
			}
		}
	}
}