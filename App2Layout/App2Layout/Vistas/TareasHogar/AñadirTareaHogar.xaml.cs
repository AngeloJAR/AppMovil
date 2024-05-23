using App2Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2Layout.Vistas.TareasHogar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AñadirTareaHogar : ContentPage
	{
		public AñadirTareaHogar ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
                string.IsNullOrWhiteSpace(descripcionEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            var nuevaTarea = new TareasDelHogar
            {
                Nombre = nombreEntry.Text,
                Descripcion = descripcionEntry.Text,
                HoraInicio = DateTime.Today.Add(horaInicioTimePicker.Time),
                HoraFinalizacion = DateTime.Today.Add(horaFinalizacionTimePicker.Time),
                EstaTerminada = estaTerminadaSwitch.IsToggled
            };

            try
            {
                await App.db_Conexion.InsertTareaDelHogar(nuevaTarea);
                MessagingCenter.Send(this, "NuevaTareaDelHogar", nuevaTarea);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al guardar la tarea: {ex.Message}", "OK");
            }
        }
    }
}