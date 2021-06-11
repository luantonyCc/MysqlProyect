using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MysqlProyect.CapaNegocio
{
    public class Autor : IAutor
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);

        public void Actualizar(string codAutor, string apellidos, string nombres, string nacionalidad)
        {
                string consulta = "update tautor set Apellidos = @apellidos, Nombres = @nombres, Nacionalidad = @nacionalidad where CodAutor = @codautor";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codautor", codAutor);
                comando.Parameters.AddWithValue("@apellidos", apellidos);
                comando.Parameters.AddWithValue("@nombres", nombres);
                comando.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
        }

        public void Agregar(string codAutor, string apellidos, string nombres, string nacionalidad)
        {
            
                string consulta = "Insert into tautor values(@codautor,@apellidos,@nombres,@nacionalidad)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                // envio de parametros
                comando.Parameters.AddWithValue("@codautor", codAutor);
                comando.Parameters.AddWithValue("@apellidos", apellidos);
                comando.Parameters.AddWithValue("@nombres", nombres);
                comando.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();

        }


        public DataTable Buscar(string texto, string criterio)
        {
            string consulta = " select codautor,apellido from tautor where codautor='" + criterio + " LIKE '%' + @Texto + '%'";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("where", criterio);
            comando.Parameters.AddWithValue("LIKE", texto);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
            
          
        }

        public void Eliminar(string codAutor)
        {

            string consulta = "delete from tautor where codautor='" +codAutor+ "'";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("codautor", codAutor);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
        }

        public DataTable Listar()
        {
            string consulta = "select * from TAutor";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
    }
