using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NatalyBoutique.Models
{
    public partial class Artículos
    {
        public Artículos()
        {
            DetallePedidos = new HashSet<DetallePedidos>();
        }

        public int IdArticulo { get; set; }

		[Required]
        public decimal Precio { get; set; }

		[Required]
		public int CantidadExistencia { get; set; }

        public virtual ICollection<DetallePedidos> DetallePedidos { get; set; }
    }
}
