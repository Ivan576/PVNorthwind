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
    public class DaoCliente : DaoCrudAbstracto<Cliente, int>
    {
        public override bool actualizar(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public override int agregar(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public override bool eliminar(int clave)
        {
            throw new NotImplementedException();
        }

        public override List<Cliente> obtenerTodos()
        {
            List<Cliente> lista = new List<Cliente>();

            MySqlCommand sentencia = new MySqlCommand();
            sentencia.CommandText = " Select * from northwind.customers";
            DataTable tabla = Conexion.ejecutarConsulta(sentencia);

            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["CompanyName"].Equals("Null"))
                {
                    break;

                }
                else
                {
                    lista.Add((new Cliente(""+fila["CompanyName"])));
                }
            }
            return lista;

            throw new NotImplementedException();
        }

        public override Cliente obtenerUno(int clave)
        {
            throw new NotImplementedException();
        }
    }
}
