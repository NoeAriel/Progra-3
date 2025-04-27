using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32.SafeHandles;

namespace CapaDatos
{

    public class CD_Clientes
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

        public void MtdAgregarClientes(string Nombre, string Nit,int Telefono, string Direccion, string Estado, DateTime FechaAuditoria,string UsuarioAuditoria)
        {
                string QueryAgregarClientes = "Insert into tbl_clientes( Nombre, Nit, Telefono, Direccion, Estado, FechaAuditoria, UsuarioAuditoria) values (@Nombre, @Nit, @Telefono, @Direccion, @Estado, @FechaAuditoria, @UsuarioAuditoria)";
                SqlCommand CommAgregaClientes = new SqlCommand(QueryAgregarClientes, conn.MtdAbrirConexion());
                CommAgregaClientes.Parameters.AddWithValue("@Nombre", Nombre);
                CommAgregaClientes.Parameters.AddWithValue("@Nit", Nit);
                CommAgregaClientes.Parameters.AddWithValue("@Telefono", Telefono);
                CommAgregaClientes.Parameters.AddWithValue("@Direccion", Direccion);
                CommAgregaClientes.Parameters.AddWithValue("@Estado", Estado);
                CommAgregaClientes.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
                CommAgregaClientes.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
                CommAgregaClientes.ExecuteNonQuery();
                conn.MtdCerrarConexion();

                
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoClientes.Text = "";
            txtNombre.Text = "";

        }

        public void MtdActualizarClientes(int CodigoCliente, string Nombre, string Nit, int Telefono, string Direccion, string Estado, DateTime FechaAuditoria, string UsuarioAuditoria)
        {
            
            string QueryActualizarClientes = "update tbl_clientes\tset Nombre = @Nombre,Nit = @Nit,Telefono = @telefono,Direccion = @direccion,FechaAuditoria =@FechaAditoria,Estado = @Estado,UsuarioAuditoria = @auditoria,";
            SqlCommand CommActualizarClientes = new SqlCommand(QueryActualizarClientes, conn.MtdAbrirConexion());
            CommAgregaClientes.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            CommAgregaClientes.Parameters.AddWithValue("@Nombre", Nombre);
            CommAgregaClientes.Parameters.AddWithValue("@Nit", Nit);
            CommAgregaClientes.Parameters.AddWithValue("@Telefono", Telefono);
            CommAgregaClientes.Parameters.AddWithValue("@Direccion", Direccion);
            CommAgregaClientes.Parameters.AddWithValue("@Estado", Estado);
            CommAgregaClientes.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommAgregaClientes.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommAgregaClientes.ExecuteNonQuery();
            conn.MtdCerrarConexion();


        }

        public void MtdEliminarClientes(int CodigoCliente)
        {

            string QueryEliminarClientes = "Delete tbl_clientes where CodigoCliente = @CodigoCliente;";
            SqlCommand CommEliminarClientes = new SqlCommand(QueryEliminarClientes, conn.MtdAbrirConexion());
            CommAgregaClientes.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            CommAgregaClientes.ExecuteNonQuery();
            conn.MtdCerrarConexion();


        }
    }
}
