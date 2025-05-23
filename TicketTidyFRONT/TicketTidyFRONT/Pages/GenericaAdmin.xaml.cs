using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using TicketTidyFRONT.Pages.AccionesAdmin;
using TicketTidyFRONT.Pages.Auxiliares;

namespace TicketTidyFRONT.Pages
{
    public partial class GenericaAdmin : ContentPage
    {
        public GenericaAdmin()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("nombreUsuario"))
            {
                lblSaludo.Text = $"¡Hola, {Preferences.Get("nombreUsuario", "")}!";
            }
            else
            {
                lblSaludo.Text = "¡Bienvenido a TicketTidy!";
            }
        }

    }
}
