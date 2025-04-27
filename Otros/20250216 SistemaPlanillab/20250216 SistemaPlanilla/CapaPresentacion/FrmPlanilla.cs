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
        // instancia general

        public FrmPlanilla()
        {
            InitializeComponent();
        }
        // comoo se construlle una intancia 
        private void cboxCodigoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblNombre.Text = capaLogica.MtdNombre(int.Parse(cboxCodigoEmpleado.Text));
            // Realizar un acomvercion de string a int
        }

        private void FrmPlanilla_Load(object sender, EventArgs e)
        {
            lblFecha.Text = capaLogica.MtdFecha(); // diseño para implementar fecha actual 
        }
    }
}
