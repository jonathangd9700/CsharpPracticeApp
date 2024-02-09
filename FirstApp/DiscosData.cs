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
                com.CommandText = "SELECT Id, Titulo, CantidadCanciones from DISCOS";
                com.Connection = con;

                con.Open();
                read = com.ExecuteReader();
                //LEER LECTOR
                while (read.Read()) ;
                {
                    Discos aux = new Discos();
                    aux.id = read.GetInt32(0);
                    aux.titulo = (string)read["Titulo"];
                    aux.cantidadCanciones = read.GetInt32(2);

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
