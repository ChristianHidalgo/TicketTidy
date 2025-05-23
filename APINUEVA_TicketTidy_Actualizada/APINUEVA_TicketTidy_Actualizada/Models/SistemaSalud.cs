using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class SistemaSalud
{
    public int Iidsistemasalud { get; set; }

    public string? Nombre { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<FichaMedica> FichaMedicas { get; set; } = new List<FichaMedica>();
}
