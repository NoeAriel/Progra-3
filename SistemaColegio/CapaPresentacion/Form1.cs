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
    public partial class Form1 : Form
    {
        Class1 capaLogica = new Class1();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = capaLogica.MtdFecha();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Text = capaLogica.MtdNombreEstudiante(comboBox1.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
