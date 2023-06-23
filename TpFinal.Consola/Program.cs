using System.Globalization;
using TpFinal.AccesoDatos.Repositories;
using TpFinal.Dominio.Models;

namespace TpFinal.Consola
{
    internal class Program
    {
        public static InMemoryProductosRepository productosInMemory = new();
        public static SqlProductoRepository sqlRepository =new();
        public bool IsSqlServer;
        static void Main(string[] args)
        {
            string? resp;
            do
            {
                //Aqui mostraremos los mensajes que apareceran en nuestra consola igual que el menu de seleccion.
                string menu = "1: Mostrar Menu Consola \n" +
                              "2: Mostrar Menu SqlServer \n" +
                              "3: Salir del programa \n";

                Console.WriteLine(menu);

                Console.Write("Eliga Una Opcion: "); //Aqui es donde indicaremos que operacion vamos a realizar
                resp = Console.ReadLine();

                string? eleccion = Convert.ToString(resp);

                Console.WriteLine(); // Linea de separacion.

                switch (eleccion)
                {
                    case "1":
                        MostrarMenuConsola();
                        break;
                    case "2":
                        MostrarMenuSqlServer();
                        break;
                    default:
                        Console.WriteLine("No se reconoce la opcion ingresada");
                        break;
                }
            }
            while (resp != "3");

            
            
        }

        private static void MostrarMenuSqlServer()
        {
            string? resp;
            string? NombreProducto;
            do
            {
                //Aqui mostraremos los mensajes que apareceran en nuestra consola igual que el menu de seleccion.
                string menu = "1: Crear producto \n" +
                                "2: Mostrar producto \n" +
                                "3: Mostrar todos los productos \n" +
                                "4: Registrar Venta \n" +
                                "5: Salir del programa Consola \n";

                Console.WriteLine(menu);

                Console.Write("Eliga Una Opcion: "); //Aqui es donde indicaremos que operacion vamos a realizar
                resp = Console.ReadLine();

                string? eleccion = Convert.ToString(resp);

                Console.WriteLine(); // Linea de separacion.

                switch (eleccion)
                {
                    case "1":
                        MostrarMenuCrearProducto(true);
                        Console.WriteLine($"Opcion ingresada: {eleccion} \n");
                        break;
                    case "2":
                        Console.WriteLine($"Ingrese nombre de Producto: \n");
                        NombreProducto = Console.ReadLine();
                        var producto = sqlRepository.ObtenerProducto(NombreProducto);
                        if (producto == null)
                        {
                            Console.WriteLine("Producto No encontrado");
                        }
                        else
                        {
                            Console.WriteLine(producto.ToString());
                        }
                        Console.WriteLine($"Opcion ingresada: {eleccion} \n");
                        break;
                    case "3":
                        Console.WriteLine($"Opcion ingresada: {eleccion} \n");
                        var productos = sqlRepository.ObtenerProductos();
                        Console.WriteLine($"Lista de productos: {productos.Count} \n");
                        foreach (var persona in productos)
                        {
                            Console.WriteLine(persona.ToString());
                        }
                        Console.WriteLine($"Fin Lista de productos \n");
                        break;
                    case "4":
                        //registrar venta
                        MostrarMenuVentaProducto();
                        Console.WriteLine($"Opcion ingresada: {eleccion} \n");
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("No se reconoce la opcion ingresada");
                        break;
                }
            }
            while (resp != "5");
        }

        private static void MostrarMenuConsola()
        {
            string? resp;
            string? NombreProducto;
            do
            {
                //Aqui mostraremos los mensajes que apareceran en nuestra consola igual que el menu de seleccion.
                string menu =   "1: Crear producto \n" +
                                "2: Mostrar producto \n" +
                                "3: Mostrar todos los productos \n" +
                                "4: Registrar Venta \n" +
                                "5: Salir del programa \n";

                Console.WriteLine(menu);

                Console.Write("Eliga Una Opcion: "); //Aqui es donde indicaremos que operacion vamos a realizar
                resp = Console.ReadLine();

                string? eleccion = Convert.ToString(resp);

                Console.WriteLine(); // Linea de separacion.

                switch (eleccion)
                {
                    case "1":
                        MostrarMenuCrearProducto(false);
                        Console.WriteLine($"Opcion ingresada: {eleccion} \n");
                        break;
                    case "2":
                        Console.WriteLine($"Ingrese Nombre de Producto: \n");
                        NombreProducto = Console.ReadLine();
                        var producto = productosInMemory.ObtenerProducto(NombreProducto);
                        if (producto ==null)
                        {
                            Console.WriteLine("Producto No encontrado");
                        }
                        else
                        {
                            Console.WriteLine(producto.ToString());
                        }
                        Console.WriteLine($"Opcion ingresada: {eleccion} \n");
                        break;
                    case "3":
                        Console.WriteLine($"Opcion ingresada: {eleccion} \n");
                        var productos = productosInMemory.ObtenerProductos();
                        Console.WriteLine($"Lista de productos: {productos.Count} \n");
                        foreach (var persona in productos)
                        {
                            Console.WriteLine(persona.ToString());
                        }
                        Console.WriteLine($"Fin Lista de productos \n");
                        break;
                    case "4":
                        //registrar venta
                        MostrarMenuVentaProducto();
                        Console.WriteLine($"Opcion ingresada: {eleccion} \n");
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("No se reconoce la opcion ingresada");
                        break;
                }
            }
            while (resp != "5");
        }

        private static void MostrarMenuVentaProducto()
        {
            string? Respuesta = string.Empty;
            Producto producto = new();
            Console.WriteLine("Ingrese Nombre del producto");
            Respuesta = Console.ReadLine();
            producto = productosInMemory.ObtenerProducto(Respuesta);
            if (producto == null)
            {
                Console.WriteLine("Producto No encontrado");
            }
            else
            {
                Console.WriteLine("Ingrese Cantidad del producto");
                Respuesta = Console.ReadLine();
                producto.Cantidad = producto.Cantidad- int.Parse(Respuesta);
                productosInMemory.ModificarProducto(producto);
            }
        }

        private static void MostrarMenuCrearProducto(bool IsSqlServer)
        {
            string? Respuesta = string.Empty;
            Producto producto = new();
            Random random= new Random();

            Console.WriteLine("Ingrese Codigo del producto");
            Respuesta = Console.ReadLine();
            producto.Codigo = Respuesta;

            Console.WriteLine("Ingrese Nombre del producto");
            Respuesta = Console.ReadLine();
            producto.Nombre = Respuesta;

            Console.WriteLine("Ingrese Cantidad del producto");
            Respuesta = Console.ReadLine();
            producto.Cantidad = int.Parse(Respuesta);

            Console.WriteLine("Ingrese Precio del producto");
            Respuesta = Console.ReadLine();
            producto.Precio = decimal.Parse(Respuesta);

            producto.Id = random.Next(1, 9999);

            if (IsSqlServer)
            {
                sqlRepository.InsertarProducto(producto);
            }
            else
            {
                productosInMemory.InsertarProducto(producto);
            }
            


        }
    }
}