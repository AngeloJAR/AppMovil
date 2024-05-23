using App2Layout.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2Layout.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class homepage : ContentPage
	{
        private ObservableCollection<Tarea> tareas;
		public homepage ()
		{
			InitializeComponent ();
            tareas = new ObservableCollection<Tarea> ();
            tareasListView.ItemsSource = tareas;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadTareasAsync();
        }

        private async Task LoadTareasAsync()
        {
            var items = await App.db_Conexion.GetItemsAsync();
            tareas.Clear();
            foreach (var item in items)
            {
                tareas.Add(item);
            }
        }


        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new PageContenido());
        }
        //Metodo para editar
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tarea = button?.BindingContext as Tarea;
            if (tarea != null) 
            {
                await Navigation.PushAsync(new EditPage(tarea));
            }
        }
        //Metodo para eliminar
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var buttton = sender as Button;
            var tarea = buttton?.BindingContext as Tarea;
            if (tarea != null)
            {
                bool confirm = await DisplayAlert("Confirmar", "¿Esta seguro de que desea eliminar este item?","Si","NO");
                if (confirm)
                {
                    await App.db_Conexion.DeleteItemAsync(tarea);
                    await LoadTareasAsync();
                }
            }
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TareasHogar.PageTareasDelHogar());
        }
    }
}