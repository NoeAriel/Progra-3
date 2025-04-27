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

        public void MtdAgregarClientes(string Nombre, string Nit, int Telefono, string Direccion, string Estado, DateTime FechaAuditoria, string UsuarioAuditoria)
        {

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            
            
            
            
            string QueryAgregarClientes = "Insert into tbl_clientes( Nombre, Nit, Telefono, Direccion, Estado, FechaAuditoria, UsuarioAuditoria) values ( @Nombre, @Nit, @Telefono, @Direccion, @Estado, @FechaAuditoria,@ UsuarioAuditoria)";
            SqlCommand CommAgregaClientes = new SqlCommand(QueryAgregarClientes,conn.MtdAbrirConexion());
            CommAgregaClientes.Parameters AddWithValue("@Nombre",Nombre);
            CommAgregaClientes.Parameters AddWithValue("@Nit",Nit);
            CommAgregaClientes.Parameters AddWithValue("@Telefono",Telefono);
            CommAgregaClientes.Parameters AddWithValue("@Direccion",Direccion);
            CommAgregaClientes.Parameters AddWithValue("@Estado",Estado);
            CommAgregaClientes.Parameters AddWithValue("@FechaAuditoria",FechaAuditoria);
            CommAgregaClientes.Parameters AddWithValue("@UsuarioAuditoria",UsuarioAuditoria);
            CommAgrgarClientes.ExecuteNonQuery();
            conn.MtdCerrarConexion();

        }

    }
}
