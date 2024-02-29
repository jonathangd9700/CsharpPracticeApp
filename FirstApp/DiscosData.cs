using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;

namespace FirstApp
{
    internal class DiscosData
    {

        public List<Discos> listar() 
        {
            List<Discos> lista = new List <Discos>();
            //CONEXION A DB
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader read;
            try
            {
                con.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security = true";
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "SELECT D.Id, Titulo, CantidadCanciones, UrlImagenTapa, E.Descripcion as Edicion, T.Descripcion as TipoEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id And  D.IdTipoEdicion = t.Id";
                com.Connection = con;

                con.Open();
                read = com.ExecuteReader();
                //LEER LECTOR
                while (read.Read())
                {
                    Discos aux = new Discos();
                    aux.id = read.GetInt32(0);
                    aux.titulo = (string)read["Titulo"];
                    aux.cantidadCanciones = read.GetInt32(2);
                    aux.urlImagenTapa = (string)read["UrlImagenTapa"];
                    aux.Edicion = new Estilos();
                    aux.TipoEdicion = new Estilos();
                    aux.Edicion.Descripcion = (string)read["Edicion"];
                    aux.TipoEdicion.Descripcion = (string)read["TipoEdicion"];

                    lista.Add(aux);
                }
                con.Close();
                return lista;
            }

            catch (Exception ex) 
            {
                throw ex;
            }

        }

    }
}
