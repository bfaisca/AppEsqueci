using appEsqueci.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appEsqueci
{
    public partial class App : Application
    {

        public static string DbName;
        public static string DbPath;
        public App()
        {
            InitializeComponent();

            MainPage = new PagPrincipal();
        }

        public App(string dbPath,string dbName)
        {
            InitializeComponent();
            App.DbName = dbName;
            App.DbPath = dbPath;
            MainPage = new PagPrincipal();
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
