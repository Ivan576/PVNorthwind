using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
   public class Empleado
    {

        public String Nombre { get; set; }

        public Empleado(String nombre) {
            Nombre = nombre;
        }
    }
}
