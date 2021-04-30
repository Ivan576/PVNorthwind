using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
 public   class Pvendido
    {
        public String Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }

        public Pvendido(String nombre,double precio, int cantidad, double subtotal)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }
    }
}
