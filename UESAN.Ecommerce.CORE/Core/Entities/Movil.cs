using System;
using System.Collections.Generic;

namespace UESAN.Ecommerce.CORE.Infrastructure.Data;

public partial class Movil
{
    public int MovilId { get; set; }

    public string? Placa { get; set; }

    public string? Marca { get; set; }

    public string? Descripcion { get; set; }
}
