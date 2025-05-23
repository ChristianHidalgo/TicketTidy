using System;
using System.Collections.Generic;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class Cliente
{
    public int Iidcliente { get; set; }

    public string? Personaafacturar { get; set; }

    public string? Nombrecompañia { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public string? Codigopostal { get; set; }

    public string? Telefono { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
