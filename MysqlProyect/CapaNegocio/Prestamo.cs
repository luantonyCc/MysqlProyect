using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MysqlProyect.CapaNegocio
{
    public class Prestamo : IPrestamo

    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        public bool Actualizar(string codAutor, string codLibro, string fechaPrestamo)
        {
            throw new NotImplementedException();
        }

        public void Agregar(string codAutor, string codLibro, string fechaPrestamo)
        {
            string consulta = "Insert into tprestamo values(@codAutor,@codlibro,@fechaPrestamo)";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);

            // envio de parametros
            comando.Parameters.AddWithValue("@codlibro", codLibro);
            comando.Parameters.AddWithValue("@codAutor", codAutor);
            comando.Parameters.AddWithValue("@fechaPrestamo", fechaPrestamo);
           
        }

        public DataTable Buscar(string texto, string criterio)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(string fechaPrestamo)
        {
            string consulta = "delete from tprestamo where fechaprestamo ='" + fechaPrestamo + "'";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("fechaprestamo", fechaPrestamo);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
        }
    

        public DataTable Listar()
        {
            string consulta = "select * from tprestamo";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);   // lleva la consulta a la base de datos 
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);      // trae la consulta 
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}
