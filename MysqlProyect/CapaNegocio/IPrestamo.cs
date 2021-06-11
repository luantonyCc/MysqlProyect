using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MysqlProyect.CapaNegocio
{
    interface IPrestamo
    {
        DataTable Listar();

        void Agregar(string codAutor, string codLibro, string fechaPrestamo);

        void Eliminar(string fechaPrestamo);

        bool Actualizar(string codAutor, string codLibro, string fechaPrestamo);

        DataTable Buscar(string texto, string criterio);
    }
}
