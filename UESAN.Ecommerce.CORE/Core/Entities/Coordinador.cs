using System;
using System.Collections.Generic;

namespace UESAN.Ecommerce.CORE.Infrastructure.Data;

public partial class Coordinador
{
    public int CoordinadorId { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Firma { get; set; }
}
