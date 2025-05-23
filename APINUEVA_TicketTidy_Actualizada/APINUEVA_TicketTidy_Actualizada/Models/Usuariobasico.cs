using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Usuariobasico
{
    public long Id { get; set; }

    public string? Contraseña { get; set; }

    public string? Email { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Telefono { get; set; }

    [JsonIgnore]
    public virtual ICollection<Incidencium> Incidencia { get; set; } = new List<Incidencium>();
}
