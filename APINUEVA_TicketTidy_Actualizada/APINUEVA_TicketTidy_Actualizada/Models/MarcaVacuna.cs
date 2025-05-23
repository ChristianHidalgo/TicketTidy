using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class MarcaVacuna
{
    public int Iidmarcavacuna { get; set; }

    public string? Nombremarca { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<ExpedienteVacunacion> ExpedienteVacunacions { get; set; } = new List<ExpedienteVacunacion>();
}
