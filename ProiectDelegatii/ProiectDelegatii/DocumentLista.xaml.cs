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
using System.Collections;

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

		
		async void OnDescarcaClicked(object sender, EventArgs e)
		{
		List<Document> l = await App.Database.GetListDocumentAsync(dl.ID);
			float s=0;
			int i = 230;
			string ch;
			DateTime data;
			foreach ( Document chestie in l)
			{
				if (chestie.Moneda.Equals("Ron"))
					s = s + chestie.Suma;
				else s = (float)(s + chestie.Suma * 4.9);
			}
			string suma = s.ToString();
			try
			{
				PdfDocument document = new PdfDocument();

				//Add a page to the document
				PdfPage page = document.Pages.Add();

				//Create PDF graphics for the page
				PdfGraphics graphics = page.Graphics;

				//Set the standard font
				PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

				//Draw the text
				graphics.DrawString("Decont justificativ de cheltuieli diverse", font, PdfBrushes.Black, new PointF(100, 0));
				graphics.DrawString("Delegatia numarul: "+dl.ID.ToString(), font, PdfBrushes.Black, new PointF(0, 50));
				graphics.DrawString("Perioada: " + dl.Data_Plecare.ToString("d") +" - "+dl.Data_Intoarcere.ToString("d"), font, PdfBrushes.Black, new PointF(0, 80));
				graphics.DrawString("Data Decontului: " + DateTime.UtcNow, font, PdfBrushes.Black, new PointF(0, 110));
				graphics.DrawString("Cheltuieli efectuale conform documentelor anexate", font, PdfBrushes.Black, new PointF(30, 180));
				graphics.DrawString("Denumire", font, PdfBrushes.Black, new PointF(30, 230));
				graphics.DrawString("Data Document", font, PdfBrushes.Black, new PointF(180, 230));
				graphics.DrawString("Suma", font, PdfBrushes.Black, new PointF(380, 230));
				foreach (Document chestie in l)
				{
					s = chestie.Suma;
					ch = chestie.Denumire;
					data = chestie.DataDocument;
					i = i + 40;
					graphics.DrawString(ch, font, PdfBrushes.Black, new PointF(30, i));
					graphics.DrawString(data.ToString("d"), font, PdfBrushes.Black, new PointF(180, i));
					graphics.DrawString(s.ToString()+" "+chestie.Moneda, font, PdfBrushes.Black, new PointF(380, i));
				}
				graphics.DrawString("Total Cheltuieli", font, PdfBrushes.Black, new PointF(30, i+50));
				graphics.DrawString(suma+" Ron", font, PdfBrushes.Black, new PointF(380, i+50));
				//Save the document to the stream
				MemoryStream stream = new MemoryStream();
				document.Save(stream);

				//Close the document
				document.Close(true);

				//Save the stream as a file in the device and invoke it for viewing
				Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application / pdf", stream);
				DisplayAlert("Salvat cu succes", "Fisierele mele/Spatiu de stocare intern/Syncfusion", "Close");
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message, "Close");
			}
		}

	}
}