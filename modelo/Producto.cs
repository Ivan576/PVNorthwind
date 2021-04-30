using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Producto
    {
        public String Nombre { get; set; }
        public int Cantidad { get; set; }

        public int Id { get; set; }
        public double Precio { get; set; }

        public Producto(String nombre, int cantidad, int id, double precio) {
            Nombre = nombre;
            Cantidad = cantidad;
            Id = id;
            Precio = precio;

        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
