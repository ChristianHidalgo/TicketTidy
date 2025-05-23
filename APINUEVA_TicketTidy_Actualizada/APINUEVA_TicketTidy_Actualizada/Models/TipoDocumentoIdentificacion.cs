using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class TipoDocumentoIdentificacion
{
    public int Iidtipodocumento { get; set; }

    public string? Nombre { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
