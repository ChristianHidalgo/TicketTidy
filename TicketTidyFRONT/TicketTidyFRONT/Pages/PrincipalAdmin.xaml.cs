namespace TicketTidyFRONT.Pages;

public partial class PrincipalAdmin : FlyoutPage
{
	public PrincipalAdmin()
	{
		InitializeComponent();
        App.Navigate = NavigateAdmin;
        App.MenuAdmin = this;
    }

}