using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class Class1
    {
        // Crear metodos Nombre
        // public 
        public string MtdNombre (int CodigoEmpleado)
        {
            string NombreEmpleado = "";

            if (CodigoEmpleado == 1)
            {
                NombreEmpleado = "Juan Manuel Lopez Diaz";
            }
            else if (CodigoEmpleado == 2)
            {
                NombreEmpleado="Luis Felipe Noria Perez";
            }
            else if(CodigoEmpleado == 3)
            {
                NombreEmpleado = "Derik Pedro Mulul Rosales";
            } else if (CodigoEmpleado == 4)
            {
                NombreEmpleado = "Fátima Lis Lima Moreira";
            }
            else if (CodigoEmpleado == 5)
                {
                NombreEmpleado = "Maria Angel Soc Flores";
            }
            else
            {
                NombreEmpleado = "";
            }


            return NombreEmpleado;
        }

        // creacion de metodo FechaHoy
        public string MtdFecha()
        {
            string FechaHoy = DateTime.Today.ToString("d");
            return FechaHoy;
        }
    }
}
