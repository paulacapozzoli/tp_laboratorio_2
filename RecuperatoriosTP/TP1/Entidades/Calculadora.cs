using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static int switchDecimal = 0; //para distinguir decimales de binarios

        /// <summary>
        /// Valida y realiza la operación pedida entre ambos números
        /// </summary>
        /// <param name="num1">Primer número</param>
        /// <param name="num2">Segundo número</param>
        /// <param name="operador">Operador recibido</param>
        /// <returns>Resultado de la operacon en formato double</returns>
        public static double Operar(Numero num1, Numero num2, char operador)
        {
            double resultado=0;           

            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
            
        }
        /// <summary>
        /// Valida que el valor recibido sea + - * o /
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Valor recibido si valida, si no retorna "+"</returns>
        private static string ValidarOperador(char operador)
        {
            if(operador=='+'|| operador == '-' || operador == '*'|| operador == '/')
            {
                return operador.ToString();
            }
            else
            {
                return "+";
            }
        }
    }    
}
