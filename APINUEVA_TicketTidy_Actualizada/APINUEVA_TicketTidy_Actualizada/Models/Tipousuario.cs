using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Tipousuario
{
    public int Iidtipousuario { get; set; }

    public string? Nombretipousuario { get; set; }

    public string? Descripcion { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<MenuTipoUsuario> MenuTipoUsuarios { get; set; } = new List<MenuTipoUsuario>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
