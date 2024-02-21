using System;
using System.Collections.Generic;

namespace ProyectoTec02AMMA.Models;

public partial class Carrera
{
    public int CarreraId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Profesore> Profesores { get; set; } = new List<Profesore>();
}
