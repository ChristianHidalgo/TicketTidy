using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class FichaMedica
{
    public int Iidfichamedica { get; set; }

    public int? Iidpersona { get; set; }

    public int? Iidsistemasalud { get; set; }

    public string? Nombresistemasalud { get; set; }

    public string? Medicoatiende { get; set; }

    public int? Iidtipoalergia { get; set; }

    public string? Descripcionalergia { get; set; }

    public int? Iidgruposanguineo { get; set; }

    public string? Enfermedadcronica { get; set; }

    public virtual GrupoSanguineo? IidgruposanguineoNavigation { get; set; }

    public virtual Empleado? IidpersonaNavigation { get; set; }

    public virtual SistemaSalud? IidsistemasaludNavigation { get; set; }

    public virtual TipoAlergium? IidtipoalergiaNavigation { get; set; }
}
