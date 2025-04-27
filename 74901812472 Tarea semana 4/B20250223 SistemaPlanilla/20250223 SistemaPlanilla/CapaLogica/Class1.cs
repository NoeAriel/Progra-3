using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

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


       // public string MtdSalario(string cboxCargo)
        //{
         //   string Salario = "0";

         //   if (cboxCargo == "Operativo")
         //   {
          //      Salario = "4000";
          //  }
          //  else if (cboxCargo == "Supervisor")
          //  {
          //      Salario = "10000";
          //  }
          //  else if (cboxCargo == "Jefe")
           // {
           //     Salario = "20000";
           // }
           // else if (cboxCargo == "Gerente")
           // {
           //     Salario = "35000";
           // }
            
           // else
           // {
           //     Salario = "0";
           // }


           // return Salario;
       // }

        public double MtdSalario(string cboxCargo)
        {
           double Salario = 0;

            if (cboxCargo == "Operativo")
            {
              Salario = 4000;
           }
           else if (cboxCargo == "Supervisor")
           {
               Salario = 10000;
           }
           else if (cboxCargo == "Jefe")
          {
              Salario = 20000;
          }
          else if (cboxCargo == "Gerente")
          {
              Salario = 35000;
          }

                 else
                 {
                     Salario = 0;
                 }


          return Salario;

        }

        //public string MtdHorasExtras(string txtHorasExtras)
        //{
        //     string horasExtras = txtHorasExtras;
        //
        //     return horasExtras;
        // }

        public int MtdHorasExtras(string txtHorasExtras)
        {
            int horas = int.Parse(txtHorasExtras);

            int horasExtras = int.Parse(txtHorasExtras)*10;

            return horasExtras;
        }






    }
}
