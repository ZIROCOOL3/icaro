using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinal.Dominio.Models;

namespace TpFinal.AccesoDatos.Repositories
{
    public interface IProductoRepository
    {
        Producto ObtenerProducto(string nombre);
        List<Producto> ObtenerProductos();
        List<Producto> EliminarProducto(int id);
        List<Producto> ModificarProducto(Producto producto);
        List<Producto> InsertarProducto(Producto producto);
    }
}
