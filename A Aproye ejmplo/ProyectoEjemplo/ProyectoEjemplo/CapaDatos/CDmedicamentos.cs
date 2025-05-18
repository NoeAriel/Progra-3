using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class CDmedicamentos
    {
        CDconexion cd_conexion = new CDconexion();

        public List<dynamic> MtdListarCategorias()
        {
            List<dynamic> ListaCategorias = new List<dynamic>();
            string QueryListaCategorias = "Select CodigoCategoria, Nombre from tbl_categorias";
            SqlCommand cmd = new SqlCommand(QueryListaCategorias, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaCategorias.Add(new
                {
                    Value = reader["CodigoCategoria"],
                    Text = $"{reader["CodigoCategoria"]} - {reader["Nombre"]}"
                });
            }
            cd_conexion.MtdCerrarConexion();
            return ListaCategorias;
        }


        public string MtdListarCategoriasDgv(int CodigoCategoria)
        {
            string resultado = string.Empty;
            string QueryListaProveedores = "Select CodigoCategoria, Descripcion from tbl_categorias where CodigoCategoria=@CodigoCategoria";
            SqlCommand cmd = new SqlCommand(QueryListaProveedores, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoCategoria", CodigoCategoria);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) 
            {
                string codigo = reader["CodigoCategoria"].ToString();
                string nombre = reader["Descripcion"].ToString();
                resultado = $"{codigo} - {nombre}";
            }
            else
            {
                resultado = string.Empty;
            }
                cd_conexion.MtdCerrarConexion();
            return resultado;
        }


        public List<dynamic> MtdListaProveedores()
        {
            List<dynamic> ListaProveedores = new List<dynamic>();
            string QueryListaProveedores = "Select CodigoProveedor, Nombre from tbl_proveedores";
            SqlCommand cmd = new SqlCommand(QueryListaProveedores, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaProveedores.Add(new
                {
                    Value = reader["CodigoProveedor"],
                    Text = $"{reader["CodigoProveedor"]} - {reader["Nombre"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaProveedores;
        }

        public string MtdListaProveedoresDgv(int CodigoProveedor)
        {
            string resultado = string.Empty;
            string QueryListaProveedores = "Select CodigoProveedor, Nombre from tbl_proveedores where CodigoProveedor=@CodigoProveedor";
            SqlCommand cmd = new SqlCommand(QueryListaProveedores, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
            string codigo = reader["CodigoProveedor"].ToString();
            string nombre = reader["Nombre"].ToString();
            resultado = $"{codigo} - {nombre}";
            }
            else
            {
                resultado = string.Empty;
            }

            cd_conexion.MtdCerrarConexion();
            return resultado;
        }

        public DataTable MtdConsultarMedicamentos()
        {
            string QueryConsultarMedicamentos = "Select * from tbl_medicamentos";
            SqlDataAdapter Adapter = new SqlDataAdapter(QueryConsultarMedicamentos, cd_conexion.MtdAbrirConexion());
            DataTable Dt = new DataTable();
            Adapter.Fill(Dt);
            cd_conexion.MtdCerrarConexion();
            return Dt;
        }

        public void MtdAgregarMedicamentos(string Descripcion, string UnidadMedida, double Precio, double Stock, DateTime FechaVencimiento, int CodigoCategoria, int CodigoProveedor, string Estado, DateTime FechaAuditoria, string UsuarioAuditoria)
        {
            string QueryAgregarMedicamentos = "Insert into tbl_medicamentos(Descripcion,UnidadMedida,Precio, Stock, FechaVencimiento, CodigoCategoria, CodigoProveedor, Estado, FechaAuditoria, UsuarioAuditoria) values (@Descripcion, @UnidadMedida, @Precio, @Stock, @FechaVencimiento, @CodigoCategoria, @CodigoProveedor, @Estado, @FechaAuditoria, @UsuarioAuditoria)";
            SqlCommand cmd = new SqlCommand(QueryAgregarMedicamentos, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
            cmd.Parameters.AddWithValue("@UnidadMedida", UnidadMedida);
            cmd.Parameters.AddWithValue("@Precio", Precio);
            cmd.Parameters.AddWithValue("@Stock", Stock);
            cmd.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
            cmd.Parameters.AddWithValue("@CodigoCategoria", CodigoCategoria);
            cmd.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            cmd.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarMedicamentos(int CodigoMedicamento, string Descripcion, string UnidadMedida, double Precio, double Stock, DateTime FechaVencimiento, int CodigoCategoria, int CodigoProveedor, string Estado, DateTime FechaAuditoria, string UsuarioAuditoria)
        {
            string QueryActualizarMedicamentos = "Update tbl_medicamentos set Descripcion=@Descripcion, UnidadMedida=@UnidadMedida, Precio=@Precio, Stock=@Stock, FechaVencimiento=@FechaVencimiento, CodigoCategoria=@CodigoCategoria, CodigoProveedor=@CodigoProveedor, Estado=@Estado, FechaAuditoria=@FechaAuditoria, UsuarioAuditoria=@UsuarioAuditoria where CodigoMedicamento=@CodigoMedicamento";
            SqlCommand cmd = new SqlCommand(QueryActualizarMedicamentos, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoMedicamento", CodigoMedicamento);
            cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
            cmd.Parameters.AddWithValue("@UnidadMedida", UnidadMedida);
            cmd.Parameters.AddWithValue("@Precio", Precio);
            cmd.Parameters.AddWithValue("@Stock", Stock);
            cmd.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
            cmd.Parameters.AddWithValue("@CodigoCategoria", CodigoCategoria);
            cmd.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            cmd.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarMedicamentos(int CodigoMedicamento)
        {
            string QueryEliminarMedicamentos = "Delete tbl_medicamentos where CodigoMedicamento=@CodigoMedicamento";
            SqlCommand cmd = new SqlCommand(QueryEliminarMedicamentos, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoMedicamento", CodigoMedicamento);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

    }
}
