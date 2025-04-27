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

            if (NitCliente == "54355-4")
            {
                NombreCliente = "Maria Luisa Contreras donis";
            }
            else if (NitCliente == "22355-2")
            {
                NombreCliente = "Juan alberto Perez Duarte";
            }
            else if (NitCliente == "55483-7")
            {
                NombreCliente = "Joselyn Dalila Cruz Velasquez";
            }
            else if (NitCliente == "46876-4")
            {
                NombreCliente = "Nolberto José Paniagua Lopez";
            }
            else if (NitCliente == "57789-7")
            {
                NombreCliente = "Edgar pablo Flores Navas";
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

        public double mtdPrecio(string producto)
        {
            double precio = 0;

            if (producto == "Computadora")
            {
                precio = 15000;
            }
            else if (producto == "Telefono")
            {
                precio = 10000;
            }
            else if (producto == "Impresora")
            {
                precio = 4500;
            }
            else if (producto == "Reloj")
            {
                precio = 1200;
            }
            else if (producto == "Cañonera")
            {
                precio = 7500;
            }
            else
            {
                precio = 0;
            }

            return precio;
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
