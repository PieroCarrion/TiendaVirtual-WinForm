using System;
using System.Windows.Forms;
using Negocio;
using Entidades;
namespace Presentacion {
    public partial class frmAdministrador : Form {
        private nProducto nProducto = null;
        private eProducto eProducto = null;
        public frmAdministrador() {
            InitializeComponent();
            nProducto = new nProducto();
        }
        void listar() {
            listBox1.DataSource = nProducto.listarProductos();
            listBox1.DisplayMember = "nombreProducto";
            listBox1.ValueMember = "codigoProducto";
            listBox1.SelectedIndex = -1;
            listBox2.DataSource = nProducto.listarProductos();
            listBox2.DisplayMember = "nombreProducto";
            listBox2.ValueMember = "codigoProducto";
            listBox2.SelectedIndex = -1;
        }
        private void frmAdministrador_Load(object sender, EventArgs e) {
            nProducto = new nProducto();
            listar();
        }
        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "") {
                if (nProducto.buscarProductoxCodigo(textBox2.Text) == null) {
                    MessageBox.Show(nProducto.registrarProducto(textBox1.Text, textBox2.Text, Convert.ToDecimal(textBox3.Text), Convert.ToInt32(textBox4.Text)));
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox1.Focus();
                    listBox1.DataSource = null;
                    listBox2.DataSource = null;
                    listar();
                } else {
                    MessageBox.Show("Este producto ya existe");
                }
            } else {
                MessageBox.Show("Complete los espacios en blanco");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (listBox1.SelectedIndex != -1) {
                eProducto = nProducto.buscarProductoxCodigo(listBox1.SelectedValue.ToString());
                MessageBox.Show(nProducto.modificarProducto(eProducto.nombreProducto,eProducto.codigoProducto, Convert.ToDecimal(textBox5.Text),eProducto.stockProducto,eProducto.codigoProducto));
                //nProducto.cambiarPrecioDeProducto(listBox1.SelectedValue.ToString(), (double)Convert.ToDecimal(textBox5.Text));
                textBox5.Clear();
                listar();
            } else {
                MessageBox.Show("Seleccione un producto");
            }
        }
        private void button3_Click(object sender, EventArgs e) {
            if (listBox2.SelectedIndex != -1) {
                if(nProducto.actualizarStock(listBox1.SelectedValue.ToString(), Convert.ToInt32(textBox6.Text))) {
                    MessageBox.Show("Stock actualizado");
                    textBox6.Clear();
                    listar();
                } else {
                    MessageBox.Show("Error");
                }
            } else {
                MessageBox.Show("Seleccione un producto");
            }
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e) {
            if (listBox1.SelectedIndex != -1) {
                eProducto x = nProducto.listarProductos().Find(delegate (eProducto value) { return value.codigoProducto == listBox1.SelectedValue.ToString(); });
                label7.Text = "Precio: S/. " + string.Format("{0:F2}", x.precioProducto);
            }
        }
        private void listBox2_MouseClick(object sender, MouseEventArgs e) {
            if (listBox1.SelectedIndex != -1) {
                eProducto x = nProducto.listarProductos().Find(delegate (eProducto value) { return value.codigoProducto == listBox2.SelectedValue.ToString(); });
                label8.Text = "Stock Disponible: " + x.stockProducto;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsPunctuation(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void button4_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }
        private void button5_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
