using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinal.Dominio.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} - Nombre: {Nombre} - Codigo: {Codigo} - Cantidad: {Cantidad} - Precio: {Precio}";
        }
    }
}
