using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Dium
{
    public int Iiddia { get; set; }

    public string? Nombredia { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<HoraDiaActividadPersona> HoraDiaActividadPersonas { get; set; } = new List<HoraDiaActividadPersona>();
}
