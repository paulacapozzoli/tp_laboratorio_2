using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;//Atributo privado
        
        /// <summary>
        /// Propiedad de clase Numero
        /// </summary>        
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value.ToString());
            }
        }

        #region /// Conversores ///

        /// <summary>
        /// Valida que el valor recibido sea binario y lo convierte a decimal
        /// </summary>
        /// <param name="binario">Valor recibido en formato string</param>
        /// <returns> Valor convertido a decimal en formato string,
        ///           si falla retorna "Valor inválido"
        ///</returns>
        public string BinarioDecimal(string binario)
        {            
            int intDecimal= 0;
            StringBuilder binarioBuilder = new StringBuilder();

            if (!EsBinario(binario))
            {
                return "Valor inválido";                
            }
            else
            {
                //Invierto el string binario, para que su posiciones coincidan con i
                for(int i = binario.Length - 1; i >= 0; i--)
                {
                    binarioBuilder.Append(binario[i]);                   
                }

                //Recorro el string invertido, y calculo el decimal acumulando las potencias de 2 según posición
                for (int i = 0 ; i <binarioBuilder.Length; i++)
                {
                    if (binarioBuilder[i] != '0')
                    {
                        intDecimal += (int)Math.Pow(2, i);
                    }
                }
                return intDecimal.ToString();                
            }
        }
        /// <summary>
        /// Convierte el valor recibido a binario
        /// </summary>
        /// <param name="numero">Valor recibido en formato double</param>
        /// <returns> Valor convertido a binario en formato string,
        ///           si falla retorna "Valor inválido"
        /// </returns>
        public string DecimalBinario(double numero)
        {
            int absoluto;
            int intDecimal;            
            Numero convertir = new Numero(numero);
            StringBuilder invertido = new StringBuilder();
            StringBuilder decimalBuilder = new StringBuilder();            

            absoluto = (int)convertir.numero;
            intDecimal = Math.Abs(absoluto);

            do
            {
                //Construyo el string segun el resto del valor dividido por 2
                if (intDecimal % 2 == 0)
                {
                    decimalBuilder.Append("0");//si el resto es 0, escribo 0
                }
                else
                {
                    decimalBuilder.Append("1");//si el resto es 1, escribo 1
                }
                intDecimal /= 2;//Divido el valor por 2 para volver a iterar

            } while ( intDecimal > 0);

            //Invierto el string para que el resultado binario quede en el orden correcto
            for(int i = decimalBuilder.Length - 1; i >=0 ; i--)
            {
                invertido.Append(decimalBuilder[i]);
            }
            return invertido.ToString();
        }
        /// <summary>
        /// Convierte el valor recibido a binario
        /// </summary>
        /// <param name="numero">Valor recibido en formato string</param>
        /// <returns> Valor convertido a binario en formato string,
        ///           si falla retorna "Valor inválido"
        /// </returns>
        public string DecimalBinario(string numero)
        {            
            double dblDecimal;
            
            if (double.TryParse(numero, out dblDecimal))
            {
                return DecimalBinario(dblDecimal);
            }
            else
            {
                return "Valor inválido";
            }             
        }
        /// <summary>
        /// Valida que la cadena de caracteres esté compuesta solamente por caracteres '0' y '1'
        /// </summary>
        /// <param name="binario">Cadena a validar</param>
        /// <returns>true si es exitosa, false si falla</returns>
        private static bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0')
                {
                    if (binario[i]!= '1')
                    {
                        return false;                        
                    }                    
                }
            }
            return true;
        }
        #endregion

        #region /// Sobrecarga de operadores ///
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
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        #endregion

        #region /// Constructores ///
        /// <summary>
        /// Constructor por defecto
        /// </summary>        
        public Numero()
            : this(0)
        {
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
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region /// Validaciones ///
        /// <summary>
        /// Comprueba que el valor recibido sea numérico, y lo retorna en formato double
        /// </summary>
        /// <param name="strNumero">Valor recibido en formato string</param>
        /// <returns>Valor en formato double, o 0 si no es válido</returns>
        private double ValidarNumero(string strNumero)
        {
            int numero;

            if (int.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }


}
