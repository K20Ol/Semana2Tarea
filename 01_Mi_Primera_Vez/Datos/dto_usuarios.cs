using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Mi_Primera_Vez.Datos
{
    public class dto_usuarios
    {
        public int idUsuario { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int idPais { get; set; }
    }
}
