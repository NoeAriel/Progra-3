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

namespace CapaPresentacion
{
    public partial class FrmPlanilla : Form
    {
        Class1 capaLogica = new Class1();


        public FrmPlanilla()
        {
            InitializeComponent();


        }

        private void cboxCodigoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNombre.Text = capaLogica.MtdNombre(int.Parse(cboxCodigoEmpleado.Text));


        }

        private void FrmPlanilla_Load(object sender, EventArgs e)
        {
            lblFecha.Text = capaLogica.MtdFecha();
            MtdLimpiarCampos();
            lblFecha.Text = "";
        }

        private void cboxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSalarioBase.Text = capaLogica.MdtSalarioBase(cboxCargo.Text).ToString("c");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int ContarFilas = dgvDatosPlanilla.Rows.Add();

            double SalarioBase = capaLogica.MdtSalarioBase(cboxCargo.Text);
            double MontoHoras= capaLogica.MtdHorasExtras(int.Parse(txtHorasExtras.Text));
            double MontIsr = capaLogica.MtdIsr(SalarioBase); 
            double MontoIgss = capaLogica.MtdIgss(SalarioBase);
            double MontoSalarioNeto = capaLogica.MtdSalarioNeto(SalarioBase, MontoHoras, MontIsr, MontoIgss);

            dgvDatosPlanilla.Rows[ContarFilas].Cells[0].Value = cboxCodigoEmpleado.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[1].Value = lblNombre.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[2].Value = cboxCargo.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[3].Value = cboxMes.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[4].Value = lblSalarioBase.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[5].Value = txtHorasExtras.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[6].Value = MontoHoras;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[7].Value = MontIsr;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[8].Value = MontoIgss;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[9].Value = MontoSalarioNeto;

            MtdLimpiarCampos();
        }

        private void dgvDatosPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ContarFilas;
            ContarFilas = dgvDatosPlanilla.CurrentRow.Index;

            cboxCodigoEmpleado.Text = dgvDatosPlanilla[0, ContarFilas].Value.ToString();
            cboxMes.Text = dgvDatosPlanilla[3, ContarFilas].Value.ToString();
            cboxCargo.Text = dgvDatosPlanilla[2, ContarFilas].Value.ToString();
            txtHorasExtras.Text = dgvDatosPlanilla[5, ContarFilas].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int ContarFilas;
            ContarFilas = dgvDatosPlanilla.CurrentRow.Index;

            double SalarioBase = capaLogica.MdtSalarioBase(cboxCargo.Text);
            double MontoHoras = capaLogica.MtdHorasExtras(int.Parse(txtHorasExtras.Text));
            double MontIsr = capaLogica.MtdIsr(SalarioBase);
            double MontoIgss = capaLogica.MtdIgss(SalarioBase);
            double MontoSalarioNeto = capaLogica.MtdSalarioNeto(SalarioBase, MontoHoras, MontIsr, MontoIgss);

            dgvDatosPlanilla.Rows[ContarFilas].Cells[0].Value = cboxCodigoEmpleado.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[1].Value = lblNombre.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[2].Value = cboxCargo.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[3].Value = cboxMes.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[4].Value = lblSalarioBase.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[5].Value = txtHorasExtras.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[6].Value = MontoHoras;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[7].Value = MontIsr;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[8].Value = MontoIgss;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[9].Value = MontoSalarioNeto;

            MtdLimpiarEditar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int ContarFilas;
            ContarFilas = dgvDatosPlanilla.CurrentRow.Index;
            dgvDatosPlanilla.Rows.RemoveAt(ContarFilas);

            MtdLimpiarCampos();

        }

        public void MtdLimpiarCampos()
        {
            cboxCodigoEmpleado.Text = "";
            cboxCargo.Text = "";
            cboxMes.Text = "";
            txtHorasExtras.Clear();
            lblSalarioBase.Text = "";
            lblNombre.Text = "";
        }
        public void MtdLimpiarEditar()
        {
            cboxCodigoEmpleado.Text = "";
            lblNombre.Text = "";
            cboxCargo.Text = "";
            cboxMes.Text = "";
            txtHorasExtras.Clear();
            lblSalarioBase.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
