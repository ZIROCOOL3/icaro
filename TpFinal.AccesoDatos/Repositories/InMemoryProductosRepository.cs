using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinal.Dominio.Models;

namespace TpFinal.AccesoDatos.Repositories
{
    public class InMemoryProductosRepository : IProductoRepository
    {
        private List<Producto> Productos = new()
        {
            new Producto
            {
                Id= 1,
                Codigo= "123",
                Nombre="Azucar",
                Cantidad=25,
                Precio=212
            },
            new Producto()
            {
                Id= 2,
                Codigo= "326",
                Nombre="Yerba",
                Cantidad=10,
                Precio=412            }
        };
        public List<Producto> EliminarProducto(int id)
        {
            // Opcion 1
            foreach (var producto in Productos)
            {
                if (producto.Id == id)
                {
                    Productos.Remove(producto);
                }
            }

            return Productos;
        }

        public List<Producto> InsertarProducto(Producto producto)
        {
            Productos.Add(producto);

            return Productos;
        }

        public List<Producto> ModificarProducto(Producto producto)
        {
            // Opcion 1
            Producto productoEncontrada = null;

            foreach (var p in Productos)
            {
                if (p.Nombre == producto.Nombre)
                {
                    productoEncontrada = p;
                    break;
                }
            }

            if (productoEncontrada != null)
            {
                Productos.Remove(productoEncontrada);

                return InsertarProducto(producto);
            }

            return Productos;
        }

        public Producto ObtenerProducto(string nombre)
        {
            Producto productoResult = null;

            // Opcion 1
            foreach (var producto in Productos)
            {
                if (producto.Nombre == nombre)
                {
                    productoResult = producto;
                }
            }

            return productoResult;
        }

        public List<Producto> ObtenerProductos()
        {
            return Productos;
        }
    }
}
