using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class Rol
{
    public int RolNombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
