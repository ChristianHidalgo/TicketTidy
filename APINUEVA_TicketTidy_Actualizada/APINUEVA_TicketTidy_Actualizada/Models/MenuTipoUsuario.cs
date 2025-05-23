using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class MenuTipoUsuario
{
    public int Iidmenutipousuario { get; set; }

    public int? Iidmenu { get; set; }

    public int? Iidtipousuario { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual Menu? IidmenuNavigation { get; set; }

    public virtual Tipousuario? IidtipousuarioNavigation { get; set; }
}
