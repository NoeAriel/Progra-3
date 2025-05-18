using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDproveedores
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarProveedores()
        {
            string QueryConsultar = "Select * from tbl_proveedores";
            SqlDataAdapter SqlAdap = new SqlDataAdapter(QueryConsultar, cd_conexion.MtdAbrirConexion());
            DataTable Dt = new DataTable();
            SqlAdap.Fill(Dt);
            cd_conexion.MtdCerrarConexion();
            return Dt;
        }

        public void MtdAgregarProveedores(string Nombre, string Nit, int Telefono, string Email, string Estado, DateTime FechaAuditoria, string UsuarioAuditoria)
        {
            string QueryAgregar = "Insert into tbl_proveedores (Nombre, Nit, Telefono, Email, Estado, FechaAuditoria, UsuarioAuditoria) values (@Nombre, @Nit, @Telefono, @Email, @Estado, @FechaAuditoria, @UsuarioAuditoria)";
            SqlCommand cmd = new SqlCommand(QueryAgregar, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Nit", Nit);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            cmd.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarProveedores(int CodigoProveedor, string Nombre, string Nit, int Telefono, string Email, string Estado, DateTime FechaAuditoria, string UsuarioAuditoria)
        {
            string QueryActualizar = "Update tbl_proveedores set Nombre=@Nombre, Nit=@Nit, Telefono=@Telefono, Email=@Email, Estado=@Estado, FechaAuditoria=@FechaAuditoria, UsuarioAuditoria=@UsuarioAuditoria where CodigoProveedor=@CodigoProveedor";
            SqlCommand cmd = new SqlCommand(QueryActualizar, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Nit", Nit);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            cmd.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarProveedores(int CodigoProveedor)
        {
            string QueryEliminar = "Delete from tbl_proveedores where CodigoProveedor=@CodigoProveedor";
            SqlCommand cmd = new SqlCommand(QueryEliminar, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
