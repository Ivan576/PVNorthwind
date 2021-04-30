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
    public class DaoEmpleado : DaoCrudAbstracto<Empleado, int>
    {
        public override bool actualizar(Empleado obj)
        {
            throw new NotImplementedException();
        }

        public override int agregar(Empleado obj)
        {
            throw new NotImplementedException();
        }

        public override bool eliminar(int clave)
        {
            throw new NotImplementedException();
        }

        public override List<Empleado> obtenerTodos()
        {
            throw new NotImplementedException();
        }

        public override Empleado obtenerUno(int clave)
        {
            Empleado nuevo;
            MySqlCommand sentencia = new MySqlCommand();
            sentencia.CommandText = " Select * from northwind.employees  where EmployeeID= 1";
            DataTable tabla = Conexion.ejecutarConsulta(sentencia);


            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["FirstName"].Equals("Null"))
                {
                    break;

                }
                else
                {
                    nuevo = ((new Empleado("" + fila["FirstName"])));
                    return nuevo;
                }
            }


            throw new NotImplementedException();
        }
    }
}
