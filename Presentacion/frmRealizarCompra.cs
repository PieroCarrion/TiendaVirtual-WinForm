using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using Negocio;
namespace Presentacion {
    public partial class frmRealizarCompra : Form {
        private nVenta nVenta = null;
        private nProducto nProducto = null;
        private frmCompraFinalizada auxForm = null;
        public frmRealizarCompra() {
            InitializeComponent();
            nVenta = new nVenta();
            nProducto = new nProducto();
        }
        private void frmRealizarCompra_Load(object sender, EventArgs e) {
            textBox3.Text = Form1.clienteSesion.nombreCliente;
            textBox5.Text = Form1.clienteSesion.dniCliente;
            textBox6.Text = Form1.clienteSesion.telefonoCliente;
            textBox4.Text = Form1.clienteSesion.direccionCliente;
            textBox7.Text = Form1.clienteSesion.tipoCliente;
            label5.Text = "Monto a pagar: S/."+ string.Format("{0:F2}", montoAPagar());
        }
        private int cantidadProductos() {
            int aux = 0;
            if (Form1.listaDetalles != null) {
                foreach (eDetalleVenta detalle in Form1.listaDetalles) {
                    aux += detalle.cantidad;
                }
            }
            return aux;
        }
        private double montoAPagar() {
            decimal monto = 0;
            if (Form1.listaDetalles != null) {
                foreach (eDetalleVenta detalle in Form1.listaDetalles) {
                    monto += (detalle.cantidad * detalle.PUnitario);
                }
            }
            if (Form1.clienteSesion.tipoCliente == "Premium") {
                return Convert.ToDouble(monto) * 0.92;
            } else {
                return Convert.ToDouble(monto);
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "") {
                if (Form1.listaDetalles != null) {
                    DateTime fechaHoy = DateTime.Now;
                    int numerocor = Form1.numeroCorrelativo;
                    if (nVenta.registrarVenta(numerocor,Form1.listaDetalles, Form1.clienteSesion.dniCliente, cantidadProductos(), Convert.ToDecimal(montoAPagar()), fechaHoy.ToShortDateString() + "(" + fechaHoy.ToShortTimeString()+")",textBox4.Text)) {
                        foreach (eDetalleVenta detalle in Form1.listaDetalles) {
                            nProducto.actualizarStock(detalle.codigoProducto,nProducto.buscarProductoxCodigo(detalle.codigoProducto).stockProducto-detalle.cantidad);
                        }
                        Form1.numeroCorrelativo++;
                        MessageBox.Show("Gracias Por Comprar en nuestra tienda");
                    } else {
                        MessageBox.Show("Error en realizar la compra");
                    }
                } else {
                    MessageBox.Show("No hay productos en la cesta");
                    Close();
                }
                Form1.listaDetalles = new List<eDetalleVenta>();
                auxForm = new frmCompraFinalizada();
                auxForm.ShowDialog();
                Close();
            } else {
                MessageBox.Show("Complete los espacios en blanco");
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
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
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void button3_Click(object sender, EventArgs e) {
            Close();
        }
        private void button2_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                button1_Click(sender,e);
            }
        }
    }
}
