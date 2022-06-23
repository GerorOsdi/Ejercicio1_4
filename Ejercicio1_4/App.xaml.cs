using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio1_4.Controlers;
using System.IO;

namespace Ejercicio1_4
{
    public partial class App : Application
    {
        static dataBase db;

        public static dataBase dbPhoto
        {
            get
            {
                if (db == null)
                {
                    String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbPhotosSave.db3");
                    db = new dataBase(FolderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
