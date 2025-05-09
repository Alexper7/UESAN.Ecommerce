using System;
using System.Collections.Generic;

namespace UESAN.Ecommerce.CORE.Infrastructure.Data;

public partial class Conductor
{
    public int ConductorId { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Telefono { get; set; }
}
