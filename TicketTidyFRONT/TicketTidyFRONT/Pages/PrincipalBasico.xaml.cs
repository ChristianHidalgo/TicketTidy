namespace TicketTidyFRONT.Pages;

public partial class PrincipalBasico : FlyoutPage
{
    public PrincipalBasico()
    {
        InitializeComponent();
        App.Navigate = NavigateBasico;
        App.MenuBasico = this;
    }
}