using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NatalyBoutique.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        public int IdCliente { get; set; }

		[Required]
        public string Nombre { get; set; }

		[Required]
        public string Direccion { get; set; }

		[Required]
        public string Telefono { get; set; }

        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
