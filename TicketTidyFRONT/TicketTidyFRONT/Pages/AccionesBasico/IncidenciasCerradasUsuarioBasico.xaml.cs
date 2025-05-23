using System.Collections.ObjectModel;
using APIBuenaTicketing.Models;
using TicketTidyFRONT.ClasesBinding;
using TicketTidyFRONT.Generic;

namespace TicketTidyFRONT.Pages.AccionesBasico;

public partial class IncidenciasCerradasUsuarioBasico : ContentPage
{
    public IncidenciasAsignadasViewModel ViewModel { get; set; }

    public async Task CargarIncidencias()
    {
        try
        {
            ViewModel.Incidencias = new ObservableCollection<Incidencia>();
            ViewModel.fecha = DateTime.Now.ToString("dd-MM-yyyy");
            ViewModel.cargando = true;

            int idBasico = Convert.ToInt32(Preferences.Get("idBasico", (long)0));
            var incidenciasHTTP = await HTTPHelper.GetAll<Incidencia>(
                "http://finaltickettidy.somee.com/getIncidenciasByBasico/{id}?idBasico=" + idBasico
            );

            foreach (var item in incidenciasHTTP)
            {
                if (item.Estado == "Cerrada")
                {
                    ViewModel.Incidencias.Add(item);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudieron cargar las incidencias", "OK");
        }
        finally
        {
            ViewModel.cargando = false;
        }
    }

    public IncidenciasCerradasUsuarioBasico()
    {
        InitializeComponent();
        ViewModel = new IncidenciasAsignadasViewModel();
        ViewModel.image = "crono_icon";
        ViewModel.incidenciaIcono = "incidencia_icono_listas";
        _ = CargarIncidencias();
        BindingContext = ViewModel;
    }

    private void verIncidencia_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int id = Convert.ToInt32(btn.CommandParameter);
        Preferences.Set("idIncidencia", id);
        App.Navigate.PushAsync(new VerIncidenciaCerradaBasico());
    }

    private async void cerradasRefreshing_Refreshing(object sender, EventArgs e)
    {
        await CargarIncidencias();
    }
}
