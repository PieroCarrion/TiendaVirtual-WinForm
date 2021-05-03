using System;
using System.Linq;
using System.Windows.Forms;
using Negocio;
namespace Presentacion {
    public partial class frmRegistarUsuario : Form {
        private nCliente nCliente = null;
        public frmRegistarUsuario() {
            InitializeComponent();
            nCliente = new nCliente();
        }
        private void btnRegistrar_Click(object sender, EventArgs e) {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "") {
                if (textBox2.Text.Count() == 8) {
                    if (textBox4.Text == textBox5.Text) {
                        MessageBox.Show(nCliente.registrarCliente(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text, textBox6.Text));
                        Close();
                    } else {
                        MessageBox.Show("Las contraseñas deben ser iguales");
                    }
                } else {
                    MessageBox.Show("DNI inválido");
                }
            } else {
                MessageBox.Show("Complete los espacios en blanco");
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }
        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar)) {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                btnRegistrar_Click(sender,e);
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
    }
}
