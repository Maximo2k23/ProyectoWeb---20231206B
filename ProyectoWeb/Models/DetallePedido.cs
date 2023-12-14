﻿using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class DetallePedido
{
    public int IdDetallePedido { get; set; }

    public int IdProducto { get; set; }

    public int IdPedido { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
