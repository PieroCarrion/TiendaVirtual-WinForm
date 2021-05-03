using System.Collections.Generic;
using Datos;
using Entidades;
namespace Negocio {
    public class nVenta {
        private dVenta venta = null;
        private dDetalleVenta dDetalleVenta = null;
        public nVenta() {
            venta = new dVenta();
            dDetalleVenta = new dDetalleVenta();
        }
        public bool registrarVenta(int numeroCorrelativo, List<eDetalleVenta> listaDetalles, string dniCliente, int cantidadProducto, decimal totalVenta, string fechaVenta,string destinoVenta) {
            //DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            eVenta objVenta = new eVenta(dniCliente,cantidadProducto,totalVenta,fechaVenta,destinoVenta);
            if (dDetalleVenta.registrarVenta(listaDetalles,numeroCorrelativo) && venta.insertarVenta(objVenta)) { 
                return true;
            } else {
                return false;
            }
        }
        public eVenta buscarVenta(int idVenta) {
            return venta.buscarVenta(idVenta);
        }
        public List<eVenta> listarVentas() {
            return venta.listarVentas();
        }
    }
}
