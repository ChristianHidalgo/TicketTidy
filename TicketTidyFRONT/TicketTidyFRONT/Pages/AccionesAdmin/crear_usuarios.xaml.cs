using Newtonsoft.Json;
using System.Text;

namespace TicketTidyFRONT.Pages.AccionesAdmin;

public partial class crear_usuarios : ContentPage
{
    public crear_usuarios()
    {
        InitializeComponent();
    }
    

    private async void crearBtn_Clicked(object sender, EventArgs e)
    {
        string nombre = nombreEntry.Text?.Trim();
        string correo = correoEntry.Text?.Trim();
        string contraseña = contrasenaEntry.Text?.Trim();
        string telefono = telefonoEntry.Text?.Trim();
        string tipoSeleccionado = pickerTipoUsuario.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) ||
            string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(tipoSeleccionado))
        {
            await DisplayAlert("Error", "Por favor, rellena todos los campos.", "OK");
            return;
        }

        string urlBase = "http://finaltickettidy.somee.com/";

        string urlPost = tipoSeleccionado.ToLower() switch
        {
            "administrador" => urlBase + "crearAdministrador",
            "gestor" => urlBase + "crearGestor",
            "técnico" => urlBase + "crearTecnico",
            "básico" => urlBase + "crearUsuarioBasico",
            _ => null
        };

        if (urlPost == null)
        {
            await DisplayAlert("Error", "Tipo de usuario no válido.", "OK");
            return;
        }

        var usuario = new
        {
            NombreUsuario = nombre,
            Email = correo,
            Contraseña = contraseña,
            Telefono = telefono
        };

        try
        {
            var json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(urlPost, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Usuario creado correctamente.", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                string msg = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"Error al crear usuario: {msg}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }

    private async void backBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
