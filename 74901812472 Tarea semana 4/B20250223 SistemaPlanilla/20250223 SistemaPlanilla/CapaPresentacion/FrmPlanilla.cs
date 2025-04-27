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
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblSalarioBase_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cboxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSalarioBase.Text = capaLogica.MtdSalario(cboxCargo.Text).ToString("c");

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int contarFilas = dgvDatosPlanilla.Rows.Add();

            double SalarioBase = capaLogica.MtdSalario(cboxCargo.Text);

            dgvDatosPlanilla.Rows[contarFilas].Cells[0].Value = cboxCodigoEmpleado.Text;
            dgvDatosPlanilla.Rows[contarFilas].Cells[1].Value = lblNombre.Text;
            dgvDatosPlanilla.Rows[contarFilas].Cells[2].Value = cboxCargo.Text;
            dgvDatosPlanilla.Rows[contarFilas].Cells[3].Value = cboxMes.Text;
            dgvDatosPlanilla.Rows[contarFilas].Cells[4].Value = lblSalarioBase.Text;
            dgvDatosPlanilla.Rows[contarFilas].Cells[5].Value = txtHorasExtras.Text;
            dgvDatosPlanilla.Rows[contarFilas].Cells[6].Value = capaLogica.MtdHorasExtras(txtHorasExtras.Text);
            //dgvDatosPlanilla.Rows[contarFilas].Cells[7].Value = capaLogica.MtdISR(SalarioBase);
            //dgvDatosPlanilla.Rows[contarFilas].Cells[8].Value = capaLogica.MtdIGSS(SalarioBase);
            //dgvDatosPlanilla.Rows[contarFilas].Cells[9].Value = capaLogica.MtdSalarioNeto(SalarioBase, capaLogica.MtdHorasExtras(txtHorasExtras.Text), capaLogica.MtdISR(SalarioBase), capaLogica.MtdIGSS(SalarioBase)));
            MtdLimpiarCampos();
        }

        private void dgvDatosPlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatosPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ContarFilas;
            ContarFilas = dgvDatosPlanilla.CurrentRow.Index;

            cboxCodigoEmpleado.Text = dgvDatosPlanilla[0,ContarFilas].Value.ToString();
            cboxMes.Text = dgvDatosPlanilla[3,ContarFilas].Value.ToString();
            cboxCargo.Text = dgvDatosPlanilla[2,ContarFilas].Value.ToString();
            txtHorasExtras.Text = dgvDatosPlanilla[5,ContarFilas].Value.ToString();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int ContarFilas;
            ContarFilas = dgvDatosPlanilla.CurrentRow.Index;

            double SalarioBase = capaLogica.MtdSalario(cboxCargo.Text);

            dgvDatosPlanilla.Rows[ContarFilas].Cells[0].Value = cboxCodigoEmpleado.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[1].Value = lblNombre.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[2].Value = cboxCargo.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[3].Value = cboxMes.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[4].Value = lblSalarioBase.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[5].Value = txtHorasExtras.Text;
            dgvDatosPlanilla.Rows[ContarFilas].Cells[6].Value = capaLogica.MtdHorasExtras(txtHorasExtras.Text);
            //dgvDatosPlanilla.Rows[contarFilas].Cells[7].Value = capaLogica.MtdISR(SalarioBase);
            //dgvDatosPlanilla.Rows[contarFilas].Cells[8].Value = capaLogica.MtdIGSS(SalarioBase);
            //dgvDatosPlanilla.Rows[contarFilas].Cells[9].Value = capaLogica.MtdSalarioNeto(SalarioBase, capaLogica.MtdHorasExtras(txtHorasExtras.Text), capaLogica.MtdISR(SalarioBase), capaLogica.MtdIGSS(SalarioBase)));
            MtdLimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboxCodigoEmpleado.Text = "";
            lblNombre.Text = "";
            cboxCargo.Text = "";
            cboxMes.Text = "";
            lblSalarioBase.Text = "";
            txtHorasExtras.Text = "";
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
            lblNombre.Text = "";
            cboxCargo.Text = "";
            cboxMes.Text = "";
            lblSalarioBase.Text = "";
            txtHorasExtras.Text = "";
        }

        public void MtdLimpiarEditar()
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
