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
        public FormCalculadora()
        {
            InitializeComponent();
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
            Numero primerNumero = new Numero(numero1);
            Numero segundoNumero = new Numero(numero2);

            return Calculadora.Operar(primerNumero, segundoNumero, operador);
        }

        /// <summary>
        /// Refleja el resultado de una operacion al presionar el boton
        /// en el label lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            string resultadoS = resultado.ToString();
            lblResultado.Text = resultadoS;
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla
        /// al presionar el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            cmbOperador.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// Cierra el formulario al presionar el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numeroDecimal = new Numero(lblResultado.Text);

            lblResultado.Text = numeroDecimal.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numeroBinario = new Numero(lblResultado.Text);

            lblResultado.Text = numeroBinario.BinarioDecimal(lblResultado.Text);
        }
    }
}
