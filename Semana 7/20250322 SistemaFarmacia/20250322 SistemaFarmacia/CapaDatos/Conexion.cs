using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDatos
{
    public class Conexion
    {
        private SqlConnection db_conexion = new SqlConnection("Data Source=DESKTOP-IH3GHDG\\SQLEXPRESS;Initial Catalog=db_farmacia;Integrated Security=True;Encrypt=False");

        public SqlConnection MtdAbrirConexion()
        {
            if (db_conexion.State == ConnectionState.Closed)
                db_conexion.Open();
            return db_conexion;
        }

        public SqlConnection MtdCerrarConexion()
        {
            if (db_conexion.State == ConnectionState.Open)
                db_conexion.Close();
            return db_conexion;
        }

    }

}
