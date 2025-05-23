using Microsoft.Maui.Controls;

namespace TicketTidyFRONT.Pages
{
    public partial class GenericaBasico : ContentPage
    {
        public GenericaBasico()
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