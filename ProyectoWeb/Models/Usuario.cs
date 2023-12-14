using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class Usuario
{
    public string IdUsuario { get; set; } = null!;

    public string? Clave { get; set; }

    public string? Nombres { get; set; }

    public string? Paterno { get; set; }

    public string? Materno { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Aviso> Avisos { get; set; } = new List<Aviso>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Rol> RolNombres { get; set; } = new List<Rol>();
}
