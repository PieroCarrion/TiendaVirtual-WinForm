using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Negocio;
namespace Presentacion {
    public partial class Form1 : Form {
        public static eCliente clienteSesion;
        public static eProducto productoSeleccionado;
        public static int cantidadProducto;
        public static int numeroCorrelativo;
        public static List<eDetalleVenta> listaDetalles;
        public static bool sesion;
        private nCliente nCliente = null;
        private nVenta nVenta = null;
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            nVenta = new nVenta();
            nCliente = new nCliente();
            //ACTUALIZAR EL TIPO DE CLIENTE A PREMIUM SI TIENE MAS DE S/1000 en COMPRAS
            if (nVenta.listarVentas() != null) {
                List<decimal> cantidadComprasxCliente = new List<decimal>();
                decimal aux = 0;
                foreach (eCliente cliente in nCliente.listarClientes()) {
                        foreach (eVenta venta in nVenta.listarVentas()) {
                            if (venta.dniCliente == cliente.dniCliente) {
                                aux += venta.totalVenta;
                            }
                        }
                        cantidadComprasxCliente.Add(aux);
                        aux = 0;
                }
                int i = 0;
                foreach (eCliente cliente in nCliente.listarClientes()) {
                        if (cantidadComprasxCliente.ElementAt(i) > 1000) {
                            nCliente.actualizarCliente(cliente.dniCliente, "Premium");
                        }
                    i++;
                }
            }
            listaDetalles = new List<eDetalleVenta>();
            if (nVenta.listarVentas() != null) {
                foreach (eVenta venta in nVenta.listarVentas()) {
                    numeroCorrelativo = ++venta.idVenta;
                }
            } else {
                numeroCorrelativo = 0;
            }
        }
        private void abrir_FormCompra(object sender, EventArgs e) {
            frmCompra x = new frmCompra();
            x.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e) {
            frmRegistarUsuario x = new frmRegistarUsuario();
            x.ShowDialog();
        }
        private void btnIngresar_Click(object sender, EventArgs e) {
            if (textBox1.Text != "" && textBox2.Text != "") {
                if (textBox1.Text.Count() == 8) {
                    if (nCliente.existeCliente(textBox1.Text)) {
                        clienteSesion = nCliente.buscarCliente(textBox1.Text);
                        if (nCliente.buscarCliente(textBox1.Text).tipoCliente != "Administrador") {
                            MessageBox.Show("Bienvenido " + clienteSesion.nombreCliente);
                            abrir_FormCompra(sender, e);
                        } else if (nCliente.buscarCliente(textBox1.Text).tipoCliente == "Administrador") {
                            MessageBox.Show("Bienvenido administrador " + clienteSesion.nombreCliente);    
                        }
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    } else {
                        MessageBox.Show("El usuario no existe");
                    }
                } else {
                    MessageBox.Show("Ingrese un DNI válido");
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
            } else if (e.KeyChar == (char)Keys.Escape) {
                Close();
            } else {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsSeparator(e.KeyChar)) {
                e.Handled = true;
            } else if (e.KeyChar == (char)Keys.Escape) {
                Close();
            } else if (e.KeyChar == (char)Keys.Enter) {
                btnIngresar_Click(sender, e);
            } else {
                e.Handled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
        private void button2_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }
        private void btnCatálogos_Click(object sender, EventArgs e) {
            frmCatalogo x = new frmCatalogo();
            x.Show();
        }
        private void button5_Click(object sender, EventArgs e) {
            if (clienteSesion != null) {
                if (clienteSesion.nombreCliente[0] == 'x' || clienteSesion.nombreCliente[0] == 'X') {
                    frmReportes x = new frmReportes();
                    x.ShowDialog();
                } else {
                    MessageBox.Show("Solo un Administrador puede acceder");
                }
            } else {
                MessageBox.Show("Iniciar Sesion");
            }
        }
        private void button4_Click(object sender, EventArgs e) {
            Form1.clienteSesion = null;
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }
    }
}
