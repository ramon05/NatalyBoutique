using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatalyBoutique.Procedure
{
	public class ProcedureMostrarTodo
	{
		public DateTime Fecha { get; set; }
		public int Id_Pedido { get; set; }
	    public int Id_Cliente { get; set; }
	    public string Nombre { get; set; }
		public string DireccionClient { get; set; }
	    public string Telefono { get; set; }
		public int CantSurtida { get; set; }
		public int CantOrdenada { get; set; }
		public string Seccion { get; set; }
		public int NumEstante { get; set; }
		public int Id_Articulo { get; set; }
		public string Direccion { get; set; }
		public string Size { get; set; }
		public string Color { get; set; }
		public int CantPedido { get; set; }

	}
}
