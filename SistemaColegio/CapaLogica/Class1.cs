using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class Class1
    {
        public string MtdNombreEstudiante(string comboBox1)
        {
            string NombreEstudiante = "";

            if (comboBox1 == "7490-24-123")
            {
                NombreEstudiante = "Luis Alberto Perez Donis";
            }
            else if (comboBox1 == "7490-22-5687")
            {
                NombreEstudiante = "Delia Maria Rios Rivas";
            }
            else if (comboBox1 == "7490-23-6548")
            {
                NombreEstudiante = "Juan Pedro Pedroza Argueta";
            }
            else if (comboBox1 == "7490-24-56874")
            {
                NombreEstudiante = "Ligia Julia Mendez Estrada";
            }
            else if (comboBox1 == "7490-22-231")
            {
                NombreEstudiante = "Deonel Farruko Pop Maluma";
            }
            else
            {
                NombreEstudiante = "";
            }


            return NombreEstudiante;
        }

        public string MtdFecha()
        {
            string FechaHoy = DateTime.Today.ToString("d");
            return FechaHoy;
        }
    }
}
