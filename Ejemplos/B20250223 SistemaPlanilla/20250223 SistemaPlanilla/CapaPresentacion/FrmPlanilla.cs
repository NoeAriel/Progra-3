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
            lblSalarioBase.Text = capaLogica.MtdSalario(cboxCargo.Text);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
