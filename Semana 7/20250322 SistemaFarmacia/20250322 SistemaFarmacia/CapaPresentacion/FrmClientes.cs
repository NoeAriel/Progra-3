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
        CdClientes cd_clientes = new CdClientes();
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

        private void btnGuardar_Click(object sender, EventArgs)
        {

            try
            {
                MtdAgregarClientes(Nombre, Nit, txtTelefono, txtDireccion, cboxEstado, FechaAuditoria, UsuarioAuditoria)
            MessageBox.Show("Cliente agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            
        }
    }
}
