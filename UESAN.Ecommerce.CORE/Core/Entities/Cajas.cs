using System;
using System.Collections.Generic;

namespace UESAN.Ecommerce.CORE.Infrastructure.Data;

public partial class Cajas
{
    public int CajasCod { get; set; }

    public DateOnly? FechaFfFv { get; set; }

    public string? Descripcion { get; set; }

    public int? Cantidad { get; set; }
}
