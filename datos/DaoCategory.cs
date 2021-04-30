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
    public class DaoCategory : DaoCrudAbstracto<Category, int>
    {
        public override bool actualizar(Category obj)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "UPDATE categories SET CategoryName=@CategoryName, Description=@Description WHERE CategoryId=@CategoryId";

                sentencia.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
                sentencia.Parameters.AddWithValue("@Description", obj.Description);
                sentencia.Parameters.AddWithValue("@CategoryId", obj.CategoryId);

                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public override int agregar(Category obj)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "INSERT INTO categories (CategoryName,Description) VALUES(@CategoryName,@Description); SELECT LAST_INSERT_ID();";

                sentencia.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
                sentencia.Parameters.AddWithValue("@Description", obj.Description);

                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public override bool eliminar(int clave)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "DELETE FROM categories WHERE CategoryId=@CategoryId";

                sentencia.Parameters.AddWithValue("@CategoryId", clave);

                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public override List<Category> obtenerTodos()
        {
            List<Category> lista = new List<Category>();

            MySqlCommand sentencia = new MySqlCommand();
            sentencia.CommandText = 
                "SELECT CategoryId, CategoryName, Description" +
                " FROM northwind.categories" +
                " order by CategoryName";

            DataTable tabla = Conexion.ejecutarConsulta(sentencia);

            //Recorrer la tabla y crear un objeto por cada fila
            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new Category(
                    int.Parse(fila["CategoryId"].ToString()), fila["CategoryName"].ToString(),
                    fila["Description"].ToString()
                    ));
            }

            return lista;

        }

        public override Category obtenerUno(int clave)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();            sentencia.CommandText =
                    "SELECT CategoryId, CategoryName, Description" +
                    " FROM northwind.categories" +
                    " WHERE CategoryId=" + clave;
            
                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                Category categoria=null;
                if (tabla != null && tabla.Rows.Count > 0){
                    DataRow fila = tabla.Rows[0];
                    categoria = new Category(
                    int.Parse(fila["CategoryId"].ToString()), fila["CategoryName"].ToString(),
                    fila["Description"].ToString()
                    );
                }
                return categoria;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
