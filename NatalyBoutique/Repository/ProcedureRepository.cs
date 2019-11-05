using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NatalyBoutique.Models;
using NatalyBoutique.Procedure;


namespace NatalyBoutique.Repository
{
	public class ProcedureRepository
	{
		private readonly string _connectionString;

		public ProcedureRepository(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		//public async Task<List<ProcedureMostrarTodo>> GetAll()
		//{
		//	using(SqlConnection sql = new SqlConnection(_connectionString))
		//	{
		//		using(SqlCommand cmd = new SqlCommand("MostrarTodo"))
		//		{
		//			cmd.CommandType = System.Data.CommandType.StoredProcedure;
		//			var response = new List<ProcedureMostrarTodo>();
		//			await sql.OpenAsync();

		//			using(var reader = await cmd.ExecuteReaderAsync())
		//			{
		//				while(await reader.ReadAsync())
		//				{
		//					response.Add(MapToValue(reader));
		//				}
		//			}

		//			return response;
		//		}
		//	}
		//}

		//	private ProcedureMostrarTodo MapToValue(SqlDataReader reader)
		//	{
		//		return new ProcedureMostrarTodo()
		//		{
		//			Fecha = reader["Fecha"].ToString(),
		//			Id_Pedido = (int)reader["Id_Pedido"],
		//			Id_Cliente = (int)reader["Id_Cliente"],
		//			Nombre = reader["Nombre"].ToString(),
		//			DireccionClient = reader["DireccionClient"].ToString(),
		//			Telefono = reader["Telefono"].ToString(),
		//			CantSurtida = (int)reader["CantSurtida"],
		//			CantOrdenada =(int)reader["CantOrdenada"],
		//			Seccion = reader["Seccion"].ToString(),
		//			NumEstante = (int)reader["NumEstante"],
		//			Id_Articulo = (int)reader["Id_Articulo"],
		//			Direccion = reader["Direccion"].ToString(),
		//			Size = (int)reader["Size"],
		//			Color = reader["Color"].ToString(),
		//			CantPedida = (int)reader["CantPedida"]
		//		};
		//	}
		//}

		public List<ProcedureMostrarTodo> OdtenerTodo()
		{
			using (var cont = new NatalyBoutiqueContext())
			{
				return (
					from p in cont.Pedidos
					join c in cont.Clientes on p.IdCliente equals c.IdCliente
					join dt in cont.DetallePedidos on p.IdPedidos equals dt.IdPedido
					select new ProcedureMostrarTodo
					{
						Fecha = p.Fecha,
						Nombre = c.Nombre,
						DireccionClient = c.Direccion,
						Telefono = c.Telefono,
						CantSurtida = dt.CantidadSurtida,
						CantOrdenada = dt.CantidadOrdenada,
						Seccion = dt.SeccionBodega,
						NumEstante = dt.NumeroEstante,
						Direccion = dt.Descripcion,
						Size = dt.Tamaño,
						Color = dt.Color,
						CantPedido = p.CantidadPedido
					}
				).ToList();
			}
		}

	}
}
