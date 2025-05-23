using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class TipoAlergium
{
    public int Iidtipoalergia { get; set; }

    public string? Nombretipoalergia { get; set; }

    public string? Bhabilitado { get; set; }

    public virtual ICollection<FichaMedica> FichaMedicas { get; set; } = new List<FichaMedica>();
}
