using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class MedicoTelefonoPersona
{
    public int Iidmedicotelefono { get; set; }

    public int? Iidpersona { get; set; }

    public string? Numerotelefonicomedico { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual Empleado? IidpersonaNavigation { get; set; }
}
