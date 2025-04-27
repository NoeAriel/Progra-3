
/*1. crear conexion bdd*/
/*-------------------------------------------------*/

		using System;
		using System.Collections.Generic;
		using System.Data.SqlClient;
		using System.Data;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;

		namespace CapaDatos
		{
			public  class CD_Conexion_bdd
			{
				private SqlConnection db_conexion = new SqlConnection("Data Source=EMORALES\\SQLEXPRESS;Initial Catalog=db_planilla2;Integrated Security=True;Encrypt=False");

				public SqlConnection MtdAbrirConexion()
				{
					if (db_conexion.State == ConnectionState.Closed)
						db_conexion.Open();
					return db_conexion;
				}

				public SqlConnection MtdCerrarConexion()
				{
					if (db_conexion.State == ConnectionState.Open)
						db_conexion.Close();
					return db_conexion;
				}

			}
		}


/* 2. Consultar */
/*-------------------------------------------------*/
		// Capa Datos
			namespace CapaDatos
			{
				public class CD_Planilla
				{
					public DataTable MtdConsultarClientes()
					{
						CD_Conexion_bdd cd_conexionDB = new CD_Conexion_bdd();

						string QuerySelect = "Select * from tbl_planilla";
						SqlDataAdapter adapter = new SqlDataAdapter(QuerySelect,cd_conexionDB.MtdAbrirConexion());
						DataTable dt_planilla = new DataTable();
						adapter.Fill(dt_planilla);
						return dt_planilla;
					}
				}
			}
				
		// Capa Presentacion
			
			public void MtdMostrarClientes()
			{
				CD_Planilla cd_Planilla = new CD_Planilla();
				DataTable dt_planilla = cd_Planilla.MtdConsultarClientes();
				dgvDatosPlanilla.DataSource = dt_planilla;
			}
			
			private void FrmPlanilla_Load(object sender, EventArgs e)
			{
				MtdMostrarClientes();
			}			


/* 3. Agregar*/
/*-------------------------------------------------*/		
		
	// Capa Datos
	
			public void MtdAgregarClientes(int Codigo, string Nombre, string Cargo, string Mes, double SalarioBase, int HorasExtras, double MontoHoras, double Isr, double Igss, double SalarioNeto, DateTime Fecha)
			{
				CD_Conexion_bdd cd_conexionDB = new CD_Conexion_bdd();

				string Usp_crear = "INSERT INTO tbl_planilla VALUES (@CodigoEmpleado, @Nombre, @Cargo, @Mes, @SalarioBase, @HorasExtras, @MontoHoras, @Isr, @Igss, @SueldoNeto, @Fecha)";
				SqlCommand cmd_InsertarClientes = new SqlCommand(Usp_crear, cd_conexionDB.MtdAbrirConexion());
				cmd_InsertarClientes.Parameters.AddWithValue("@CodigoEmpleado", Codigo);
				cmd_InsertarClientes.Parameters.AddWithValue("@Nombre", Nombre);
				cmd_InsertarClientes.Parameters.AddWithValue("@Cargo", Cargo);
				cmd_InsertarClientes.Parameters.AddWithValue("@Mes", Mes);
				cmd_InsertarClientes.Parameters.AddWithValue("@SalarioBase", SalarioBase);
				cmd_InsertarClientes.Parameters.AddWithValue("@HorasExtras", HorasExtras);
				cmd_InsertarClientes.Parameters.AddWithValue("@MontoHoras", MontoHoras);
				cmd_InsertarClientes.Parameters.AddWithValue("@Isr", Isr);
				cmd_InsertarClientes.Parameters.AddWithValue("@Igss", Igss);
				cmd_InsertarClientes.Parameters.AddWithValue("@SueldoNeto", SalarioNeto);
				cmd_InsertarClientes.Parameters.AddWithValue("@Fecha", Fecha);
				cmd_InsertarClientes.ExecuteNonQuery();


				cd_conexionDB.MtdCerrarConexion();
			}
	
	// Capa Presentacion

			private void btnGuardar_Click(object sender, EventArgs e)
			{
				int codigo = int.Parse(cboxCodigoEmpleado.Text);
				string Nombre = lblNombre.Text;
				string Cargo = cboxCargo.Text;
				string Mes = cboxMes.Text;
				double SalarioBase = cl_planilla.MtdSalarioBase(Cargo);
				int HorasExtras = int.Parse(txtHorasExtras.Text);
				double MontoHorasE = cl_planilla.MtdMontoHoras(HorasExtras);
				double Isr = cl_planilla.MtdIsr(SalarioBase);
				double Igss = cl_planilla.MtdIgss(SalarioBase);
				double SalarioNeto = cl_planilla.MtdSalarioNeto(SalarioBase, MontoHorasE, Isr, Igss);
				DateTime Fecha = DateTime.Parse(cl_planilla.MtdFechaHoy());

				try
				{
					CD_Planilla cd_Planilla = new CD_Planilla();
					cd_Planilla.MtdAgregarClientes(codigo, Nombre, Cargo, Mes, SalarioBase, HorasExtras, MontoHorasE, Isr, Igss, SalarioNeto, Fecha);
					MessageBox.Show("Datos agregados correctamente");
					MtdMostrarClientes();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.StackTrace);
				}
			}


/* 4. Actualizar*/
/*-------------------------------------------------*/
	// Configurar Datagrid
	
		/* AutoSizeColumnMode = AllCell*/
		/* ReadOnly = True*/
		/* SelectionMode = FullRowSelect*/
		
        private void dgvDatosPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboxCodigoEmpleado.Text = dgvDatosPlanilla.SelectedCells[1].Value.ToString();
            cboxMes.Text = dgvDatosPlanilla.SelectedCells[4].Value.ToString();
            cboxCargo.Text = dgvDatosPlanilla.SelectedCells[3].Value.ToString();
            txtHorasExtras.Text = dgvDatosPlanilla.SelectedCells[6].Value.ToString();
            lblPlanilla.Text = dgvDatosPlanilla.SelectedCells[0].Value.ToString();
        }


	// Capa Datos
	
			public void MtdActualizarClientes(int CodigoPlanilla, int Codigo, string Nombre, string Cargo, string Mes, double SalarioBase, int HorasExtras, double MontoHoras, double Isr, double Igss, double SalarioNeto, DateTime Fecha)
			{
				CD_Conexion_bdd cd_conexionDB = new CD_Conexion_bdd();

				string Usp_crear = "UPDATE tbl_planilla SET CodigoEmpleado=@CodigoEmpleado, Nombre=@Nombre, Cargo=@Cargo, Mes=@Mes, SalarioBase=@SalarioBase, HorasExtras=@HorasExtras, MontoHoras=@MontoHoras, Isr=@Isr, Igss=@Igss, SueldoNeto=@SueldoNeto, Fecha=@Fecha WHERE CodigoPlanilla = @CodigoPlanilla";
				SqlCommand cmd_InsertarClientes = new SqlCommand(Usp_crear, cd_conexionDB.MtdAbrirConexion());
				cmd_InsertarClientes.Parameters.AddWithValue("@CodigoPlanilla", CodigoPlanilla);
				cmd_InsertarClientes.Parameters.AddWithValue("@CodigoEmpleado", Codigo);
				cmd_InsertarClientes.Parameters.AddWithValue("@Nombre", Nombre);
				cmd_InsertarClientes.Parameters.AddWithValue("@Cargo", Cargo);
				cmd_InsertarClientes.Parameters.AddWithValue("@Mes", Mes);
				cmd_InsertarClientes.Parameters.AddWithValue("@SalarioBase", SalarioBase);
				cmd_InsertarClientes.Parameters.AddWithValue("@HorasExtras", HorasExtras);
				cmd_InsertarClientes.Parameters.AddWithValue("@MontoHoras", MontoHoras);
				cmd_InsertarClientes.Parameters.AddWithValue("@Isr", Isr);
				cmd_InsertarClientes.Parameters.AddWithValue("@Igss", Igss);
				cmd_InsertarClientes.Parameters.AddWithValue("@SueldoNeto", SalarioNeto);
				cmd_InsertarClientes.Parameters.AddWithValue("@Fecha", Fecha);
				cmd_InsertarClientes.ExecuteNonQuery();

				cd_conexionDB.MtdCerrarConexion();
			}
	
	// Capa Presentación	

			private void btnEditar_Click(object sender, EventArgs e)
			{
				int codigo = int.Parse(cboxCodigoEmpleado.Text);
				string Nombre = lblNombre.Text;
				string Cargo = cboxCargo.Text;
				string Mes = cboxMes.Text;
				double SalarioBase = cl_planilla.MtdSalarioBase(Cargo);
				int HorasExtras = int.Parse(txtHorasExtras.Text);
				double MontoHorasE = cl_planilla.MtdMontoHoras(HorasExtras);
				double Isr = cl_planilla.MtdIsr(SalarioBase);
				double Igss = cl_planilla.MtdIgss(SalarioBase);
				double SalarioNeto = cl_planilla.MtdSalarioNeto(SalarioBase, MontoHorasE, Isr, Igss);
				DateTime Fecha = DateTime.Parse(cl_planilla.MtdFechaHoy());
				int CodigoPlanilla = int.Parse(lblPlanilla.Text);


				try
				{
					CD_Planilla cd_Planilla = new CD_Planilla();
					cd_Planilla.MtdActualizarClientes(CodigoPlanilla, codigo, Nombre, Cargo, Mes, SalarioBase, HorasExtras, MontoHorasE, Isr, Igss, SalarioNeto, Fecha);
					MessageBox.Show("Datos actualizado correctamente");
					MtdMostrarClientes();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.StackTrace);
				}
			}

/* 5. Eliminar*/
/*-------------------------------------------------*/
	// Capa Datos
	
			public void MtdEliminarClientes(int CodigoPlanilla)
			{
				CD_Conexion_bdd cd_conexionDB = new CD_Conexion_bdd();

				string Usp_crear = "DELETE FROM tbl_planilla WHERE CodigoPlanilla = @CodigoPlanilla";
				SqlCommand cmd_InsertarClientes = new SqlCommand(Usp_crear, cd_conexionDB.MtdAbrirConexion());
				cmd_InsertarClientes.Parameters.AddWithValue("@CodigoPlanilla", CodigoPlanilla);
				cmd_InsertarClientes.ExecuteNonQuery();

				cd_conexionDB.MtdCerrarConexion();
			}
	
	// Capa Presentacion
	
			private void btnEliminar_Click(object sender, EventArgs e)
			{
				int CodigoPlanilla = int.Parse(lblPlanilla.Text);

				try
				{
					CD_Planilla cd_Planilla = new CD_Planilla();
					cd_Planilla.MtdEliminarClientes(CodigoPlanilla);
					MessageBox.Show("Datos eliminados correctamente");
					MtdMostrarClientes();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.StackTrace);
				}
			}
		
