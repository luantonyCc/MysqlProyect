using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MysqlProyect.CapaNegocio
{
    interface Ilibro
    {
        DataTable Listar();

        void Agregar(string codLibro, string titulo, string editorial);
      
        void Eliminar(string codLibro);

        void Actualizar(string codLibro, string titulo, string editorial);

        DataTable Buscar(string texto, string criterio);
    }
}
