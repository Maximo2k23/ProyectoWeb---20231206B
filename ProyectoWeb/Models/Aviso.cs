using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class Aviso
{
    public int IdAviso { get; set; }

    public string? Titulo { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Estado { get; set; }

    public string? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
