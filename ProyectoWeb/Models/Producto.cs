using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public int? Importancia { get; set; }

    public string? Imagen { get; set; }

    public int IdCategoria { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
}
