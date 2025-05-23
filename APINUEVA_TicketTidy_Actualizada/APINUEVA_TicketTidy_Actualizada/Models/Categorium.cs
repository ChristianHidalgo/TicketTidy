using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Categorium
{
    public int Iidcategoria { get; set; }

    public string? Nombrecategoria { get; set; }

    public int? Bhabilitado { get; set; }

    public string? Nombreimagen { get; set; }

    public byte[]? Imagen { get; set; }

    public string? Descripcioncategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
