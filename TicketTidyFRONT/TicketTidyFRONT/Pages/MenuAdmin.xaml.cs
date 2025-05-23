using APIBuenaTicketing.Models;
using TicketTidyFRONT.Generic;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using TicketTidyFRONT.Pages.Auxiliares;
using TicketTidyFRONT.Pages.AccionesAdmin;

namespace TicketTidyFRONT.Pages
{
    public partial class MenuAdmin : ContentPage
    {
        public ObservableCollection<MenuItemModel> listaMenuAdmin { get; set; }
        public Administrador usuario { get; set; }

        public MenuAdmin()
        {
            InitializeComponent();
        
            NavigationPage.SetHasNavigationBar(this, false);

            listaMenuAdmin = new ObservableCollection<MenuItemModel>
            {
                new MenuItemModel { id = 1, nombre = "Gestionar dispositivos y espacios", icono = "espacios_dispositivos.png" },
                new MenuItemModel { id = 2, nombre = "Listado de usuarios por tipo", icono = "usuarios.png" },
                new MenuItemModel { id = 3, nombre = "Listar incidencias", icono = "incidencia_icono.png" },
                  new MenuItemModel { id = 4, nombre = "Gestionar usuarios", icono = "add_icon.png" },
                new MenuItemModel { id = 5, nombre = "Cerrar sesión", icono = "salida.png" }
            };

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (usuario == null)
                GetUsuario();
        }

        public async void GetUsuario()
        {
            try
            {
                int id = Convert.ToInt32(Preferences.Get("idAdmin", (long)0));

                if (id != 0)
                {
                    usuario = await HTTPHelper.Get<Administrador>("http://finaltickettidy.somee.com/getAdminById/" + id + "?idAdmin=" + id);

                    if (usuario != null)
                    {
                        lblId.Text = $"ID: {usuario.Id}";
                        lblNombre.Text = $"Usuario: {usuario.NombreUsuario}";
                        lblEmail.Text = $"Email: {usuario.Email}";
                    }
                    else
                    {

                        await DisplayAlert("Error", "No se encontraron los datos del administrador.", "OK");
                        Console.WriteLine("Respuesta de la API es null.");
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "No se ha encontrado el ID del administrador.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo administrador: {ex.Message}");
                await DisplayAlert("Error", "No se pudo cargar la información del administrador.", "OK");
            }
        }

        private async void lstMenuAdmin_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is MenuItemModel item)
            {
                switch (item.id)
                {
                    case 1:
                        await Navigation.PushModalAsync(new LoadingPage());
                        await Task.Delay(100);
                        await App.Navigate.PushAsync(new crear_espacios_dispositivos());
                        await Navigation.PopModalAsync();
                        break;
                    case 2:
                        await Navigation.PushModalAsync(new LoadingPage());
                        await Task.Delay(100);
                        await App.Navigate.PushAsync(new ListarUsuarios());
                        await Navigation.PopModalAsync();
                        break;
                    case 3:
                        await Navigation.PushModalAsync(new LoadingPage());
                        await Task.Delay(100); 
                        await App.Navigate.PushAsync(new ListarIncidencias());
                        await Navigation.PopModalAsync();
                        break;
                    case 4:
                        await Navigation.PushModalAsync(new LoadingPage());
                        await Task.Delay(100);
                        await App.Navigate.PushAsync(new crear_usuarios());
                        await Navigation.PopModalAsync();
                        break;
                    case 5:
                        Preferences.Remove("perfil");
                        Preferences.Remove("idAdmin");
                        App.Current.MainPage = new LoginPage();
                        break;
                }
                ((ListView)sender).SelectedItem = null;
            }
        }
    }

    public class MenuItemModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string icono { get; set; }
    }
}
