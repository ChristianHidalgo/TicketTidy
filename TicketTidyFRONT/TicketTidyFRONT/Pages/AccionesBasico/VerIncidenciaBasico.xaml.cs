using APIBuenaTicketing.Models;
using TicketTidyFRONT.Generic;

namespace TicketTidyFRONT.Pages.AccionesBasico;

public partial class VerIncidenciaBasico : ContentPage
{
    public VerIncidenciaBasico()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarDetalles();
    }

    private async Task CargarDetalles()
    {
        try
        {
            int idIncidencia = Convert.ToInt32(Preferences.Get("idIncidencia", 0));

            var incidencia = await HTTPHelper.Get<Incidencia>(
                $"http://finaltickettidy.somee.com/getIncidenciasById/{idIncidencia}?idIncidencia={idIncidencia}"
            );

            if (incidencia != null)
            {
                lblId.Text = incidencia.Id.ToString();
                lblFechaApertura.Text = incidencia.FechaDeApertura?.ToString("dd-MM-yyyy") ?? "Sin fecha";
                lblDescripcion.Text = incidencia.DescripcionDeLaIncidencia;
                lblTipo.Text = incidencia.TipoDeIncidencia ?? "No especificado";
                lblEstado.Text = incidencia.Estado ?? "No especificado";

                if (incidencia.TecnicoId != 0)
                {
                    var tecnico = await HTTPHelper.Get<Tecnico>($"http://finaltickettidy.somee.com/getTecnico/{incidencia.TecnicoId}?idtecnico={incidencia.TecnicoId}");
                    lblTecnico.Text = tecnico?.NombreUsuario ?? "No asignado";
                }
                else
                {
                    lblTecnico.Text = "No asignado";
                }
            }
            else
            {
                await DisplayAlert("Error", "No se encontró la incidencia", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar los detalles", "OK");
        }
    }

    private async void Volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
