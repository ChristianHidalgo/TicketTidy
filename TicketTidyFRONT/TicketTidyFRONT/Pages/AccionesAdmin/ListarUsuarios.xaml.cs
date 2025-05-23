using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;
using APIBuenaTicketing.Models;

namespace TicketTidyFRONT.Pages.AccionesAdmin
{
    public partial class ListarUsuarios : ContentPage
    {
        private readonly HttpClient _httpClient;

        public class UsuarioDisplay
        {
            public string NombreUsuario { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
        }

        public ListarUsuarios()
        {
            InitializeComponent();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://finaltickettidy.somee.com/")
            };

            CargarTiposDeUsuario();
        }

        private void CargarTiposDeUsuario()
        {
            var tipos = new List<string>
            {
                "Técnicos",
                "Gestores",
                "Administradores",
                "Usuarios Básicos"
            };

            TipoUsuarioPicker.ItemsSource = tipos;
        }

        private async void TipoUsuarioPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoUsuarioPicker.SelectedIndex == -1)
                return;

            string tipoSeleccionado = TipoUsuarioPicker.SelectedItem.ToString();
            List<UsuarioDisplay> usuariosMostrar = new();

            try
            {
                switch (tipoSeleccionado)
                {
                    case "Técnicos":
                        var tecnicos = await _httpClient.GetFromJsonAsync<List<Tecnico>>("getTecnicos");
                        if (tecnicos != null)
                        {
                            usuariosMostrar = tecnicos.Select(t => new UsuarioDisplay
                            {
                                NombreUsuario = t.NombreUsuario,
                                Email = t.Email,
                                Telefono = t.Telefono
                            }).ToList();
                        }
                        break;

                    case "Gestores":
                        var gestores = await _httpClient.GetFromJsonAsync<List<Gestor>>("getGestores");
                        if (gestores != null)
                        {
                            usuariosMostrar = gestores.Select(g => new UsuarioDisplay
                            {
                                NombreUsuario = g.NombreUsuario,
                                Email = g.Email,
                                Telefono = g.Telefono
                            }).ToList();
                        }
                        break;

                    case "Administradores":
                        var admins = await _httpClient.GetFromJsonAsync<List<Administrador>>("getAdmins");
                        if (admins != null)
                        {
                            usuariosMostrar = admins.Select(a => new UsuarioDisplay
                            {
                                NombreUsuario = a.NombreUsuario,
                                Email = a.Email,
                                Telefono = a.Telefono
                            }).ToList();
                        }
                        break;

                    case "Usuarios Básicos":
                        var basicos = await _httpClient.GetFromJsonAsync<List<UsuarioBasico>>("getBasicos");
                        if (basicos != null)
                        {
                            usuariosMostrar = basicos.Select(b => new UsuarioDisplay
                            {
                                NombreUsuario = b.NombreUsuario,
                                Email = b.Email,
                                Telefono = b.Telefono
                            }).ToList();
                        }
                        break;
                }

                UsuariosCollectionView.ItemsSource = usuariosMostrar;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudieron cargar los usuarios: {ex.Message}", "OK");
            }
        }
    }
}
