using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida y realiza la operacion pedida entre dos numeros
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador">Operador del calculo</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            char operadorC;

            char.TryParse(operador, out operadorC);

            switch (ValidarOperador(operadorC))
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
        /// Valida que el operador recibido sea + - * o / 
        /// </summary>
        /// <param name="operador">Operador recibido</param>
        /// <returns>Operador si valida, si no valida devuelve "+"</returns>
        private static string ValidarOperador(char operador)
        {
            if(operador == '+' || operador == '-'|| operador == '*' || operador == '/')
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
