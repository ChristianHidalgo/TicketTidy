using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class DetallePedido
{
    public int Iiddetallepedido { get; set; }

    public int? Iidpedido { get; set; }

    public int? Iidproducto { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual Pedido? IidpedidoNavigation { get; set; }

    public virtual Producto? IidproductoNavigation { get; set; }
}
