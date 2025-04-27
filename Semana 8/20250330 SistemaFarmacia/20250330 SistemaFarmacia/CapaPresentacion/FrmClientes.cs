using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class FrmClientes: Form
    {
        CD_Clientes cd_clientes = new CD_Clientes();   
        CL_Clientes cl_clientes = new CL_Clientes();

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            MtdMostrarClientes();
        }

        public void MtdMostrarClientes()
        {
            DataTable dtClientes = new DataTable();
            dtClientes = cd_clientes.MtdMostrarClientes();
            dgvDatosPlanilla.DataSource = dtClientes;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = txtNombre.Text;
                string Nit = txtNit.Text;
                int Telefono = int.Parse(txtTelefono.Text);
                string Direccion = txtDireccion.Text;
                string Estado = cboxEstado.Text;
                DateTime FechaAuditoria = cl_clientes.MtdFechaHoy();
                string UsuarioAuditoria = "Emorales";

                cd_clientes.MtdAgregarClientes(Nombre, Nit, Telefono, Direccion, Estado, FechaAuditoria, UsuarioAuditoria);
                MessageBox.Show("Cliente agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }



        //Configurar Datagrid
        /* AutoSizeColumnMode = AllCell*/
        /* ReadOnly = True*/
        /* SelectionMode = FullRowSelect*/
        private void dgvDatosPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // txtCodigoCliente.Text=dgvDatosPlanilla.Select
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //mtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Copiar el try catch del boton editar.
        }
    }
}
