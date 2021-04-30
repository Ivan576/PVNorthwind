using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
   public class Cliente
    {
        public String Nombre { get; set; }

        public Cliente(String nombre) {
            Nombre = nombre;
        }
    }
}
