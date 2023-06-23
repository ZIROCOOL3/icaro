using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinal.Dominio.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }


}
