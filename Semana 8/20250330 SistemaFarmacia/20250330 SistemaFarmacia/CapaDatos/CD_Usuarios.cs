using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    
    public class CD_Usuarios
    {
        Conexion conn = new Conexion();

        public DataTable MtdConsultaUsuarios()
        {
            string QueryConsultaUsuarios = "Select * from tbl_usuarios";
            SqlDataAdapter AdapterUsu = new SqlDataAdapter(QueryConsultaUsuarios,conn.MtdAbrirConexion());
            DataTable dtUsuarios = new DataTable();
            AdapterUsu.Fill(dtUsuarios);
            conn.MtdCerrarConexion();
            return dtUsuarios;
        }


    }
}
