using App2Layout.Controlador;
using App2Layout.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App2Layout
{
    public partial class App : Application
    {
        public static db_Conexion db_Conexion {  get; set; }

        public App()
        {
            InitializeComponent();
            InitialDatabase();

            //MainPage = new homepage();
            MainPage = new NavigationPage(new homepage());
        }

        private void InitialDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folderApp, "Tarea.db3");
            db_Conexion = new db_Conexion(dbPath);
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
