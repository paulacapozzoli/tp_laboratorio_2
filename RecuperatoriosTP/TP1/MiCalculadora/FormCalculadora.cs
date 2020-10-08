using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Cierra el formulario al presionar el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        /// <summary>
        /// Convierte el resultado a binario al presionar el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCovertirABinario_Click(object sender, EventArgs e)
        {
            if (Calculadora.switchDecimal == 0)
            {
                Numero numeroDecimal = new Numero(lblResultado.Text);
                Calculadora.switchDecimal = 1;
                lblResultado.Text = numeroDecimal.DecimalBinario(lblResultado.Text);
            }            
        }
        /// <summary>
        /// Convierte el resultado a decimal al presionar el boton 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCovertirADecimal_Click(object sender, EventArgs e)
        {
            if (Calculadora.switchDecimal == 1)
            {
                Numero numeroBinario = new Numero(lblResultado.Text);
                Calculadora.switchDecimal = 0;
                lblResultado.Text = numeroBinario.BinarioDecimal(lblResultado.Text);
            }
        }
    
        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla
        /// al presionar el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Refleja el resultado de una operacion al presionar el boton
        /// en el label lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string resultadoS = "";

            if(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)==0)
            {
                lblResultado.Text = "Ingrese solo numeros";//si dio 0 operar el lblResultado.Text va a decir Ingrese solo numeros!
            }
            else
            {
                double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);//sino asigno retorno de operar a un double
                resultadoS = resultado.ToString();// lo paso a string en otra variable
                lblResultado.Text = resultadoS;//esa variable string la asigno al lbl
            }                                                    
        }

        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Arroja mensaje para confirmar cierre del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        
        /// <summary>
        /// Carga formulario en memoria y borra cualquier contenido de los textBox, comboBox y labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla 
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.cmbOperador.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// Recibe dos numeros y un operador, llama al metodo Operar
        /// de Calculadora para realizar la operacion
        /// </summary>
        /// <param name="numero1">Primer numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operador del calculo</param>
        /// <returns>Resultado del calculo</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double num1;
            double num2;
            char chrOperador='0';
            Numero primerNumero = new Numero(numero1);
            Numero segundoNumero = new Numero(numero2);

            char.TryParse(operador, out chrOperador);

            if (!double.TryParse(numero1, out num1)||!double.TryParse(numero1, out num2))
            {
                return 0;
            }
            else
            {
                return Calculadora.Operar(primerNumero, segundoNumero, chrOperador);
                
            }
        }
    }
}
