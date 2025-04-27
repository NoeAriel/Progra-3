using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class Class1
    {
        public string mtdNombre (string NitCliente)
        { 
            string NombreCliente = "";

            if (NitCliente == "25650-0601")
            {
                NombreCliente = "Juan Velásquez";
            }
            else if (NitCliente == "25650-0602")
            {
                NombreCliente = "Dinora Herrarte";
            }
            else if (NitCliente == "25650-0603")
            {
                NombreCliente = "Pedro Molina";
            }
            else if (NitCliente == "25650-0604")
            {
                NombreCliente = "Ester Marroquín";
            }
            else if (NitCliente == "25650-0605")
            {
                NombreCliente = "Daniel Osorio";
            }
            else
            {
                NombreCliente = "";
            }

            return NombreCliente;
        }

        public string mtdFecha()
        {
            string FechaHoy = DateTime.Today.ToString("d");
            return FechaHoy;
        }

        public double mtdPrecio(double producto)
        {
            double porcentaje = 0;

            if (producto <= 1000 )
            {
                porcentaje = 1;
            }
            else if (producto <=3000 )
            {
                porcentaje = 2;
            }
            else if (producto <=5000 )
            {
                porcentaje = 3;
            }
            else if (producto > 5000)
            {
                porcentaje = 5;
            }
           // else if (producto == "Cañonera")
            //{
            //    precio = 7500;
            //}
            else
            {
                porcentaje = 0;
            }

            return porcentaje;
        }

        public double mtdTotal(int cantidad, double precio)
        {
            double total = cantidad * precio;
            return total;
        }

       // public string mtdNombre(System.Windows.Forms.ComboBox cboxNitCliente)
       // {
       //     throw new NotImplementedException();
        //}
    }
}
