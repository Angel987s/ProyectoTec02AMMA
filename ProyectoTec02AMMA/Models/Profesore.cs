using System;
using System.Collections.Generic;

namespace ProyectoTec02AMMA.Models;

public partial class Profesore
{
    public int ProfesorId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public byte[]? Foto { get; set; }

    public int? CarreraId { get; set; }

    public virtual Carrera? Carrera { get; set; }
}
