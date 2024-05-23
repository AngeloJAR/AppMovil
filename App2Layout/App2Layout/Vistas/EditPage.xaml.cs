using App2Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2Layout.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{
		private Tarea _tarea;

		public EditPage (Tarea tarea)
		{
			InitializeComponent ();
			_tarea = tarea;
            BindingContext = _tarea;
            cedulaEntry.Text = _tarea.IdCedula;
			nombreEntry.Text = _tarea.Nombre;
			apellidoEntry.Text = _tarea.Apellido;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _tarea.IdCedula = cedulaEntry.Text;
            _tarea.Nombre = nombreEntry.Text;
            _tarea.Apellido = apellidoEntry.Text;
            // Asegúrate de usar Tarea aquí en lugar de TareasHogar
            if (string.IsNullOrWhiteSpace(_tarea.Nombre))
            {
                await DisplayAlert("Error", "Por favor, ingrese un nombre válido.", "OK");
                return;
            }

            if (_tarea.id == 0)
            {
                await App.db_Conexion.InsertItem(_tarea); // Inserta nueva tarea
            }
            else
            {
                await App.db_Conexion.UpdateItemAsync(_tarea); // Actualiza la tarea existente
            }

            MessagingCenter.Send(this, "AgregarEditarTarea", _tarea); // Envía mensaje de actualización
            await Navigation.PopAsync();
        }
    }
}