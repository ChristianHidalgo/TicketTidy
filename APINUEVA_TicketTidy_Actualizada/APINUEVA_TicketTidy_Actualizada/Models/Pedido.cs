using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Pedido
{
    public int Iidpedido { get; set; }

    public int? Iidusuario { get; set; }

    public DateTime? Fechaorden { get; set; }

    public decimal? Precioorden { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Usuario? IidusuarioNavigation { get; set; }
}
