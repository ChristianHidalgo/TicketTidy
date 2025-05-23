using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Dispositivo
{
    public long Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Tipo { get; set; }

    [JsonIgnore]
    public virtual ICollection<Incidencium> Incidencia { get; set; } = new List<Incidencium>();
}
