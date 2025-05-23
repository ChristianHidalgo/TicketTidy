using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Usuario
{
    public int Iidusuario { get; set; }

    public string? Nombreusuario { get; set; }

    public string? Contra { get; set; }

    public int? Iidcliente { get; set; }

    public int? Iidtipousuario { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual Cliente? IidclienteNavigation { get; set; }

    public virtual Tipousuario? IidtipousuarioNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
