using Newtonsoft.Json;
using System.Text;

namespace TicketTidyFRONT.Pages.AccionesAdmin;

public partial class crear_espacios_dispositivos : ContentPage
{
    private readonly HttpClient _httpClient = new();

    public crear_espacios_dispositivos()
    {
        InitializeComponent();
    }

    private async void backBtn_Clicked(object sender, EventArgs e)
    {
        if (Navigation.NavigationStack.Count > 1)
            await Navigation.PopAsync();
        else
            await DisplayAlert("Aviso", "No hay página anterior para volver.", "OK");
    }

    private async void CrearEspacio_Clicked(object sender, EventArgs e)
    {
        string descripcion = espacioDescripcionEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(descripcion))
        {
            await DisplayAlert("Error", "Por favor, introduce una descripción para el espacio.", "OK");
            return;
        }

        var espacio = new { Descripcion = descripcion };
        string url = "http://finaltickettidy.somee.com/crearEspacio";

        try
        {
            var json = JsonConvert.SerializeObject(espacio);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Espacio creado correctamente.", "OK");
                espacioDescripcionEntry.Text = string.Empty;
            }
            else
            {
                string msg = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"Error al crear espacio: {msg}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }

    private async void CrearDispositivo_Clicked(object sender, EventArgs e)
    {
        string descripcion = dispositivoDescripcionEntry.Text?.Trim();
        string marca = dispositivoMarcaEntry.Text?.Trim();
        string modelo = dispositivoModeloEntry.Text?.Trim();
        string tipo = dispositivoTipoEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(descripcion) ||
            string.IsNullOrWhiteSpace(marca) ||
            string.IsNullOrWhiteSpace(modelo) ||
            string.IsNullOrWhiteSpace(tipo))
        {
            await DisplayAlert("Error", "Por favor, rellena todos los campos del dispositivo.", "OK");
            return;
        }

        var dispositivo = new
        {
            Descripcion = descripcion,
            Marca = marca,
            Modelo = modelo,
            Tipo = tipo
        };

        string url = "http://finaltickettidy.somee.com/crearDispositivo";

        try
        {
            var json = JsonConvert.SerializeObject(dispositivo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Dispositivo creado correctamente.", "OK");

                dispositivoDescripcionEntry.Text = string.Empty;
                dispositivoMarcaEntry.Text = string.Empty;
                dispositivoModeloEntry.Text = string.Empty;
                dispositivoTipoEntry.Text = string.Empty;
            }
            else
            {
                string msg = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"Error al crear dispositivo: {msg}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }
}
