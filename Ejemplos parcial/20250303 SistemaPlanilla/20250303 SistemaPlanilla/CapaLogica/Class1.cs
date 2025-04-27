using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class Class1
    {
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


        public string MtdFecha()
        {
            string FechaHoy = DateTime.Today.ToString("d");
            return FechaHoy;
        }

        public double MdtSalarioBase(string Cargo)
        {
            double SalarioBase = 0;

            if (Cargo == "Operativo")
            {
                SalarioBase = 4000;
            }
            else if (Cargo == "Supervisor")
            {
                SalarioBase = 10000;
            }
            else if (Cargo == "Jefe")
            {
                SalarioBase = 20000;
            }
            else if (Cargo == "Gerente")
            {
                SalarioBase = 35000;
            }
            else
            {
                SalarioBase = 0;
            }
            return SalarioBase;
        }

        public double MtdHorasExtras(int CantidadHoras)
        {
            double MontoHoras = CantidadHoras * 15;
            return MontoHoras;
        }

        public double MtdIsr(double SalarioBase)
        {
            double Isr = (SalarioBase * 0.05);
            return Isr;
        }

        public double MtdIgss(double SalarioBase)
        {
            double Igss = (SalarioBase * 0.045);
            return Igss;
        }

        public double MtdSalarioNeto(double SalarioBase, double MontoHoras, double MontoIsr, double MontoIgss)
        {
            double SalarioNeto = SalarioBase + MontoHoras - MontoIsr - MontoIgss;
            return SalarioNeto;
        }

    }
}
