using ProiectDelegatii.Data;
using ProiectDelegatii.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectDelegatii
{
    public partial class App : Application
    {
        static DelegatiiDataBase database;

        public static DelegatiiDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   DelegatiiDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Delegatii.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            DependencyService.Register<Delegatie>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
