using System;
using System.Windows.Forms;
using Entidades;
using Negocio;
using System.Globalization;
namespace Presentacion {
    public partial class frmProductoInfo : Form {
        private eDetalleVenta eDetalle = null;
        private nProducto nProducto = null;
        public frmProductoInfo() {
            InitializeComponent();
            eDetalle = new eDetalleVenta();
            nProducto = new nProducto();
            textBox2.Text = "Producto: " + Form1.productoSeleccionado.nombreProducto;
            textBox3.Text = "Stock Disponible: " + Form1.productoSeleccionado.stockProducto;
            textBox4.Text = "Precio Unitario: S/." + string.Format("{0:F2}", Form1.productoSeleccionado.precioProducto);
            textBox5.Text = "Precio Total: S/.";
        }
        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "") {
                if (Convert.ToInt32(textBox1.Text) < 50 && Convert.ToInt32(textBox1.Text) > 0) {
                    if (Form1.productoSeleccionado.stockProducto - Convert.ToInt32(textBox1.Text) >= 0 && Convert.ToInt32(textBox1.Text) != 0) {
                        Form1.productoSeleccionado.cantidadCompra = Convert.ToInt32(textBox1.Text);
                        eDetalle.codigoProducto = Form1.productoSeleccionado.codigoProducto;
                        eDetalle.idVenta = Form1.numeroCorrelativo;
                        eDetalle.PUnitario = Form1.productoSeleccionado.precioProducto;
                        eDetalle.total = Form1.productoSeleccionado.precioProducto * Form1.productoSeleccionado.cantidadCompra;
                        eDetalle.cantidad = Form1.productoSeleccionado.cantidadCompra;
                        Form1.listaDetalles.Add(eDetalle);
                        Form1.cantidadProducto = 0;
                        Form1.productoSeleccionado = new eProducto();
                        Close();
                    } else {
                        MessageBox.Show("No hay stock disponible");
                    }
                }else {
                    MessageBox.Show("Solo puede comprar hasta 50 unidades");
                }
            } else {
                MessageBox.Show("Complete los espacios en blanco");
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            Form1.cantidadProducto = 0;
            Form1.productoSeleccionado = new eProducto();
            Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                if (Convert.ToInt32(textBox1.Text) > 0) {
                    textBox5.Text = "Precio Total: S/." + string.Format("{0:F2}", (Convert.ToInt32(textBox1.Text) * Form1.productoSeleccionado.precioProducto));
                }
            }else {
                textBox5.Text = "Precio Total: S/." + 0;
            }
        }
    }
}
