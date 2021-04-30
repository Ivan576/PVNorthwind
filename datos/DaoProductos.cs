using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace datos
{
    public class DaoProductos : DaoCrubProd<Producto, int>
    {
        public override bool actualizar(Producto obj)
        {
            throw new NotImplementedException();
        }

        public override int agregar(Producto obj)
        {
            throw new NotImplementedException();
        }

        public override bool eliminar(int clave)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Se crea una lista, en ella se guardaran los productos
        /// para poder obtenerlo de la base de datos tenemos que crear una sentencia
        /// Select productName== seleccionamos la lista de los nombres de los productos
        ///from northwind.products= aqui seleccionamos en que tabla traeremos esos elementos 
        ///Se crea un producto y se agrega a la lista
        ///se retorna la lista
        /// </summary>
        /// <returns><
        ///
        public override List<Producto> obtenerTodos()
        {
            
            List<Producto> lista = new List<Producto>();

            MySqlCommand sentencia = new MySqlCommand();
            sentencia.CommandText = " Select * from northwind.products";
            DataTable tabla = Conexion.ejecutarConsulta(sentencia);
         
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["productName"].Equals("Null")) {
                    break;

                }
                else {
                    lista.Add((new Producto("" + fila["productName"], int.Parse("" + fila["UnitsInStock"]), int.Parse("" + fila["ProductID"]), double.Parse(""+fila["UnitPrice"]))));
                }
            }
            return lista;
            throw new NotImplementedException();

          

        }

        public override Producto obtenerUno(int clave)
        {
            Producto nuevo;
            MySqlCommand sentencia = new MySqlCommand();
            sentencia.CommandText = " Select * from northwind.products where productID= "+clave;
            DataTable tabla = Conexion.ejecutarConsulta(sentencia);


            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["productName"].Equals("Null"))
                {
                    break;

                }
                else
                {
                    nuevo=((new Producto("" + fila["productName"], int.Parse("" + fila["UnitsInStock"]), int.Parse("" + fila["ProductID"]), double.Parse("" + fila["UnitPrice"]))));
                    return nuevo;
                }
            }

            
            throw new NotImplementedException();
        }
    }
}
