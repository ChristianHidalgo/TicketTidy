using APIBuenaTicketing.Models;
using TicketTidyFRONT.Clases;
using TicketTidyFRONT.Generic;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketTidyFRONT.Pages.AccionesBasico;
using TicketTidyFRONT.Pages.Auxiliares;

namespace TicketTidyFRONT.Pages
{
    public partial class MenuBasico : ContentPage
    {
        int idBasico;
        public List<MenuBasicoCLS> listaMenuBasico { get; set; }
        public UsuarioBasico usuario { get; set; }

        // Constructor sin parámetros (necesario para la instanciación por XAML)
        public MenuBasico()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            listaMenuBasico = new List<MenuBasicoCLS>()
            {
                new MenuBasicoCLS { id = 1, nombre = "Añadir incidencias", icono = "incidencia_icono" }, // Asegúrate de tener esta imagen en tus recursos
                new MenuBasicoCLS { id = 2, nombre = "Consultar mis incidencias", icono = "search" }, // Asegúrate de tener esta imagen en tus recursos
                new MenuBasicoCLS { id = 3, nombre = "Reabrir incidencias cerradas", icono = "reopen_icon" }, // Asegúrate de tener esta imagen en tus recursos
                new MenuBasicoCLS { id = 4, nombre = "Cerrar sesión", icono = "salida" } // Asegúrate de tener esta imagen en tus recursos
            };
            BindingContext = this;
            // No llamamos a GetUsuario() aquí, la información del usuario se cargará en OnAppearing
        }

        // Constructor con parámetro (si lo necesitas para recibir información al navegar)
        public MenuBasico(UsuarioBasico basico)
        {
            InitializeComponent();
            usuario = basico;
            NavigationPage.SetHasNavigationBar(this, false);
            listaMenuBasico = new List<MenuBasicoCLS>()
            {
                new MenuBasicoCLS { id = 1, nombre = "Añadir incidencias", icono = "add_icon" }, // Asegúrate de tener esta imagen en tus recursos
                new MenuBasicoCLS { id = 2, nombre = "Consultar mis incidencias", icono = "search_icon" }, // Asegúrate de tener esta imagen en tus recursos
                new MenuBasicoCLS { id = 3, nombre = "Reabrir incidencias cerradas", icono = "reopen_icon" }, // Asegúrate de tener esta imagen en tus recursos
                new MenuBasicoCLS { id = 4, nombre = "Cerrar sesión", icono = "salida" } // Asegúrate de tener esta imagen en tus recursos
            };
            BindingContext = this;
            if (usuario != null)
            {
                lblId.Text = $"ID: {usuario.Id}";
                lblNombre.Text = $"Usuario: {usuario.NombreUsuario}";
                lblEmail.Text = $"Email: {usuario.Email}";
            }
            else
            {
                // Manejar el caso en que no se proporciona el usuario (por ejemplo, cargar desde Preferences)
                GetUsuario();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (usuario == null)
            {
                GetUsuario(); // Llama a GetUsuario aquí si no se pasó en el constructor
            }
        }

        public async void GetUsuario()
        {
            try
            {
                int id = Convert.ToInt32(Preferences.Get("idBasico", (long)0));
                idBasico = id;
                if (id != 0)
                {
                    usuario = await HTTPHelper.Get<UsuarioBasico>("http://finaltickettidy.somee.com/getBasicoById/" + id + "?idBasico=" + id);

                    if (usuario != null)
                    {
                        lblId.Text = $"ID: {usuario.Id}";
                        lblNombre.Text = $"Usuario: {usuario.NombreUsuario}";
                        lblEmail.Text = $"Email: {usuario.Email}";
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se encontraron los datos del usuario.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "No se ha encontrado el ID del usuario.", "OK");
                    // Posiblemente navegar a la página de inicio de sesión aquí
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo usuario: {ex.Message}");
                await DisplayAlert("Error", "No se pudo cargar la información del usuario.", "OK");
            }
        }

        private async void lstMenuBasico_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is MenuBasicoCLS menuItem)
            {
                //await Navigation.PushModalAsync(new LoadingPage()); // Comenta o descomenta según necesites
                //await Task.Delay(100); // Comenta o descomenta según necesites

                switch (menuItem.id)
                {
                    case 1:
                        // Cerrar el menú desplegable (si es un FlyoutMenu)
                        if (Application.Current.MainPage is FlyoutPage flyoutPage)
                        {
                            flyoutPage.IsPresented = false;
                        }
                        await Navigation.PushModalAsync(new LoadingPage());
                        await Task.Delay(100); // opcional, para que dé tiempo a mostrar la pantalla de carga
                        await App.Navigate.PushAsync(new CrearIncidenciasUsuarioBasico(idBasico));
                        await Navigation.PopModalAsync();
                        break;
                    case 2:
                        await Navigation.PushModalAsync(new LoadingPage());
                        await Task.Delay(100); // opcional, para que dé tiempo a mostrar la pantalla de carga
                        await App.Navigate.PushAsync(new IncidenciasUsuarioBasico());
                        await Navigation.PopModalAsync();
                        break;
                    case 3:
                        await Navigation.PushModalAsync(new LoadingPage());
                        await Task.Delay(100);
                        await App.Navigate.PushAsync(new IncidenciasCerradasUsuarioBasico()); // Reemplaza con tu página
                        await Navigation.PopModalAsync();
                        break;
                    case 4:
                        CerrarSesion();
                        break;
                }

                //await Navigation.PopModalAsync(); // Comenta o descomenta según necesites
                //App.Menu.IsPresented = false; // Si estás en un FlyoutPage
                ((ListView)sender).SelectedItem = null;
            }
        }

        private void CerrarSesion()
        {
            Preferences.Remove("perfil");
            Preferences.Remove("IdBasico");
            App.Current.MainPage = new LoginPage(); // Asegúrate de tener una página de inicio de sesión
        }
    }

    public class MenuBasicoCLS
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string icono { get; set; }
    }
}