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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                CLcalculadora clCalculadora = new CLcalculadora();
                int result = clCalculadora.MtdSumar(int.Parse(txtNum1.Text), int.Parse(txtNum2.Text));
                MessageBox.Show($"El resultado de la suma es:{result}", "Exitoooooo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if(txtNum1.Text == "" ||  txtNum2.Text =="")
                {
                    MessageBox.Show("No se permiten datos en blanco", "ERRORRRRRR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show(ex.StackTrace, "ERRORRRRRR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            

            

            

        }
    }
}
