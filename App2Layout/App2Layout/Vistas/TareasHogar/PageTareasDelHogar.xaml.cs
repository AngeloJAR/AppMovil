using App2Layout.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2Layout.Vistas.TareasHogar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTareasDelHogar : ContentPage
    {
        ObservableCollection<TareasDelHogar> tareasHogar;
        public PageTareasDelHogar()
        {
            InitializeComponent();
            tareasHogar = new ObservableCollection<TareasDelHogar>();
            TareasDelHogarListView.ItemsSource = tareasHogar;

            MessagingCenter.Subscribe<AñadirTareaHogar, TareasDelHogar>(this, "NuevaTareaDelHogar", async (sender, tarea) =>
            {
                await LoadTareasDelHogarAsync();
            });
            LoadTareasDelHogarAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadTareasDelHogarAsync();
        }
        private async Task LoadTareasDelHogarAsync()
        {
            var items = await App.db_Conexion.GetTareasDelHogarAsync();
            tareasHogar.Clear();
            foreach (var item in items)
            {
                tareasHogar.Add(item);
            }
        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tareaHogar = button?.BindingContext as TareasDelHogar;
            if (tareaHogar != null)
            {
                await Navigation.PushAsync(new PageEditTareasHogar(tareaHogar));
            }
        }


        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var buttton = sender as Button;
            var tarea = buttton?.BindingContext as Tarea;
            if (tarea != null)
            {
                bool confirm = await DisplayAlert("Confirmar", "¿Esta seguro de que desea eliminar este item?", "Si", "NO");
                if (confirm)
                {
                    await App.db_Conexion.UpdateItemAsync(tarea);
                    await LoadTareasDelHogarAsync();
                }
            }

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (TareasDelHogarListView.SelectedItem != null)
            {
                var tareaHogar = TareasDelHogarListView.SelectedItem as TareasDelHogar;
                await Navigation.PushAsync(new PageEditTareasHogar(tareaHogar));
            }
            else
            {
                await DisplayAlert("Error", "Selecciona una tarea para editar.", "Aceptar");
            }
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AñadirTareaHogar());
        }
    }
}