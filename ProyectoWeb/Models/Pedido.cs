using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Estado { get; set; }

    public decimal? Total { get; set; }

    public string IdUsuario { get; set; } = null!;

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
