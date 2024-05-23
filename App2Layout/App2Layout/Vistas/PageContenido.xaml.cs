using App2Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using App2Layout.Controlador;

namespace App2Layout.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageContenido : ContentPage
    {
        private db_Conexion _dbConexion;

        public PageContenido()
        {
            InitializeComponent();
        }

        public async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var item = new Tarea
                {
                    IdCedula = cedula.Text,
                    Nombre = nombre.Text,
                    Apellido = apellido.Text,
                };
                var result = await App.db_Conexion.InsertItem(item);
                if (result == 1)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar", "Aceptar");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}
