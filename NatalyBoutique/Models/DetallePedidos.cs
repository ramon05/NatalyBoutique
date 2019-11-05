using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NatalyBoutique.Models
{
    public partial class DetallePedidos
    {
        public int IdPedido { get; set; }
        public int IdArticulo { get; set; }

		[Required]
        public string Descripcion { get; set; }

		[Required]
        public string Tamaño { get; set; }

		[Required]
        public string Color { get; set; }

		[Required]
        public string SeccionBodega { get; set; }

		[Required]
        public int NumeroEstante { get; set; }

		[Required]
        public int CantidadOrdenada { get; set; }

		[Required]
        public int CantidadSurtida { get; set; }

        public virtual Artículos IdArticuloNavigation { get; set; }
        public virtual Pedidos IdPedidoNavigation { get; set; }
    }
}
