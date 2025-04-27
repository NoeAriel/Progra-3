using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{

    public class CdClientes
    {
        Conexion conn = new Conexion();

        public DataTable MtdMostrarClientes()
        {
            string QueryConsultaClientes = "Select * from tbl_clientes";
            SqlDataAdapter AdapterCli = new SqlDataAdapter(QueryConsultaClientes, conn.MtdAbrirConexion());
            DataTable dtClientes = new DataTable();
            AdapterCli.Fill(dtClientes);
            conn.MtdCerrarConexion();
            return dtClientes;
        }

    }
}
