using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Propiedad de Numero
        /// </summary>
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value.ToString()); }
        }
        /// <summary>
        /// Convierte un numero binario en numero decimal
        /// </summary>
        /// <param name="binario">Numero binario</param>
        /// <returns>String con el numero decimal obtenido</returns>
        public string BinarioDecimal(string binario)
        {
            int numeroDecimal = 0;
            StringBuilder binarioBuilder = new StringBuilder();
            
            if (!EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    binarioBuilder.Append($"{binario[i]}");
                }

                for (int i = binarioBuilder.Length - 1; i >= 0; i--)
                {
                    if (binarioBuilder[i] == '1')
                    {
                        numeroDecimal += (int)Math.Pow(2, i);
                    }
                }
                return numeroDecimal.ToString();
            }
            else
            {
                return "Valor invalido";
            }            
        }
        /// <summary>
        /// Valida que el numero ingresado sea binario y lo convierte a decimal
        /// en caso de ser posible
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>El numero convertido a decimal si fue exitoso,
        ///          o mensaje de Valor Invalido
        /// </returns>
        public string DecimalBinario(double numero)
        {
            string binario = numero.ToString();
            return DecimalBinario(binario);           
        }
        /// <summary>
        /// Valida que el numero ingresado sea binario y lo convierte a decimal
        /// en caso de ser posible
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>El numero convertido a decimal si fue exitoso,
        ///          o mensaje de Valor Invalido
        /// </returns>
        public string DecimalBinario(string numero)
        {            
            int numDecimal;
            Numero convertir = new Numero(numero);                                   
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder binarioBuilder = new StringBuilder();
            
            if (!EsBinario(numero))
            {
                numDecimal = (int)convertir.numero;
                numDecimal = Math.Abs(numDecimal);
                do
                {
                    //Concateno en un solo string el resto 0 o 1
                    if (numDecimal % 2 == 0)
                    {
                        stringBuilder.Append("0");
                    }
                    else
                    {
                        stringBuilder.Append("1");
                    }
                    //guardo el resultado de la division
                    numDecimal /= 2;

                } while (numDecimal > 0);

                //paso el string a otra variable
                numero = stringBuilder.ToString();
                //invierto el string recorriendolo segun Length
                for (int i = numero.Length - 1; i >= 0; i--)
                {
                    binarioBuilder.Append($"{numero[i]}");
                }
                return binarioBuilder.ToString();
            }
            else
            {
                return "Valor Invalido";
            }

        }
        /// <summary>
        /// Valida que una cadena de caracteres este compuesta solamente por 0 y 1
        /// </summary>
        /// <param name="binario">Cadena a validar</param>
        /// <returns>true si es exitosa, false si falla</returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; ++i)
            {
                if (binario[i] != '0' || binario[i] != '1')
                {
                    return false;
                }               
            }
            return true;
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor de instancia para numeros flotantes de doble precision
        /// </summary>
        /// <param name="numero">Un numero flotante de doble precision</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor de instancia para strings que representen un numero
        /// </summary>
        /// <param name="strNumero">String que representa un numero</param>
        public Numero (string strNumero)
        {
            this.numero = double.Parse(strNumero);
        }        

        ///OPERADORES SOBRECARGADOS
        /// <summary>
        /// Calcula la suma de dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>La suma de los numeros</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Calcula la resta de dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>La resta de los numeros</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Calcula el producto de dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>El producto de los numeros</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Calcula el cociente de dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>El cociente de los numeros</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero== 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        /// <summary>
        /// Comprueba que un valor sea numerico y lo retorna en formato double
        /// </summary>
        /// <param name="strNumero">String del numero a validar</param>
        /// <returns>Numero en formato doble si fue exitoso, sino devuelve 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;

            if(double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }
    }
}
