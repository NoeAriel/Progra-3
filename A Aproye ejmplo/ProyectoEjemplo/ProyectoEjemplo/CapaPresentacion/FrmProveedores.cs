using CapaDatos;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class FrmProveedores : Form
    {

        CDproveedores cd_proveedores = new CDproveedores();
        CLproveedores cl_proveedores = new CLproveedores();

        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            lblFecha.Text = cl_proveedores.MtdFechaHoy().ToString("d");
            MtdConsultarProveedores();
        }
        private void MtdConsultarProveedores()
        {
            DataTable DtProveedores = cd_proveedores.MtdConsultarProveedores();
            dgvProveedores.DataSource = DtProveedores;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtNit.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(cboxEstado.Text))
            {
                MessageBox.Show("Favor completar formulario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Nombre = txtNombre.Text;
                string Nit = txtNit.Text;
                int Telefono = int.Parse(txtTelefono.Text);
                string Email = txtEmail.Text;
                string Estado = cboxEstado.Text;
                DateTime FechaAuditoria = cl_proveedores.MtdFechaHoy();
                string UsuarioAuditoria = "Emorales";

                try
                {
                    cd_proveedores.MtdAgregarProveedores(Nombre, Nit, Telefono, Email, Estado, FechaAuditoria, UsuarioAuditoria);
                    MessageBox.Show("Datos agregados correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarProveedores();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var FilaSeleccionada = dgvProveedores.SelectedRows[0];

            if (FilaSeleccionada.Index == dgvProveedores.Rows.Count - 1)
            {
                MessageBox.Show("Seleccione una fila con datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtCodigoProveedor.Text = dgvProveedores.SelectedCells[0].Value.ToString();
                txtNombre.Text = dgvProveedores.SelectedCells[1].Value.ToString();
                txtNit.Text = dgvProveedores.SelectedCells[2].Value.ToString();
                txtTelefono.Text = dgvProveedores.SelectedCells[3].Value.ToString();
                txtEmail.Text = dgvProveedores.SelectedCells[4].Value.ToString();
                cboxEstado.Text = dgvProveedores.SelectedCells[5].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoProveedor.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtNit.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(cboxEstado.Text))
            {
                MessageBox.Show("Favor completar formulario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int CodigoProveedor = int.Parse(txtCodigoProveedor.Text);
                string Nombre = txtNombre.Text;
                string Nit = txtNit.Text;
                int Telefono = int.Parse(txtTelefono.Text);
                string Email = txtEmail.Text;
                string Estado = cboxEstado.Text;
                DateTime FechaAuditoria = cl_proveedores.MtdFechaHoy(); ;
                string UsuarioAuditoria = "Emorales";

                try
                {
                    cd_proveedores.MtdActualizarProveedores(CodigoProveedor, Nombre, Nit, Telefono, Email, Estado, FechaAuditoria, UsuarioAuditoria);
                    MessageBox.Show("Datos actualizados correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarProveedores();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoProveedor.Text))
            {
                MessageBox.Show("Favor seleccionar fila a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int CodigoProveedor = int.Parse(txtCodigoProveedor.Text);

                try
                {
                    cd_proveedores.MtdEliminarProveedores(CodigoProveedor);
                    MessageBox.Show("Dato eliminado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarProveedores();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void MtdLimpiarCampos()
        {
            txtCodigoProveedor.Text = "";
            txtNombre.Text = "";
            txtNit.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            cboxEstado.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
