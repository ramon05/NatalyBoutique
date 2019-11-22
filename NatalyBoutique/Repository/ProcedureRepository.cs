using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NatalyBoutique.Models;
using NatalyBoutique.Procedure;


namespace NatalyBoutique.Repository
{
	public class ProcedureRepository
	{
		private readonly string _connectionString;
		//private readonly NatalyBoutiqueContext  _natalyBoutique;

		public ProcedureRepository(IConfiguration configuration )
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection");
			//natalyBoutique = _natalyBoutique;
		}

		public async Task<List<MostrarTodo>> GetAll()
		{
			using (SqlConnection sql = new SqlConnection(_connectionString))
			{

				using (SqlCommand cmd = new SqlCommand("MostrarTodo", sql))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					var response = new List<MostrarTodo>();
					await sql.OpenAsync();

					using (var reader = await cmd.ExecuteReaderAsync())
					{
						while (await reader.ReadAsync())
						{
							response.Add(MapToValue(reader));
						}
					}

					return response;
				}
			}
		}

		private MostrarTodo MapToValue(SqlDataReader reader)
		{
			return new MostrarTodo()
			{
				Fecha = Convert.ToDateTime(reader["Fecha"]),
				Id_Pedidos = (int)reader["Id_Pedidos"],
				Id_Cliente = (int)reader["Id_Cliente"],
				Nombre = reader["Nombre"].ToString(),
				Direccion = reader["Direccion"].ToString(),
				Telefono = reader["Telefono"].ToString(),
				CantidadSurtida = (int)reader["CantidadSurtida"],
				CantidadOrdenada = (int)reader["CantidadOrdenada"],
				SeccionBodega = reader["SeccionBodega"].ToString(),
				NumeroEstante = (int)reader["NumeroEstante"],
				Id_Articulo = (int)reader["Id_Articulo"],
				Descripcion = reader["Descripcion"].ToString(),
				Tamaño = reader["Tamaño"].ToString(),
				Color = reader["Color"].ToString(),
				CantidadPedido = (int)reader["CantidadPedido"]
			};
		}

		//public List<MostrarTodo> OdtenerTodo()
		//{
		//	using (var cont = new NatalyBoutiqueContext())
		//	{
		//		return (
		//			from p in cont.Pedidos
		//			join c in cont.Clientes on p.IdCliente equals c.IdCliente
		//			join dt in cont.DetallePedidos on p.IdPedidos equals dt.IdPedido
		//			select new MostrarTodo
		//			{
		//				Fecha = p.Fecha,
		//				Nombre = c.Nombre,
		//				Direccion = c.Direccion,
		//				Telefono = c.Telefono,
		//				CantidadSurtida = dt.CantidadSurtida,
		//				CantidadOrdenada = dt.CantidadOrdenada,
		//				SeccionBodega = dt.SeccionBodega,
		//				NumeroEstante = dt.NumeroEstante,
		//				Descripcion = dt.Descripcion,
		//				Tamaño = dt.Tamaño,
		//				Color = dt.Color,
		//				CantidadPedido = p.CantidadPedido
		//			}
		//		).ToList();
		//	}
		//}

	}
}

	

