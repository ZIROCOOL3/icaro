using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinal.Dominio.Models;

namespace TpFinal.AccesoDatos.Repositories
{
    public class SqlProductoRepository : IProductoRepository
    {
        private string connectionString = "Data Source=DESKTOP-AFQKO55\\SQLEXPRESS;Initial Catalog=TpFinal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Producto> EliminarProducto(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var query = "DELETE Productos where Id = @Id";

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();

            return ObtenerProductos();
        }

        public List<Producto> InsertarProducto(Producto producto)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var query = "INSERT INTO Productos (Codigo, Nombre, Cantidad, Precio) VALUES (@Codigo, @Nombre, @Cantidad, @Precio)";
            EjecutarComando(query, producto, connection);
            return ObtenerProductos();
        }

        public List<Producto> ModificarProducto(Producto producto)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var query = @"UPDATE Productos
            SET Codigo = @Codigo
              , Nombre = @Nombre
              , Cantidad = @Cantidad,
              , Precio = @Precio, 
                WHERE id=@Id ";

            EjecutarComando(query, producto, connection);
            return ObtenerProductos();
        }
        private static void EjecutarComando(string query, Producto producto,SqlConnection connection)
        {
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", producto.Id);
            command.Parameters.AddWithValue("@Codigo", producto.Codigo);
            command.Parameters.AddWithValue("@Nombre", producto.Nombre);
            command.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
            command.Parameters.AddWithValue("@Precio", producto.Precio);
            command.ExecuteNonQuery();
        }
        public Producto ObtenerProducto(string nombre)
        {
            string query = "SELECT * FROM Productos WHERE Nombre = @Nombre";

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", nombre);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var producto = new Producto
                    {
                        Id = reader.GetInt32(nameof(Producto.Id)),
                        Codigo = reader.GetFieldValue<string>("Codigo"),
                        Nombre = reader.GetFieldValue<string>("Nombre"),
                        Cantidad = reader.GetFieldValue<int>("Cantidad"),
                        Precio = reader.GetFieldValue<decimal>("Precio"),
                    };

                    return producto;
                }
            }

            return null;
        }

        public List<Producto> ObtenerProductos()
        {

            var productos = new List<Producto>();

            string query = "SELECT * FROM Productos";

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new Producto
                        {
                            Id = reader.GetInt32(nameof(Producto.Id)),
                            Codigo = reader.GetFieldValue<string>("Codigo"),
                            Nombre = reader.GetFieldValue<string>("Nombre"),
                            Cantidad = reader.GetFieldValue<int>("Cantidad"),
                            Precio = reader.GetFieldValue<decimal>("Precio"),
                        };

                        productos.Add(producto);
                    }
                }

                connection.Close();
            }

            return productos;
        }
    }
}
