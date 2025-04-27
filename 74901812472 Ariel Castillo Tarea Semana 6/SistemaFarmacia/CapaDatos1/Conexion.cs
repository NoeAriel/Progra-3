using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos1
{
    public class Conexion
    {
        public SqlConnection conexion_db = new SqlConnection("Data Source = DESKTOP-IH3GHDG\\SQLEXPRESS");
    }
}
