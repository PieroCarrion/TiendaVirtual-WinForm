using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negocio;
using Entidades;
namespace Presentacion {
    public partial class frmReportes : Form {
        private nCliente nCliente = null;
        private nProducto nProducto = null;
        private nVenta nVenta = null;
        private nDetalleVenta nDetalleVenta = null;
        public frmReportes() {
            InitializeComponent();
            nCliente = new nCliente();
            nProducto = new nProducto();
            nVenta = new nVenta();
            nDetalleVenta = new nDetalleVenta();
            decimal monto = 0;
            if (nVenta.listarVentas() != null && nProducto.listarProductos() != null && nCliente.listarClientes() != null) {
                label1.Text = "Cantidad de Ventas: " + nVenta.listarVentas().Count().ToString();
                //
                foreach (eVenta nventa in nVenta.listarVentas()) {
                    monto += nventa.totalVenta;
                }
                //
                label2.Text = "Ganancias(S/.): " + string.Format("{0:F2}",Convert.ToDouble(monto));
                label4.Text = "Cantidad de Productos: " + nProducto.listarProductos().Count();
                //
                int x1, x2, x3;
                x1 = x2 = x3 = 0;
                foreach (eCliente cliente in nCliente.listarClientes()) {
                    if (cliente.tipoCliente == "No Premium") {
                        x1++;
                    } else if (cliente.tipoCliente == "Premium") {
                        x2++;
                    } else if (cliente.tipoCliente == "Administrador") {
                        x3++;
                    }
                }
                label6.Text = "Cantidad de Clientes No Premium: " + x1;
                label7.Text = "Cantidad de Clientes Premium: " + x2;
                label8.Text = "Cantidad de Administradores: " + x3;
                //
                if (nDetalleVenta.listarDetalles() != null) {
                    List<int> cantidadProductos = new List<int>();
                    foreach (eProducto producto in nProducto.listarProductos()) {
                        int aux = 0;
                        foreach (eDetalleVenta detalle in nDetalleVenta.listarDetalles()) {
                            if (detalle.codigoProducto == producto.codigoProducto) {
                                aux += detalle.cantidad;
                            }
                        }
                        cantidadProductos.Add(aux);
                    }
                    int mayor = 0;
                    int i = 0;
                    eProducto pro = null;
                    foreach (eProducto producto in nProducto.listarProductos()) {
                        if (cantidadProductos.ElementAt(i) > mayor) {
                            mayor = cantidadProductos.ElementAt(i);
                            pro = producto;
                        }
                        i++;
                    }
                    label3.Text = "Producto con Mayor Demanda: " + pro.nombreProducto + "(" + pro.codigoProducto + ")";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
        private void button2_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }
        private void frmReportes_Load(object sender, EventArgs e) {
            if (Form1.clienteSesion != null) {
                if (Form1.clienteSesion.tipoCliente == "Administrador") {
                    ListViewItem item;
                    if (nProducto.listarProductos()!=null) {
                        foreach (eProducto producto in nProducto.listarProductos()) {
                            item = new ListViewItem();
                            item = listView2.Items.Add(producto.nombreProducto);
                            item.SubItems.Add(producto.codigoProducto);
                            item.SubItems.Add(string.Format("{0:F2}",producto.precioProducto));
                            item.SubItems.Add(producto.stockProducto.ToString());
                        }
                    }
                    if (nVenta.listarVentas()!=null) {
                        foreach (eVenta venta in nVenta.listarVentas()) {
                            item = new ListViewItem();
                            item = listView3.Items.Add(venta.idVenta.ToString());
                            item.SubItems.Add(venta.dniCliente);
                            item.SubItems.Add(venta.cantidadProductosVenta.ToString());
                            item.SubItems.Add(string.Format("{0:F2}",venta.totalVenta));
                            item.SubItems.Add(venta.fechaVenta);
                            item.SubItems.Add(venta.destinoVenta);
                        }
                    }
                    if (nCliente.listarClientes() != null) {
                        foreach (eCliente cliente in nCliente.listarClientes()) {
                            item = new ListViewItem();
                            item = listView1.Items.Add(cliente.nombreCliente);
                            item.SubItems.Add(cliente.dniCliente);
                            item.SubItems.Add(cliente.direccionCliente);
                            item.SubItems.Add(cliente.telefonoCliente);
                            item.SubItems.Add(cliente.tipoCliente);
                        }
                    }
                } else {
                    MessageBox.Show("Usted no es un administrador");
                }
            } else {
                MessageBox.Show("Solo un administrador puede acceder a la información");
                Close();
            }
        }
        private void button3_Click(object sender, EventArgs e) {
            frmAdministrador x = new frmAdministrador();
            x.ShowDialog();
        }
    }
}
