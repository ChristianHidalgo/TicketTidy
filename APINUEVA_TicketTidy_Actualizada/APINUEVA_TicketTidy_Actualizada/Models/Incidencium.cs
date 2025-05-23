using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Incidencium
{
    public long Id { get; set; }

    public DateOnly? FechaDeApertura { get; set; }

    public DateOnly? FechaDeCierre { get; set; }

    public long? DispositivoId { get; set; }

    public long? EspacioId { get; set; }

    public long? GestorId { get; set; }

    public long? TecnicoId { get; set; }

    public long? UBasicoId { get; set; }

    public string? DescripcionDeLaIncidencia { get; set; }

    public string? DescripcionDeLaSolución { get; set; }

    public string? TipoDeIncidencia { get; set; }

    public string? Estado { get; set; }

    public virtual Dispositivo? Dispositivo { get; set; }

    public virtual Espacio? Espacio { get; set; }

    public virtual Gestor? Gestor { get; set; }

    public virtual Tecnico? Tecnico { get; set; }

    public virtual Usuariobasico? UBasico { get; set; }
}
