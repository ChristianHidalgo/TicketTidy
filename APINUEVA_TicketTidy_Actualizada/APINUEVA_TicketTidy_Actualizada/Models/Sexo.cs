using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Sexo
{
    public int Iidsexo { get; set; }

    public string? Nombre { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
