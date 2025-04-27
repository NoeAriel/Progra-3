using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class CldClientes
    {
        Conexion conn = new Conexion();
        public DataTable MtdConsultarClientes()
        {
            string QueryConsultaClientes = "Select * from tbl_clientes";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaClientes,conn.MtdAbrirConexion());
            DataTable dtClientes = new DataTable();
            sqlAdap.Fill(dtClientes);
            return dtClientes;
            conn.MtdCerrarConexion();
        }
    }
}
