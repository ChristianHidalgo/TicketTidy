using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Producto
{
    public int Iidproducto { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Bhabilitado { get; set; }

    public string? Nombreimagen { get; set; }

    public byte[]? Imagen { get; set; }

    public int? Iidcategoria { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Categorium? IidcategoriaNavigation { get; set; }
}
