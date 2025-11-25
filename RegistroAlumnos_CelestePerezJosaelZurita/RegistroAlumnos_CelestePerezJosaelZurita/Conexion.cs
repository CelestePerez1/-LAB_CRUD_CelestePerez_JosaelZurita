using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace RegistroAlumnos_CelestePerezJosaelZurita
{
    internal class Conexion
    {

        private SqlConnection conn;

        public Conexion()
        {
            string cadena = ConfigurationManager.ConnectionStrings["DBAlumnosConnection"].ConnectionString;
            conn = new SqlConnection(cadena);
        }

        public SqlConnection Abrir()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public void Cerrar()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
