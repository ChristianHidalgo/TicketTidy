using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Espacio
{
    public long Id { get; set; }

    public string? Descripcion { get; set; }


    [JsonIgnore]
    public virtual ICollection<Incidencium> Incidencia { get; set; } = new List<Incidencium>();
}
