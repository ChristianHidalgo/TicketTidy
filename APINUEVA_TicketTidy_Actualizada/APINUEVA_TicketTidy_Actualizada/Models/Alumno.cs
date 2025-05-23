using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Alumno
{
    public int Iidalumno { get; set; }

    public string? Nombre { get; set; }

    public string? Appaterno { get; set; }

    public string? Apmaterno { get; set; }

    public int? Iidsexo { get; set; }

    public DateTime? Fechanacimiento { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual Sexo? IidsexoNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
