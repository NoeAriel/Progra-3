using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmMedicamentos : Form
    {

        CLmedicamentos cl_medicamentos = new CLmedicamentos();
        CDmedicamentos cd_medicamentos = new CDmedicamentos();

        public FrmMedicamentos()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cboxDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxDescripcion.Text))
            {
                MessageBox.Show("Seleccione una descripcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtPrecio.Text = cl_medicamentos.MtdPrecioMedicamento(cboxDescripcion.Text).ToString("c");
            }
        }


        private void MtdMostrarListaProveedores()
        {
            var ListaProveedores = cd_medicamentos.MtdListaProveedores();

            foreach (var proveedor in ListaProveedores)
            {
                cboxCodigoProveedor.Items.Add(proveedor);
            }

            cboxCodigoProveedor.DisplayMember = "Text";
            cboxCodigoProveedor.ValueMember = "Value";
        }

        private void MtdMostrarListaCategorias()
        {
            
            var ListaCategorias = cd_medicamentos.MtdListarCategorias();

            foreach (var Categorias in ListaCategorias)
            {
                cboxCodigoCategoria.Items.Add(Categorias);
            }

            cboxCodigoCategoria.DisplayMember = "Text";
            cboxCodigoCategoria.ValueMember = "Value";
        }

        private void MtdConsultarMedicamentos()
        {
            DataTable Dt = cd_medicamentos.MtdConsultarMedicamentos();
            dgvMedicamentos.DataSource = Dt;
        }


        private void FrmMedicamentos_Load(object sender, EventArgs e)
        {
            lblFecha.Text = cl_medicamentos.MtdFechaHoy().ToString();
            MtdMostrarListaProveedores();
            MtdConsultarMedicamentos();
            MtdMostrarListaCategorias();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxDescripcion.Text) || string.IsNullOrEmpty(cboxUnidadMedida.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtStock.Text) ||
                string.IsNullOrEmpty(DtpFechaVencimiento.Text) || string.IsNullOrEmpty(cboxCodigoCategoria.Text) || string.IsNullOrEmpty(cboxCodigoProveedor.Text) || string.IsNullOrEmpty(cboxEstado.Text))
            {
                MessageBox.Show("Favor ingresar todos los datos en pantalla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string Descripcion = cboxDescripcion.Text;
                    string UnidadMedida = cboxUnidadMedida.Text;
                    double Precio = cl_medicamentos.MtdPrecioMedicamento(Descripcion);
                    double Stock = double.Parse(txtStock.Text);
                    DateTime FechaVencimiento = DtpFechaVencimiento.Value;
                    int CodigoCategoria = int.Parse(cboxCodigoCategoria.Text.Split('-')[0].Trim());
                    int CodigoProveedor = int.Parse(cboxCodigoProveedor.Text.Split('-')[0].Trim());
                    string Estado = cboxEstado.Text;
                    DateTime FechaAuditoria = cl_medicamentos.MtdFechaHoy();
                    string UsuarioAuditoria = "Emorales";

                    cd_medicamentos.MtdAgregarMedicamentos(Descripcion, UnidadMedida, Precio, Stock, FechaVencimiento, CodigoCategoria, CodigoProveedor, Estado, FechaAuditoria, UsuarioAuditoria);
                    MessageBox.Show("Medicamento agregado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarMedicamentos();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var FilaSeleccionada = dgvMedicamentos.SelectedRows[0];

            if (FilaSeleccionada.Index == dgvMedicamentos.RowCount - 1)
            {
                MessageBox.Show("Seleccione una fila con datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtCodigoMedicamento.Text = dgvMedicamentos.SelectedCells[0].Value.ToString();
                cboxDescripcion.Text = dgvMedicamentos.SelectedCells[1].Value.ToString();
                cboxUnidadMedida.Text = dgvMedicamentos.SelectedCells[2].Value.ToString();
                txtPrecio.Text = dgvMedicamentos.SelectedCells[3].Value.ToString();
                txtStock.Text = dgvMedicamentos.SelectedCells[4].Value.ToString();
                DtpFechaVencimiento.Text = dgvMedicamentos.SelectedCells[5].Value.ToString();

                int CodigoCategoria = (int)dgvMedicamentos.SelectedCells[6].Value;
                cboxCodigoCategoria.Text = cd_medicamentos.MtdListarCategoriasDgv(CodigoCategoria);

                int CodigoProveedor = (int)dgvMedicamentos.SelectedCells[7].Value;
                cboxCodigoProveedor.Text = cd_medicamentos.MtdListaProveedoresDgv(CodigoProveedor);

                    cboxEstado.Text = dgvMedicamentos.SelectedCells[8].Value.ToString();

                }
            }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxDescripcion.Text) || string.IsNullOrEmpty(cboxUnidadMedida.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtStock.Text) ||
                string.IsNullOrEmpty(DtpFechaVencimiento.Text) || string.IsNullOrEmpty(cboxCodigoCategoria.Text) || string.IsNullOrEmpty(cboxCodigoProveedor.Text) || string.IsNullOrEmpty(cboxEstado.Text))
            {
                MessageBox.Show("Favor ingresar todos los datos en pantalla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int CodigoMedicamento = (int.Parse(txtCodigoMedicamento.Text));
                    string Descripcion = cboxDescripcion.Text;
                    string UnidadMedida = cboxUnidadMedida.Text;
                    double Precio = cl_medicamentos.MtdPrecioMedicamento(Descripcion);
                    double Stock = double.Parse(txtStock.Text);
                    DateTime FechaVencimiento = DtpFechaVencimiento.Value;
                    int CodigoCategoria = int.Parse(cboxCodigoCategoria.Text.Split('-')[0].Trim());
                    int CodigoProveedor = int.Parse(cboxCodigoProveedor.Text.Split('-')[0].Trim());
                    string Estado = cboxEstado.Text;
                    DateTime FechaAuditoria = cl_medicamentos.MtdFechaHoy();
                    string UsuarioAuditoria = "Emorales";

                    cd_medicamentos.MtdActualizarMedicamentos(CodigoMedicamento, Descripcion, UnidadMedida, Precio, Stock, FechaVencimiento, CodigoCategoria, CodigoProveedor, Estado, FechaAuditoria, UsuarioAuditoria);
                    MessageBox.Show("Medicamento actualizado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarMedicamentos();
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
            if (string.IsNullOrEmpty(txtCodigoMedicamento.Text))
            {
                MessageBox.Show("Favor seleccionar medicamento a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int CodigoMedicamento = (int.Parse(txtCodigoMedicamento.Text));

                    cd_medicamentos.MtdEliminarMedicamentos(CodigoMedicamento);
                    MessageBox.Show("Medicamento eliminado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarMedicamentos();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoMedicamento.Text = "";
            cboxDescripcion.Text = "";
            cboxUnidadMedida.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            DtpFechaVencimiento.Text = "";
            cboxCodigoCategoria.Text="";
            cboxCodigoProveedor.Text = "";
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

        private void cboxCodigoCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboxCodigoProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
