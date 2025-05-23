using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using APIBuenaTicketing.Models;
using TicketTidyFRONT.ClasesBinding;
using TicketTidyFRONT.Generic;
using Microsoft.Maui.Controls;

namespace TicketTidyFRONT.Pages.AccionesAdmin
{
    public partial class ListarIncidencias : ContentPage
    {
        public IncidenciasAsignadasViewModel ViewModel { get; set; }

        public ListarIncidencias()
        {
            InitializeComponent();

            ViewModel = new IncidenciasAsignadasViewModel
            {
                image = "crono_icon",
                fecha = DateTime.Now.ToString("dd-MM-yyyy"),
                incidenciaIcono = "incidencia_icono_listas"
            };

            BindingContext = ViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.Incidencias == null || !ViewModel.Incidencias.Any())
            {
                await CargarIncidencias();
            }
        }

        private async Task CargarIncidencias()
        {
            try
            {
                if (ViewModel == null)
                    return;

                ViewModel.Incidencias = new ObservableCollection<Incidencia>();

                var incidenciasHTTP = await HTTPHelper.GetAll<Incidencia>(
                    "http://finaltickettidy.somee.com/incidencias");

                foreach (var item in incidenciasHTTP)
                {
                    ViewModel.Incidencias.Add(item);
                }

                if (!ViewModel.Incidencias.Any())
                    await DisplayAlert("Aviso", "No hay incidencias registradas", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudieron cargar las incidencias", "OK");
            }
        }

        private async void buscarBtn_Clicked(object sender, EventArgs e)
        {
            if (ViewModel == null)
                return;

            ViewModel.loading = true;
            await CargarIncidencias();
            ViewModel.loading = false;
        }

    }
}
