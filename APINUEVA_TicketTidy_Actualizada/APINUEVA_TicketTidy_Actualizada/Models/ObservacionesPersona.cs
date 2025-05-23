using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class ObservacionesPersona
{
    public int Iidobservacionespersona { get; set; }

    public int? Iidpersona { get; set; }

    public string? Descripcion { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual Empleado? IidpersonaNavigation { get; set; }
}
