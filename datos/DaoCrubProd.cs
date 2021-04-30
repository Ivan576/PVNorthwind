using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
   public  abstract class DaoCrubProd<T, C>
    {

        public abstract int agregar(T obj);
        public abstract bool actualizar(T obj);
        public abstract bool eliminar(C clave);
        public abstract List<T> obtenerTodos();
        public abstract T obtenerUno(C clave);
    }
}
