using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Proveedores
    {
        Conexion conn = new Conexion();
        public DataTable MtdMostrarProveedores()
        {
            string QueryConsultaProveedores = "Select * from tbl_proveedores";
            SqlDataAdapter AdapterProv = new SqlDataAdapter(QueryConsultaProveedores, conn.MtdAbrirConexion());
            DataTable dtProveedores = new DataTable();
            AdapterProv.Fill(dtProveedores);
            conn.MtdCerrarConexion();
            return dtProveedores;
        }

    }
}
