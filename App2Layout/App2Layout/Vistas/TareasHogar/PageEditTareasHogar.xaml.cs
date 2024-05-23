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
    public partial class PageEditTareasHogar : ContentPage
    {
        private TareasDelHogar _tareaHogar;
        public PageEditTareasHogar(TareasDelHogar tareaHogar)
        {
            InitializeComponent();
            _tareaHogar = tareaHogar;
            nombreEntry.Text = _tareaHogar.Nombre;
            descripcionEntry.Text = _tareaHogar.Descripcion;            
            horainicioEntry.Time = _tareaHogar.HoraInicio.TimeOfDay; // Solo necesitas la hora del DateTime
            horafinalizacionEntry.Date = _tareaHogar.HoraFinalizacion; // Convierte DateTime a string
            estaterminadaEntry.IsToggled = _tareaHogar.EstaTerminada; // Convierte bool a string
        }
        //public string Nombre { get; set; }
        //public string Descripcion { get; set; }
        //public DateTime HoraInicio { get; set; }
        //public DateTime HoraFinalizacion { get; set; }
        //public bool EstaTerminada { get; set; }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var tarea = (TareasDelHogar)BindingContext; // Asegúrate de usar Tarea aquí en lugar de TareasHogar
            if (string.IsNullOrWhiteSpace(tarea.Nombre))
            {
                await DisplayAlert("Error", "Por favor, ingrese un nombre válido.", "OK");
                return;
            }

            await App.db_Conexion.InsertTareaDelHogar(tarea); // Asegúrate de llamar al método adecuado para guardar la tarea
            MessagingCenter.Send(this, "AgregarEditarTarea", tarea); // Asegúrate de enviar el mensaje con la tarea correcta
            await Navigation.PopAsync();

        }
    }
}