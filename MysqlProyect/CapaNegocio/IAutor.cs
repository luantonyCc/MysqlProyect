using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MysqlProyect.CapaNegocio
{
    interface IAutor
    {
        DataTable Listar();

        void Agregar(string codAutor, string apellidos, string nombres, string nacionalidad);

        void Eliminar(string codAutor);

        void Actualizar(string codAutor, string apellidos, string nombres, string nacionalidad);

        DataTable Buscar(string texto, string criterio);

    }
}
