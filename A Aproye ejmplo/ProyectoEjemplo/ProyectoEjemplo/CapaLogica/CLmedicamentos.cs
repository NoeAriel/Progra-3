using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLmedicamentos
    {
        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public double MtdPrecioMedicamento(string Descripcion)
        {
            if (Descripcion == "Jarabe") return 150;
            else if (Descripcion == "Pastilla") return 100;
            else if (Descripcion == "Suero") return 50;
            else if (Descripcion == "Vitaminas") return 125;
            else if (Descripcion == "Cremas") return 75;
            else return 0;
        }
    }
}
