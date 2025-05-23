using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Administrador
{
    public long Id { get; set; }

    public string? Contraseña { get; set; }

    public string? Email { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Telefono { get; set; }
}
