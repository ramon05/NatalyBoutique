using System;
using System.Collections.Generic;

namespace NatalyBoutique.Models
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            DetallePedidos = new HashSet<DetallePedidos>();
        }

        public int IdPedidos { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadPedido { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual ICollection<DetallePedidos> DetallePedidos { get; set; }
    }
}
