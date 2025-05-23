using System.Collections.ObjectModel;
using APIBuenaTicketing.Models;
using TicketTidyFRONT.ClasesBinding;
using TicketTidyFRONT.Generic;

namespace TicketTidyFRONT.Pages.AccionesBasico;

public partial class IncidenciasUsuarioBasico : ContentPage
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
                //IMPORTANTE, esta url es la de tecnico, hay que cambiarla por la de basico:
                "http://finaltickettidy.somee.com/getIncidenciasByBasico/{id}?idBasico=" + idBasico
                //"http://finaltickettidy.somee.com/getIncidenciasByTecnico/{id}?idtecnico=" + idBasico
            );

            foreach (var item in incidenciasHTTP)
            {
                Console.WriteLine($"ID: {item.Id} | Descripción: {item.DescripcionDeLaIncidencia} | Fecha: {item.FechaDeApertura} | Tipo: {item.TipoDeIncidencia}");
                ViewModel.Incidencias.Add(item);
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

    public IncidenciasUsuarioBasico()
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
        App.Navigate.PushAsync(new VerIncidenciaBasico()); // Asegúrate de tener esta página creada
    }

    private async void asignadasRefreshing_Refreshing(object sender, EventArgs e)
    {
        await CargarIncidencias();
    }
}
