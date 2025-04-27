using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLcalculadora
    {
        public int MtdSumar(int num1, int num2)
        { 
              int resultado = 0;
              resultado = num1 + num2;            
              return resultado;
        }

        public int MtdRestar(int num1, int num2)
        {
            int resultado = 0;
            resultado = num1 - num2;
            return resultado;
        }

        public int MtdMultiplicar(int num1, int num2)
        {
            int resultado = 0;
            resultado = num1 * num2;
            return resultado;
        }

        public int MtdDividir(int num1, int num2)
        {
            int resultado = 0;
            resultado = num1 / num2;
            return resultado;
        }
    }
}
