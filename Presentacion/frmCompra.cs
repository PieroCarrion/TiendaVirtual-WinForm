using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negocio;
using Entidades;
namespace Presentacion {
    public partial class frmCompra : Form {
        private nDetalleVenta nDetalleVenta = null;
        private nProducto nProducto = null;
        private List<eProducto> cestaDeCompra = null;
        private frmRealizarCompra x = null;
        private ListViewItem item = null;
        public frmCompra() {
            InitializeComponent();
            nDetalleVenta = new nDetalleVenta();
            cestaDeCompra = new List<eProducto>();
            nProducto = new nProducto();
        }
        private void frmCompra_Load(object sender, EventArgs e) {
            if (nProducto.listarProductos() != null) {
                listBox1.DataSource = nProducto.listarProductos();
                listBox1.DisplayMember = "nombreProducto";
                listBox1.ValueMember = "codigoProducto";
                listBox1.SelectedIndex = -1;
            } else {
                MessageBox.Show("No hay productos en stock");
            }
        }
        private void listar() {
            if (Form1.clienteSesion != null) {
                if (Form1.listaDetalles != null) {
                    listView1.Items.Clear();
                    foreach (eDetalleVenta detalle in Form1.listaDetalles) {
                        item = new ListViewItem();
                        item = listView1.Items.Add(detalle.codigoProducto);
                        item.SubItems.Add(detalle.PUnitario.ToString());
                        item.SubItems.Add(detalle.cantidad.ToString());
                    }
                }
                lblCantidadProductos.Text = "Cantidad de productos: " + cantidadProductos();
                lblMontoAPagar.Text = "Monto a Pagar: " + string.Format("{0:F2}", Convert.ToDouble(montoAPagar()));
                if (Form1.clienteSesion.tipoCliente == "Premium") {
                    label2.Visible = true;
                    label2.Text = "Descuento: " + string.Format("{0:F2}", Convert.ToDouble(montoAPagar()) * 0.08);
                }
            }
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
        private decimal montoAPagar() {
            decimal monto = 0;
            if (Form1.listaDetalles != null) {
                foreach (eDetalleVenta detalle in Form1.listaDetalles) {
                    monto += (detalle.cantidad * detalle.PUnitario);
                }
            }
            return monto;
        }
        private void btnCompra_Click(object sender, EventArgs e) {
            if (Form1.listaDetalles.Count() != 0) {
                x = new frmRealizarCompra();
                foreach (eProducto producto in nProducto.listarProductos()) {
                    if (producto.codigoProducto == Form1.productoSeleccionado.codigoProducto) {
                        cestaDeCompra.Add(Form1.productoSeleccionado);
                        Form1.productoSeleccionado = null;
                        Form1.cantidadProducto = 0;
                    }
                }
                x.ShowDialog();
                if (!Form1.sesion) {
                    Close();
                }else {
                    listar();
                }
            } else {
                MessageBox.Show("No hay productos seleccionados");
            }
        }
        private void btnModifcarCompra_Click(object sender, EventArgs e) {
            if (Form1.listaDetalles != null) {
                Form1.listaDetalles = new List<eDetalleVenta>();
            }
            listar();
        }
        private void button1_Click(object sender, EventArgs e) {
            listar();
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (listBox1.SelectedIndex != -1) {
                Form1.productoSeleccionado = nProducto.buscarProductoxCodigo(listBox1.SelectedValue.ToString());
                frmProductoInfo x = new frmProductoInfo();
                x.ShowDialog();
                listar();
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }
        private void button3_Click(object sender, EventArgs e) {
            Form1.cantidadProducto = 0;
            Form1.productoSeleccionado = new eProducto();
            Form1.clienteSesion = null;
            Close();
        }
        private void frmCompra_Activated(object sender, EventArgs e) {
            listar();
        }
    }
}
