using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using MysqlProyect.CapaNegocio;

namespace MysqlProyect
{
    public partial class Lista : System.Web.UI.Page
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);

        public DataTable ListarL()
        {
            Libro listar = new Libro();
            GridView1.DataSource = listar.Listar();
            GridView1.DataBind();
            return listar.Listar();

        }
        public DataTable ListarA()
        {
            Autor listarA = new Autor();
            GridView1.DataSource = listarA.Listar();
            GridView1.DataBind();
            return listarA.Listar();

        }

        public DataTable ListarP()
        {
            Prestamo listarP= new Prestamo();
            GridView1.DataSource = listarP.Listar();
            GridView1.DataBind();
            return listarP.Listar();

        }



        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnlibro_Click(object sender, EventArgs e)
        {
            ListarL();
        }
        protected void btnautor_Click(object sender, EventArgs e)
        {
            ListarA();
        }
        protected void btnpresta_Click(object sender, EventArgs e)
        {
            ListarP();
        }


        //-----------------------------------------------------
        //-------------- BOTONES DE AUTOR----------------------
        //-----------------------------------------------------

        protected void btna_Click(object sender, EventArgs e)
        {

            Autor agrega = new Autor();
            string codAutor = txt1.Text.Trim();
            string apellidos = txt2.Text.Trim();
            string nombres = txt3.Text.Trim();
            string nacionalidad = txt4.Text.Trim();
            agrega.Agregar(codAutor, apellidos, nombres, nacionalidad);
            ListarA();
        }

        protected void btndeleA_Click(object sender, EventArgs e)
        {
            Autor borra = new Autor();
            string codAutor = txt1.Text.Trim();
            borra.Eliminar(codAutor);
        }

        protected void btnacA_Click(object sender, EventArgs e)
        {
            Autor actualiza = new Autor();
            string codAutor = txt1.Text.Trim();
            string apellidos = txt2.Text.Trim();
            string nombres = txt3.Text.Trim();
            string nacionalidad = txt4.Text.Trim();
            actualiza.Actualizar(codAutor, apellidos, nombres, nacionalidad);
        }

        protected void btbl_Click(object sender, EventArgs e)
        {
            Autor busca = new Autor();
            string texto = txtbusca.Text.Trim();
            string criterio = ddlCri.Text.Trim();
            GridView1.DataSource = busca.Buscar(texto, criterio);
            GridView1.DataBind();

        }
        //-----------------------------------------------------
        //-------------- BOTONES DE LIBRO----------------------
        //-----------------------------------------------------

        protected void btnLib_Click(object sender, EventArgs e)
        {
            Libro agregaL = new Libro();
            string codLibro= txt1.Text.Trim();
            string titulo = txt2.Text.Trim();
            string editorial = txt3.Text.Trim();
            agregaL.Agregar(codLibro, titulo, editorial);
            ListarL();
        }

        protected void btndeleL_Click(object sender, EventArgs e)
        {
            Libro borraL = new Libro();
            string codLibro = txt1.Text.Trim();
            borraL.Eliminar(codLibro);
            ListarL();
        }

        protected void btnacL_Click(object sender, EventArgs e)
        {
            Libro actualizaL = new Libro();
            string codLibro = txt1.Text.Trim();
            string titulo = txt2.Text.Trim();
            string editorial = txt3.Text.Trim();
            actualizaL.Actualizar(codLibro, titulo, editorial);
            ListarL();
        }

        protected void btnbuL_Click(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------
        //-------------- BOTONES DE PRESTAMO-------------------
        //-----------------------------------------------------
        protected void btnp_Click(object sender, EventArgs e)
        {
            Prestamo agregaP = new Prestamo ();
           
            string codAutor = txt1.Text.Trim();
            string codLibro= txt2.Text.Trim();
            string fechaPrestamo = txt3.Text.Trim();
            agregaP.Agregar(codAutor,codLibro,fechaPrestamo);
            
        }

        protected void btndeleP_Click(object sender, EventArgs e)
        {
            Prestamo borraP = new Prestamo();
            string fechaPrestamo = txt1.Text.Trim();
            borraP.Eliminar(fechaPrestamo);
        
        }
    }
}

