using Entidades;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        public FormCalculadora()
        {
            InitializeComponent();


            this.cmbOperador.Items.Add("");
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            this.lblResultado.Text = string.Empty;
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.cmbOperador.SelectedIndex = 0;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.txtNumero1.Text == String.Empty || this.txtNumero2.Text == String.Empty)
            {
                MessageBox.Show("Faltan campos para realizar la operación");
            }
            else if (this.cmbOperador.Text == "/" && this.txtNumero2.Text == "0")
            {
                this.lblResultado.Text = Convert.ToString(double.MinValue);
                MessageBox.Show("No se puede dividir por 0");
            }
            else
            {

                if (this.cmbOperador.Text == String.Empty)
                {
                    this.cmbOperador.Text = "+";
                }

                double resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
                string cadena = String.Format(this.txtNumero1.Text + this.cmbOperador.Text + this.txtNumero2.Text + '=');


                if (this.cmbOperador.Text == "/")
                {
                    this.lblResultado.Text = resultado.ToString("N2");
                    this.lstOperaciones.Items.Add(cadena + resultado.ToString("N2"));
                }
                else
                {
                    this.lblResultado.Text = resultado.ToString();
                    this.lstOperaciones.Items.Add(cadena + resultado.ToString());

                }
            }

        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            if (operador == String.Empty)
            {
                operador = "+";
            }
            char op = Convert.ToChar(operador);

            double resultado = Calculadora.Operar(n1, n2, op);

            return resultado;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
           Operando operando = new Operando();
            if (!String.IsNullOrEmpty (this.lblResultado.Text))
            {

            this.lblResultado.Text = operando.DecimalBinario(this.lblResultado.Text);
            this.lstOperaciones.Items.Add(lblResultado.Text);
            }
            else
            {
                MessageBox.Show("No hay nada para convertir");
            }

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();
            if (!String.IsNullOrEmpty(this.lblResultado.Text))
            {

                this.lblResultado.Text = operando.BinarioDecimal(this.lblResultado.Text);
                this.lstOperaciones.Items.Add(lblResultado.Text);

            }
            else
            {
                MessageBox.Show("No hay nada para convertir");
            }
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir?", "Salida", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solamente números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solamente números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
