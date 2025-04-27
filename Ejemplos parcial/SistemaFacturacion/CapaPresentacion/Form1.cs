using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblFecha.Text = capaLogica.mtdFecha();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNombreCliente.Text = capaLogica.mtdNombre(cboxNitCliente.Text);
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e, System.Windows.Controls.TextBox textBox2)
        {
            lblPrecio.Text = capaLogica.mtdPrecio(comboBox2.Text).ToString("c");
            
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int ContarFilas;
            ContarFilas = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.RemoveAt(ContarFilas);

            mtdLimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarCampos();
        }

        public void mtdLimpiarCampos()
        {
            cboxNitCliente.Text = "";
            lblNombreCliente.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            lblPrecio.Text = "";
            lblTotal.Text = "";
            lblImpuesto.Text = "";
            lblMonto.Text = "";


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void lblImpuesto_Click(object sender, EventArgs e)
        {

        }

        private void lblMonto_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
           