using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Pago
{
    public int Iidpago { get; set; }

    public int? Iidalumno { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Monto { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual Alumno? IidalumnoNavigation { get; set; }
}
