using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Menu
{
    public int Iidmenu { get; set; }

    public string? Nombreopcion { get; set; }

    public string? Nombreicono { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<MenuTipoUsuario> MenuTipoUsuarios { get; set; } = new List<MenuTipoUsuario>();
}
