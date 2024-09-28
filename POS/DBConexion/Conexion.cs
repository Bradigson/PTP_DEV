using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBConexion
{
    public class Conexion
    {
        public string mensaje;
        private string strcon = ConfigurationManager.ConnectionStrings["POS2"].ConnectionString;
        private SqlConnection con;
        private SqlCommand comando;
        private IPHostEntry host;

        public Conexion()
        {
            connetionString();

        }

        public SqlConnection connetionString()
        {
            con = new SqlConnection(strcon);
            return con;

        }
        public void conectar()
        {
            con.Open();
        }
        public void desConectar()
        {
            con.Close();
        }

        /// <summary>
        /// Prepara el SqlComand a la espera de otra funcion
        /// </summary>
        /// <param name="sp">Procedimiento almacenado o consulta</param>
        /// <param name="esquema">es un elemento opcional, no obligatorio</param>
        /// <returns></returns>
        public SqlCommand sqlCommand(string sp, string esquema = "")
        {
            try
            {
                conectar();

                if (esquema.Trim().Length >= 1)
                {
                    comando = new SqlCommand(esquema + "." + sp, con);
                }
                else
                {
                    comando = new SqlCommand(sp, con);
                }

            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }

            return comando;
        }

        /// <summary>
        /// Ejecuta el SqlComand y retorna un bool
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        public bool sqlCommandExec(string sp, string esquema = "")
        {

            try
            {

                conectar();

                if (esquema.Trim().Length >= 1)
                {
                    sp = esquema + "." + sp;
                    comando = new SqlCommand(sp, con);
                }
                else
                {
                    comando = new SqlCommand(sp, con);
                }

                comando.ExecuteNonQuery();
                desConectar();

            }
            catch (Exception e)
            {
                mensaje = e.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Ejecuta un SELECT (DataTable)
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DataTable SpQueryTable(string sp, string esquema = "")
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter sqlDataAdapter;
                conectar();

                if (esquema.Trim().Length >= 1)
                {
                    sqlDataAdapter = new SqlDataAdapter(esquema + "." + sp, con);
                }
                else
                {
                    sqlDataAdapter = new SqlDataAdapter(sp, con);
                }

                sqlDataAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                return dt = null;
            }
            finally { con.Close(); }

            return dt;
        }
    }
}