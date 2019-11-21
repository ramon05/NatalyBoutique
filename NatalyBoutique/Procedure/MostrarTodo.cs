using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatalyBoutique.Procedure
{
	public class MostrarTodo
	{
		public DateTime Fecha { get; set; }
		public int Id_Pedidos { get; set; }
	    public int Id_Cliente { get; set; }
	    public string Nombre { get; set; }
		public string Direccion { get; set; }
	    public string Telefono { get; set; }
		public int CantidadSurtida { get; set; }
		public int CantidadOrdenada { get; set; }
		public string SeccionBodega { get; set; }
		public int NumeroEstante { get; set; }
		public int Id_Articulo { get; set; }
		public string Descripcion { get; set; }
		public string Tamaño { get; set; }
		public string Color { get; set; }
		public int CantidadPedido { get; set; }

	}

}
