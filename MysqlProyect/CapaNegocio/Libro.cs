using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;



namespace MysqlProyect.CapaNegocio
{
    public class Libro : Ilibro
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        public void Actualizar(string codLibro, string titulo, string editorial)
        {
            string consulta = "update tLibro set Titulo = @titulo, Editorial = @editorial where CodLibro = @codLibro";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@codLibro", codLibro);
            comando.Parameters.AddWithValue("@titulo", titulo);
            comando.Parameters.AddWithValue("@editorial", editorial);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
        }

        public void Agregar(string codLibro, string titulo, string editorial)
        {
            string consulta = "Insert into tlibro values(@codlibro,@titulo,@editorial)";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);

            // envio de parametros
            comando.Parameters.AddWithValue("@codlibro", codLibro);
            comando.Parameters.AddWithValue("@titulo", titulo);
            comando.Parameters.AddWithValue("@editorial", editorial);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
        }

        public DataTable Buscar(string texto, string criterio)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(string codLibro)
        {
            string consulta = "delete from tlibro where codlibro='" + codLibro + "'";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("codlibro", codLibro);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
        }

        public DataTable Listar()
        {
            string consulta = "select * from TLibro";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}