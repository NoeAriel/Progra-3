﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;


namespace CapaPresentacion
{
    public partial class FrmClientes: Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

        }

        public void MtdConsultarClientes()
        {
            CldClientes cd_clientes = new CldClientes();
            DataTable dtClientes = cd_clientes.MtdConsultarClientes();
            dgvClientes.DataSource = dtClientes;
        }
    }
}
