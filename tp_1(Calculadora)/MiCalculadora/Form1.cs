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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] operadores = { "+", "-", "*", "/" };
            foreach (string operador in operadores)
            {
                this.cmbOperador.Items.Add(operador);
            }
            this.cmbOperador.Items.Add("");
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOperador.SelectedItem = ("+");
            label1.Text = "";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            if (!((txtNumero1.Text).All(char.IsDigit)) || txtNumero1.Text == "")
            {
                txtNumero1.Text = "0";
            }
            if (!((txtNumero2.Text).All(char.IsDigit)) || txtNumero2.Text == "")
            {
                txtNumero2.Text = "0";
            }
            if (cmbOperador.Text != "+" && cmbOperador.Text != "-" && cmbOperador.Text != "*" && cmbOperador.Text != "/")
            {
                cmbOperador.Text = "+";
            }
            label1.Text = resultado.ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = true;
        }

        private static double Operar(string Numero1, string Numero2, string operador)
        {
            Numero numeroUno = new Numero(Numero1);
            Numero numeroDos = new Numero(Numero2);
            return Calculadora.Operar(numeroUno, numeroDos, operador);
        }

        private void Limpiar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is ComboBox || item is Label)
                {
                    item.Text = "";
                }
            }
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            label1.Text = Numero.DecimalBinario(label1.Text);
            if (label1.Text != "Valor invalido")
            {
                btnConvertirABinario.Enabled = false;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            label1.Text = Numero.BinarioDecimal(label1.Text);
            btnConvertirABinario.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}