using CapaDatos;
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
    public partial class FrmUsuarios : Form
    {
        CD_Proveedores cd_proveedores = new CD_Proveedores();
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            MtdMostrarUsuarios();
        }

        public void MtdMostrarUsuarios()
        {
            DataTable dtUsuarios = new DataTable();
            dtUsuarios = cd_proveedores.MtdMostrarProveedores();
            dgvDatosPlanilla.DataSource = dtUsuarios;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int CodigoCliente = int.Parse(txtCodigoCliente.Text);
            //Copiar el boton agregar

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
