using App2Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2Layout.Vistas.TareasHogar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActualizarTareasHogar : ContentPage
	{
        private TareasDelHogar _tarea;
        public ActualizarTareasHogar (TareasDelHogar tareasDelHogar)
		{
			InitializeComponent ();
            _tarea = tareasDelHogar;
            BindingContext = _tarea;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _tarea.Nombre = nombreEntry.Text;
            _tarea.Descripcion = descripcionEntry.Text;
            _tarea.HoraInicio = DateTime.Today.Add(horaInicioTimePicker.Time);
            _tarea.HoraFinalizacion = DateTime.Today.Add(horaFinalizacionTimePicker.Time);

            await App.db_Conexion.UpdateTareaDelHogarAsync(_tarea);
            await Navigation.PopAsync();
        }
    }
}